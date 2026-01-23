using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Launcher.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    public partial string Username { get; set; } = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    public partial string Password { get; set; } = string.Empty;

    public event EventHandler? LoginCompleted;

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private Task LoginAsync()
    {
        if (true)
        {
            LoginCompleted?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Password = string.Empty;
        }

        return Task.CompletedTask;
    }

    private bool CanLogin() => !string.IsNullOrWhiteSpace(Username) &&
                               !string.IsNullOrWhiteSpace(Password);
}