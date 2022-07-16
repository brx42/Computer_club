using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Computer_club.Domain.Options;

public class JWT
{
    public static string Issuer { get; set; }
    public static string Audience { get; set; }
    public static string Key { get; set; }
    public static int LifeTime { get; set; }

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}