using IntroTo.WPF.Desktop.Commands;

namespace IntroTo.WPF.Desktop.Services.Factories;

public interface ICommandsFactory
{
    TCommand CreateCommand<TCommand>()
        where TCommand : Command;
}