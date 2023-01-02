using System.Reactive;
using System.Security.AccessControl;
using System.Windows.Input;
using ReactiveUI;

namespace IntroTo.Reactive.Console;

public class CanExecuteCommandLesson
{
    public CanExecuteCommandLesson()
    {
        var canSave = this.WhenAnyValue(
            x => x.Username,
            x => x.Password,
            (username, password) => 
                !string.IsNullOrWhiteSpace(username) &&
                !string.IsNullOrWhiteSpace(password));

        SaveCommand = ReactiveCommand.CreateFromTask(SaveAsync, canSave);
    }
    
    public string Username { get; set; }
    public string Password { get; set; }

    public ICommand SaveCommand { get; }

    private static Task SaveAsync()
    {
        System.Console.WriteLine("Saved");
        return Task.CompletedTask;
    }
}