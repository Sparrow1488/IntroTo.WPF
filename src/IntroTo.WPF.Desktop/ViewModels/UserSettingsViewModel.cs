using System.Windows.Input;
using IntroTo.WPF.Desktop.Commands;
using IntroTo.WPF.Desktop.Services.Factories;
using IntroTo.WPF.Desktop.Services.Navigation;
using IntroTo.WPF.Desktop.Services.User;

namespace IntroTo.WPF.Desktop.ViewModels;

public sealed class UserSettingsViewModel : ViewModel
{
    private readonly ICommandsFactory _commandsFactory;
    private string _username;
    private bool _isPublic;
    private bool _notificationsEnabled;

    public UserSettingsViewModel(
        INavigationStore store, 
        IUserService userService,
        ICommandsFactory commandsFactory) : base(store)
    {
        _commandsFactory = commandsFactory;
        _username = userService.Current.Info?.Username ?? string.Empty;
        _isPublic = userService.Current.Settings?.IsPublic ?? false;
        _notificationsEnabled = userService.Current.Settings?.NotificationsEnabled ?? false;
    }
    
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }
    public bool IsPublic
    {
        get => _isPublic;
        set
        {
            _isPublic = value;
            OnPropertyChanged(nameof(IsPublic));
        }
    }
    public bool NotificationsEnabled
    {
        get => _notificationsEnabled;
        set
        {
            _notificationsEnabled = value;
            OnPropertyChanged(nameof(NotificationsEnabled));
        }
    }

    public ICommand SaveSettingsCommand => _commandsFactory.CreateCommand<SaveUserSettingsCommand>();
}