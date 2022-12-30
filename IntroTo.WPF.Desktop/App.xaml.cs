using System;
using System.Windows;
using IntroTo.WPF.Desktop.Services.Contexts;
using IntroTo.WPF.Desktop.Services.Factories;
using IntroTo.WPF.Desktop.Services.Handlers;
using IntroTo.WPF.Desktop.Services.Navigation;
using IntroTo.WPF.Desktop.Services.User;
using IntroTo.WPF.Desktop.ViewModels;
using IntroTo.WPF.Desktop.Windows;
using IntroTo.WPF.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace IntroTo.WPF.Desktop;

public partial class App
{
    public App()
    {
        ApplicationHost = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>();
                
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<ProfileViewModel>();
                services.AddSingleton<UserSettingsViewModel>();
                
                services.AddSingleton<INavigationStore, NavigationStore>();
                services.AddSingleton<INavigationCommandFactory, NavigationCommandFactory>();
                services.AddSingleton<ICommandsFactory, DefaultCommandsFactory>();
                
                services.AddSingleton<IErrorsService, DefaultErrorsService>();
                services.AddSingleton<INavigationService, NavigationService>();
                services.AddSingleton<IUserService, UserService>();
                
                services.AddSingleton<ApplicationContext, DefaultApplicationContext>();
            }).Build();
    }

    private IHost ApplicationHost { get; }
    private IServiceProvider Services => ApplicationHost.Services;
    
    protected override void OnStartup(StartupEventArgs e)
    {
        SetupMainWindow();
        SetupCurrentViewModel();
        SetupCurrentUser();
        
        base.OnStartup(e);
    }

    private void SetupMainWindow()
    {
        MainWindow = GetRequired<MainWindow>();
        MainWindow.Show();
        MainWindow.DataContext = GetRequired<MainViewModel>();
    }

    private void SetupCurrentViewModel()
    {
        var navigationService = GetRequired<INavigationService>();
        navigationService.Navigate<HomeViewModel>();
    }

    private void SetupCurrentUser()
    {
        var options = GetRequired<IOptions<UserServiceOptions>>();
        options.Value.CurrentUser = new User
        {
            Info = new UserInfo { Username = "Valentin" },
            Settings = new UserSettings() { IsPublic = true, NotificationsEnabled = false }
        };
    }

    private T GetRequired<T>() 
        where T : notnull => Services.GetRequiredService<T>();
}
