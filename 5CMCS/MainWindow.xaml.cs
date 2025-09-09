using System.Windows;
using System.Windows.Media;   // <-- needed for Brushes

namespace _5CMCS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set background color of MainWindow to light gray
            this.Background = Brushes.LightGray;

            // Load default dashboard view
            ContentHost.Content = new Views.DashboardView();
        }

        // Existing menu handlers (keep them)
        private void GoDashboard(object s, RoutedEventArgs e)
        {
            ContentHost.Content = new Views.DashboardView();
            this.Background = Brushes.Orange; // Window bg changes when clicking Dashboard
        }

        private void GoSubmit(object s, RoutedEventArgs e)
        {
            ContentHost.Content = new Views.SubmitClaimView();
            this.Background = Brushes.Orange; // bg changes for Submit
        }

        private void GoUpload(object s, RoutedEventArgs e)
        {
            ContentHost.Content = new Views.UploadDocsView();
            this.Background = Brushes.Orange; // bg changes for Upload
        }

        private void GoApprovals(object s, RoutedEventArgs e)
        {
            ContentHost.Content = new Views.ApprovalsView();
            this.Background = Brushes.Orange; // bg changes for Approvals
        }

        private void GoStatus(object s, RoutedEventArgs e)
        {
            ContentHost.Content = new Views.StatusTrackerView();
            this.Background = Brushes.Orange; // bg changes for Status
        }

        // NEW: public helpers so UserControls can navigate cleanly
        public void ShowSubmit() => ContentHost.Content = new Views.SubmitClaimView();
        public void ShowUpload() => ContentHost.Content = new Views.UploadDocsView();
        public void ShowStatus() => ContentHost.Content = new Views.StatusTrackerView();
    }
}