using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using _5CMCS.Data;
using _5CMCS.Models;

namespace _5CMCS.Views
{
    public partial class SubmitClaimView : UserControl
    {
        public SubmitClaimView()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var db = Services.CreateDb();

                var lecturer = db.Lecturers.FirstOrDefault();
                if (lecturer == null)
                {
                    MessageBox.Show("No lecturer found. Restart the app to add one.",
                        "Submit", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var month = (CmbMonth.SelectedItem as ComboBoxItem)?.Content?.ToString()?.Trim() ?? "";
                if (!Regex.IsMatch(month, @"^\d{4}-\d{2}$"))
                {
                    MessageBox.Show("Select a valid Month (YYYY-MM).",
                        "Submit", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                var contract = (CmbContract.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
                var m = Regex.Match(contract, @"R\s*(\d+(\.\d+)?)", RegexOptions.IgnoreCase);
                if (!m.Success)
                {
                    MessageBox.Show("Could not detect hourly rate in the selected contract.",
                        "Submit", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                var rate = double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);

                double totalHours = 0;
                foreach (var item in GridLines.Items)
                {
                    if (item == CollectionView.NewItemPlaceholder) continue;
                    var p = item.GetType().GetProperty("Hours");
                    if (p != null && double.TryParse($"{p.GetValue(item)}", out var h)) totalHours += h;
                }

                var claim = new Claim
                {
                    LecturerId = lecturer.LecturerId,
                    Month = month,
                    HoursWorked = totalHours,
                    HourlyRate = rate,
                    Notes = "",
                    DocumentName = null,
                    Status = "Pending"
                };

                db.Claims.Add(claim);
                db.SaveChanges();

                MessageBox.Show("Claim submitted successfully!",
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting claim:\n{ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}