using Newtonsoft.Json;

namespace Computer_club.Domain.Models;

public class Authentication
{
    public string Message { get; set; }
    public bool IsAuthenticated { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
    public string Token { get; set; }
    [JsonIgnore]
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }
}