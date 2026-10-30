
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PerformanceMAUI.DataAccess;

namespace PerformanceMAUI.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    private readonly ApiService _api = new();

    public string Username { get; set; } = "";
    public string Password { get; set; } = "";

    private string _message = "";
    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }

    public async Task<bool> LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Username) ||
            string.IsNullOrWhiteSpace(Password))
        {
            Message = "Enter your username and password.";
            return false;
        }

        try
        {
            bool success = await _api.LoginAsync(Username, Password);
            Message = success ? "" : "Login failed.";
            return success;
        }
        catch (HttpRequestException)
        {
            Message = "Unable to connect to the web service.";
            return false;
        }
    }

    public void Cancel()
    {
        Username = "";
        Password = "";
        Message = "";

        OnPropertyChanged(nameof(Username));
        OnPropertyChanged(nameof(Password));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

