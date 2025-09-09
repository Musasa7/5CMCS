using System.Windows;

namespace _5CMCS
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtUser.Text) &&
                !string.IsNullOrWhiteSpace(TxtPass.Password))
            {
                DialogResult = true; // success → App opens MainWindow
            }
            else
            {
                MessageBox.Show("Enter username & password (prototype).",
                    "Sign in", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}