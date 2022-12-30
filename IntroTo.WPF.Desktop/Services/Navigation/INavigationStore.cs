using IntroTo.WPF.Desktop.ViewModels;

namespace IntroTo.WPF.Desktop.Services.Navigation;

public interface INavigationStore
{
    event ViewModelChanged? ViewModelChanged;
    ViewModel? CurrentViewModel { get; set; }
}

public delegate void ViewModelChanged();
