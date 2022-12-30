using System.ComponentModel;
using IntroTo.WPF.Desktop.Services.Navigation;

namespace IntroTo.WPF.Desktop.ViewModels;

public abstract class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public ViewModel(
        INavigationStore store)
    {
        Store = store;
    }
    
    protected INavigationStore Store { get; }

    protected virtual void OnPropertyChanged(string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}