using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using _5CMCS.Data;

namespace _5CMCS.Views
{
    public partial class StatusTrackerView : UserControl
    {
        private ItemsControl? _items;
        private DataGrid? _grid;

        private sealed class RowVM
        {
            public int ClaimId { get; set; }
            public string Lecturer { get; set; } = "";
            public string Month { get; set; } = "";
            public double TotalAmount { get; set; }
            public string Status { get; set; } = "";
            public string? Document { get; set; }
        }

        public StatusTrackerView()
        {
            InitializeComponent();
            Loaded += StatusTrackerView_Loaded;
        }

        private void StatusTrackerView_Loaded(object sender, RoutedEventArgs e)
        {
            _items = FindName("Timeline") as ItemsControl ?? _items;
            _grid = FindName("GridAll") as DataGrid ?? _grid;

            _items ??= FindFirst<ItemsControl>(this);
            _grid ??= FindFirst<DataGrid>(this);

            Refresh();
        }

        private void Refresh()
        {
            try
            {
                using var db = Services.CreateDb();
                var rows = db.Claims
                    .Include(c => c.Lecturer)
                    .AsNoTracking()
                    .OrderByDescending(c => c.ClaimId)
                    .Select(c => new RowVM
                    {
                        ClaimId = c.ClaimId,
                        Lecturer = c.Lecturer != null ? c.Lecturer.Name : "",
                        Month = c.Month,
                        TotalAmount = Math.Round(c.HoursWorked * c.HourlyRate, 2),
                        Status = c.Status,
                        Document = c.DocumentName
                    })
                    .ToList();

                if (_grid != null) { _grid.ItemsSource = rows; }
                if (_items != null) { _items.ItemsSource = rows; }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load claim statuses:\n{ex.Message}",
                    "Status Tracker", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static T? FindFirst<T>(DependencyObject root) where T : DependencyObject
        {
            for (int i = 0, n = VisualTreeHelper.GetChildrenCount(root); i < n; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                if (child is T t) return t;
                var nested = FindFirst<T>(child);
                if (nested != null) return nested;
            }
            return null;
        }
    }
}