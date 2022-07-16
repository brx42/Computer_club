namespace Computer_club.Domain.Models;

public class Token
{
    public string Username { get; set; }
    public string UserId { get; set; }
    public string JwtToken { get; set; }
    public string RefreshToken { get; set; }
}