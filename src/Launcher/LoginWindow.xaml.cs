using System.Windows;
using Launcher.ViewModels;

namespace Launcher;

public partial class LoginWindow
{
    private LoginViewModel? ViewModel => DataContext as LoginViewModel;

    public LoginWindow()
    {
        InitializeComponent();

        Loaded += LoginWindow_OnLoaded;
    }

    private void LoginWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (ViewModel != null)
        {
            ViewModel.LoginCompleted += ViewModel_OnLoginCompleted;
        }

        UsernameTextBox.Focus();
    }

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        ViewModel?.Password = PasswordBox.Password;
    }

    private void ViewModel_OnLoginCompleted(object? sender, EventArgs e)
    {
        DialogResult = true;
        Close();
    }

    protected override void OnClosed(EventArgs e)
    {
        if (ViewModel != null)
        {
            ViewModel.LoginCompleted -= ViewModel_OnLoginCompleted;
        }

        base.OnClosed(e);
    }
}
