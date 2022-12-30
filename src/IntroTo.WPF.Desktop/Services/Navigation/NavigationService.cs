using IntroTo.WPF.Desktop.ViewModels;

namespace IntroTo.WPF.Desktop.Services.Navigation;

public class NavigationService : INavigationService
{
    private readonly INavigationCommandFactory _navigateFactory;

    public NavigationService(INavigationCommandFactory navigateFactory)
    {
        _navigateFactory = navigateFactory;
    }
    
    public void Navigate<TViewModel>() where TViewModel : ViewModel
    {
        var navigationCommand = _navigateFactory.CreateNavigation<TViewModel>();
        navigationCommand.Execute(this);
    }
}