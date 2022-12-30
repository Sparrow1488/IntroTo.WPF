namespace IntroTo.WPF.Model;

public class UserInfo : Identity
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
}