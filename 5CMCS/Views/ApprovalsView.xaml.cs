using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using _5CMCS.Data;

namespace _5CMCS.Views
{
    public partial class ApprovalsView : UserControl
    {
        private DataGrid? _grid;

        private sealed class RowVM
        {
            public int ClaimId { get; set; }
            public string Lecturer { get; set; } = "";
            public string Month { get; set; } = "";
            public string Status { get; set; } = "";
        }

        public ApprovalsView()
        {
            InitializeComponent();
            Loaded += ApprovalsView_Loaded;
        }

        private void ApprovalsView_Loaded(object? sender, RoutedEventArgs e)
        {
            _grid ??= FindFirstDataGrid(this);
            Refresh();
        }

        private void Refresh()
        {
            try
            {
                if (_grid == null) return;

                using var db = Services.CreateDb();
                var rows = db.Claims
                    .Include(c => c.Lecturer)
                    .AsNoTracking()
                    .Where(c => c.Status == "Pending" || c.Status == "Verified")
                    .OrderBy(c => c.ClaimId)
                    .Select(c => new RowVM
                    {
                        ClaimId = c.ClaimId,
                        Lecturer = c.Lecturer != null ? c.Lecturer.Name : "",
                        Month = c.Month,
                        Status = c.Status
                    })
                    .ToList();

                _grid.ItemsSource = rows;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load claims:\n{ex.Message}",
                    "Approvals", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Verify_Click(object sender, RoutedEventArgs e)
            => UpdateStatusSelected("Verified", "marked as Verified.");

        private void Approve_Click(object sender, RoutedEventArgs e)
            => UpdateStatusSelected("Approved", "approved.");

        private void Reject_Click(object sender, RoutedEventArgs e)
            => UpdateStatusSelected("Rejected", "rejected.");

        private void UpdateStatusSelected(string newStatus, string successText)
        {
            try
            {
                var row = _grid?.SelectedItem as RowVM;
                if (row == null) { MessageBox.Show("Select a claim first."); return; }

                using var db = Services.CreateDb();
                var claim = db.Claims.Find(row.ClaimId);
                if (claim == null) { MessageBox.Show("Claim not found."); return; }

                claim.Status = newStatus;
                db.SaveChanges();

                MessageBox.Show($"Claim #{claim.ClaimId} {successText}",
                    "Approvals", MessageBoxButton.OK, MessageBoxImage.Information);

                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not update claim:\n{ex.Message}",
                    "Approvals", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static DataGrid? FindFirstDataGrid(DependencyObject root)
        {
            for (int i = 0, n = VisualTreeHelper.GetChildrenCount(root); i < n; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is DataGrid dg) return dg;
                var nested = FindFirstDataGrid(child);
                if (nested != null) return nested;
            }
            return null;
        }
    }
}