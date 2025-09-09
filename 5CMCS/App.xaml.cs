using System.Windows;

namespace _5CMCS
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Show login first (modal)
            ShutdownMode = ShutdownMode.OnExplicitShutdown;

            var login = new LoginWindow();
            var ok = login.ShowDialog() == true;

            if (!ok)
            {
                Shutdown();
                return;
            }

            var main = new MainWindow();
            MainWindow = main;
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            main.Show();
        }
    }
}