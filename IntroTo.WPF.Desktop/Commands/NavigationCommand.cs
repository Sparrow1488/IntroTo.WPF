using System;
using IntroTo.WPF.Desktop.Services.Navigation;
using IntroTo.WPF.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace IntroTo.WPF.Desktop.Commands;

public class NavigationCommand<TViewModel> : Command
    where TViewModel : notnull, ViewModel
{
    private readonly INavigationStore _store;
    private readonly IServiceProvider _services;

    public NavigationCommand(
        INavigationStore store,
        IServiceProvider services)
    {
        _store = store;
        _services = services;
    }

    private TViewModel NavigateViewModel => _services.GetRequiredService<TViewModel>();
    
    protected override void Execute() =>
        _store.CurrentViewModel = NavigateViewModel;
}