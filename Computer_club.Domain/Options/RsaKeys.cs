using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Computer_club.Domain.Options;

public class RsaKeys
{
    private readonly RSA _rsa;
    private readonly IConfiguration _configuration;

    public RsaKeys(IConfiguration configuration)
    {
        _configuration = configuration;
        _rsa = RSA.Create();
    }

    public RsaSecurityKey GetPublicKey()
    {
        _rsa.ImportRSAPublicKey(
            source: Convert.FromBase64String(_configuration["JwtOptions:Key:Public"]),
            bytesRead: out int _);
        return new RsaSecurityKey(_rsa);
    }

    public SigningCredentials GetPrivateKey()
    {
        _rsa.ImportRSAPrivateKey(
            source: Convert.FromBase64String(_configuration["JwtOptions:Key:Private"]),
            bytesRead: out int _);
        var signingCredentials = new SigningCredentials(
            key: new RsaSecurityKey(_rsa),
            algorithm: SecurityAlgorithms.RsaSha256);
        return signingCredentials;
    }
}