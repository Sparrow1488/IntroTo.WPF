using System;
using IntroTo.WPF.Model;
using Microsoft.Extensions.Options;

namespace IntroTo.WPF.Desktop.Services.User;

public class UserService : IUserService
{
    public UserService(IOptions<UserServiceOptions> options)
    {
        Options = options;
    }
    
    private IOptions<UserServiceOptions> Options { get; }
    public Model.User Current => Options.Value.CurrentUser ?? throw new Exception("No current user");
    
    public void Update(Model.User user)
    {
        if (Options.Value.CurrentUser is null)
            throw new Exception("Current user not set!");

        Current.Info = user.Info;
        Current.Settings = user.Settings;
    }
}