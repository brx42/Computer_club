namespace Computer_club.Data.Models.UserModels;

public class Token
{
    public string Username { get; set; }
    public Guid UserId { get; set; }
    public string? JwtToken { get; set; }
    public string? RefreshToken { get; set; }
    public string Role { get; set; }
}