using System.Windows.Controls;

namespace _5CMCS.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        private void GoSubmit_Click(object sender, System.Windows.RoutedEventArgs e)
            => ((MainWindow)System.Windows.Application.Current.MainWindow).ShowSubmit();

        private void GoUpload_Click(object sender, System.Windows.RoutedEventArgs e)
            => ((MainWindow)System.Windows.Application.Current.MainWindow).ShowUpload();

        private void GoStatus_Click(object sender, System.Windows.RoutedEventArgs e)
            => ((MainWindow)System.Windows.Application.Current.MainWindow).ShowStatus();
    }
}