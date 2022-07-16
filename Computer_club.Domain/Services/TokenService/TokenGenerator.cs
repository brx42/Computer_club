﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Computer_club.Domain.Entities;
using Computer_club.Domain.Options;
using Microsoft.IdentityModel.Tokens;

namespace Computer_club.Domain.Services.TokenService;

public class TokenGenerator : ITokenGenerator
{
    public string CreateJwtToken(AppUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescription = new SecurityTokenDescriptor
        {
            Expires = DateTime.Now.AddMinutes(JWT.LifeTime),
            Issuer = JWT.Issuer,
            Audience = JWT.Audience,
            Subject = GetIdentity(user),
            SigningCredentials =
                new SigningCredentials(JWT.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescription);
        return tokenHandler.WriteToken(token);
    }

    public string CreateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }

    private ClaimsIdentity GetIdentity(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }
}