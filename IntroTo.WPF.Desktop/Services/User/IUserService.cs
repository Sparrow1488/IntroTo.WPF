namespace IntroTo.WPF.Desktop.Services.User;

public interface IUserService
{
    IntroTo.WPF.Model.User Current { get; }
    void Update(IntroTo.WPF.Model.User user);
}