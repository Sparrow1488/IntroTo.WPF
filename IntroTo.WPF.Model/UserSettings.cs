namespace IntroTo.WPF.Model;

public class UserSettings : Identity
{
    public int UserId { get; set; }
    public bool IsPublic { get; set; } = true;
    public bool NotificationsEnabled { get; set; } = true;
}