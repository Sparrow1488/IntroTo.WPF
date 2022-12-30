using System;
using IntroTo.WPF.Desktop.Commands;
using IntroTo.WPF.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace IntroTo.WPF.Desktop.Services.Navigation;

public class NavigationCommandFactory : INavigationCommandFactory
{
    private readonly IServiceProvider _services;

    public NavigationCommandFactory(IServiceProvider services)
    {
        _services = services;
    }
    
    public NavigationCommand<TViewModel> CreateNavigation<TViewModel>() 
        where TViewModel : ViewModel =>
            ActivatorUtilities.CreateInstance<NavigationCommand<TViewModel>>(_services);
}