using System.Linq;
using IntroTo.WPF.Desktop.Exceptions;
using IntroTo.WPF.Desktop.Services.Contexts;
using IntroTo.WPF.Desktop.Services.Navigation;
using IntroTo.WPF.Desktop.Services.User;
using IntroTo.WPF.Desktop.ViewModels;
using IntroTo.WPF.Model;

namespace IntroTo.WPF.Desktop.Commands;

public sealed class SaveUserSettingsCommand : Command
{
    private readonly INavigationService _navigationService;
    private readonly IUserService _userService;
    private readonly UserSettingsViewModel _settingsViewModel;
    private readonly ApplicationContext _applicationContext;

    public SaveUserSettingsCommand(
        INavigationService navigationService, 
        IUserService userService,
        UserSettingsViewModel settingsViewModel,
        ApplicationContext applicationContext)
    {
        _navigationService = navigationService;
        _userService = userService;
        _settingsViewModel = settingsViewModel;
        _applicationContext = applicationContext;
    }
    
    protected override void Execute()
    {
        if (!ConfirmUsernameValidity()) return;
        
        var changedSettings = new UserSettings
        {
            IsPublic = _settingsViewModel.IsPublic,
            NotificationsEnabled = _settingsViewModel.NotificationsEnabled
        };
        var changedInfo = new UserInfo { Username = _settingsViewModel.Username };
            
        _userService.Update(new User
        {
            Info = changedInfo,
            Settings = changedSettings
        });
            
        _navigationService.Navigate<ProfileViewModel>();
    }

    private bool ConfirmUsernameValidity()
    {
        if (string.IsNullOrWhiteSpace(_settingsViewModel.Username) ||
            _settingsViewModel.Username.Any(x => x == ' '))
        {
            _applicationContext.AddError(
                "Username invalid or contains forbidden chars",
                new ValidationException());
            return false;
        }

        return true;
    }
}