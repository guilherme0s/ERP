using System.Windows;
using Launcher;

namespace Launcher;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var loginWindow = new LoginWindow();
        var loginSuccess = loginWindow.ShowDialog() == true;

        if (loginSuccess)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
        else
        {
            Shutdown();
        }
    }
}