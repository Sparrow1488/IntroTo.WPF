using System.ComponentModel;
using System.Runtime.CompilerServices;
using IntroTo.WPF.Desktop.ViewModels;

namespace IntroTo.WPF.Desktop.Services.Navigation;

public sealed class NavigationStore : INavigationStore, INotifyPropertyChanged
{
    private ViewModel? _currentViewModel;
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public event ViewModelChanged? ViewModelChanged;

    public NavigationStore() { }

    public ViewModel? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
            ViewModelChanged?.Invoke();
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}