using IntroTo.WPF.Desktop.Services.Navigation;
using IntroTo.WPF.Desktop.Services.User;

namespace IntroTo.WPF.Desktop.ViewModels;

public class ProfileViewModel : ViewModel
{
    private string _username;

    public ProfileViewModel(
        INavigationStore store,
        IUserService userService) : base(store)
    {
        _username = userService.Current?.Info?.Username ?? string.Empty;
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
}