using IntroTo.WPF.Desktop.ViewModels;

namespace IntroTo.WPF.Desktop.Services.Navigation;

public interface INavigationService
{
    void Navigate<TViewModel>() where TViewModel : ViewModel;
}