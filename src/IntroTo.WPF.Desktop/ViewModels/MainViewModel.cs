using System.Windows.Input;
using IntroTo.WPF.Desktop.Commands;
using IntroTo.WPF.Desktop.Services.Contexts;
using IntroTo.WPF.Desktop.Services.Handlers;
using IntroTo.WPF.Desktop.Services.Navigation;

namespace IntroTo.WPF.Desktop.ViewModels;

public class MainViewModel : ViewModel
{
    private readonly INavigationStore _store;
    private readonly INavigationCommandFactory _navigationFactory;

    public MainViewModel(
        INavigationStore store,
        ApplicationContext appContext,
        INavigationCommandFactory navigationFactory,
        IErrorsService errorsService) 
    : base(store)
    {
        _store = store;
        _navigationFactory = navigationFactory;
        _store.ViewModelChanged += () => OnPropertyChanged(nameof(CurrentViewModel));
        appContext.ErrorAdded += errorsService.ShowError;
    }

    public ViewModel? CurrentViewModel => _store.CurrentViewModel;

    public ICommand NavigateHomeCommand => NavigateTo<HomeViewModel>();
    public ICommand NavigateProfileCommand => NavigateTo<ProfileViewModel>();
    public ICommand NavigateSettingsCommand => NavigateTo<UserSettingsViewModel>();

    private NavigationCommand<TViewModel> NavigateTo<TViewModel>()
        where TViewModel : ViewModel => _navigationFactory.CreateNavigation<TViewModel>();
}