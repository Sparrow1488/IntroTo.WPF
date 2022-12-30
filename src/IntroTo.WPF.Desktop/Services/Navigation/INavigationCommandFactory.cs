using IntroTo.WPF.Desktop.Commands;
using IntroTo.WPF.Desktop.ViewModels;

namespace IntroTo.WPF.Desktop.Services.Navigation;

public interface INavigationCommandFactory
{
    NavigationCommand<TViewModel> CreateNavigation<TViewModel>()
        where TViewModel : ViewModel;
}