using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IntroTo.WPF.Desktop.Models;

public class UserSettingsModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public bool IsPublic { get; set; } = true;
    public bool NotificationsEnabled { get; set; } = true;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}