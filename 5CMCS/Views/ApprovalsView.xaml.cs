using System.Windows;
using System.Windows.Controls;

namespace _5CMCS.Views
{
    public partial class ApprovalsView : UserControl
    {
        public ApprovalsView()
        {
            InitializeComponent();
        }

        private void Verify_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Coming soon", "Verify", MessageBoxButton.OK, MessageBoxImage.Information);

        private void Approve_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Coming soon", "Approve", MessageBoxButton.OK, MessageBoxImage.Information);

        private void Reject_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Coming soon", "Reject", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
