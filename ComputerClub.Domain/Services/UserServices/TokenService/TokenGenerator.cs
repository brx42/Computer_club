using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ComputerClub.Domain.Services.UserServices.TokenService;

public class TokenGenerator : ITokenGenerator
{
    private readonly JwtOptions _jwtOptions;
    private readonly RsaKeys _keys;
    public TokenGenerator(IOptions<JwtOptions> jwtOptions, IOptions<RsaKeys> keys)
    {
        _keys = keys.Value;
        _jwtOptions = jwtOptions.Value;
    }
    public async Task<string> CreateJwtToken(User user)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityTokenDescriptor tokenDescription = new SecurityTokenDescriptor
        {
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
            Expires = DateTime.Now.AddMinutes(_jwtOptions.LifeTime),
            Subject = GetIdentity(user),
            SigningCredentials = await _keys.GetPrivateKey(),
        };
        SecurityToken? token = tokenHandler.CreateToken(tokenDescription);
        return tokenHandler.WriteToken(token);
    }

    public string CreateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }

    private ClaimsIdentity GetIdentity(User user)
    {
        List<Claim> claims = new List<Claim>(11)
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, Role.SuperAdmin),
            new Claim(ClaimTypes.Role, Role.Manager),
            new Claim(ClaimTypes.Role, Role.Support),
            new Claim(ClaimTypes.Role, Role.Client),
            new Claim(ClaimTypes.Role, Role.ClubAdmin),
            new Claim(ClaimTypes.Role, Role.SiteAdmin),
            new Claim(ClaimTypes.Role, Role.Analyst),
            new Claim(ClaimTypes.Role, Role.Auditor)
        };

        ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }
}