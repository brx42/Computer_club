using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Computer_club.Domain.Entities;
using Computer_club.Domain.Options;
using Computer_club.Domain.Options.Signing;
using Microsoft.IdentityModel.Tokens;

namespace Computer_club.Domain.Services.TokenService;

public class TokenGenerator : ITokenGenerator
{
    public string CreateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescription = new SecurityTokenDescriptor
        {
            Expires = DateTime.Now.AddMinutes(JwtOptions.LifeTime),
            Subject = GetIdentity(user),
            SigningCredentials = Audience.GetAudienceKey()
        };
        var token = tokenHandler.CreateToken(tokenDescription);
        return tokenHandler.WriteToken(token);
    }

    public string CreateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }

    private ClaimsIdentity GetIdentity(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }
}