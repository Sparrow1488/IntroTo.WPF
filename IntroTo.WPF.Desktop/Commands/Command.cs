using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IntroTo.WPF.Desktop.Commands;

public abstract class Command : ICommand
{
    public event EventHandler? CanExecuteChanged;
    
    public virtual bool CanExecute(object? parameter) => true;
    public virtual void Execute(object? parameter) => Execute();
    protected virtual Task ExecuteAsync() => Task.Run(Execute);
    protected abstract void Execute();
}