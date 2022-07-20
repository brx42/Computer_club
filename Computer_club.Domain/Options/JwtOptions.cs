using Microsoft.IdentityModel.Tokens;

namespace Computer_club.Domain.Options;

public class JwtOptions
{
    public static string Issuer { get; set; }
    public static string Audience { get; set; }
    public static int LifeTime { get; set; }
    public static string Key { get; set; }
    
}