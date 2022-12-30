using System;
using IntroTo.WPF.Desktop.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace IntroTo.WPF.Desktop.Services.Factories;

public class DefaultCommandsFactory : ICommandsFactory
{
    private readonly IServiceProvider _services;

    public DefaultCommandsFactory(IServiceProvider services)
    {
        _services = services;
    }
    
    public TCommand CreateCommand<TCommand>() 
        where TCommand : Command =>
            ActivatorUtilities.GetServiceOrCreateInstance<TCommand>(_services);
}