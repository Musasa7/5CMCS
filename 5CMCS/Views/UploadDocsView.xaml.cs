using System.Windows;
using System.Windows.Controls;

namespace _5CMCS.Views
{
    public partial class UploadDocsView : UserControl
    {
        public UploadDocsView()
        {
            InitializeComponent();
        }

        private void BrowseFiles_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming soon", "Browse Files", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OneDrive_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming soon", "OneDrive", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}