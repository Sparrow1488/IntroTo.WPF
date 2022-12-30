namespace IntroTo.WPF.Model;

public class User : Identity
{
    public UserInfo? Info { get; set; }
    public UserSettings? Settings { get; set; }
}