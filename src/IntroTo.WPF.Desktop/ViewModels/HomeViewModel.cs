using IntroTo.WPF.Desktop.Services.Navigation;

namespace IntroTo.WPF.Desktop.ViewModels;

public class HomeViewModel : ViewModel
{
    public HomeViewModel(INavigationStore store) : base(store)
    {
    }
}