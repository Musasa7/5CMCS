using System.Windows;
using System.Windows.Controls;

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
            MessageBox.Show("Coming soon", "Submit Claim", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}