using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Computer_club.Domain.Options;

public class RsaKeys
{
    public string PublicPath { get; set; }
    public string PrivatePath { get; set; }
    

    public async Task<RsaSecurityKey> GetPublicKey()
    {
        var rsa = RSA.Create();
        var file = await File.ReadAllTextAsync(PublicPath);
        rsa.ImportRSAPublicKey(
            source: Convert.FromBase64String(file),
            bytesRead: out int _);
        return new RsaSecurityKey(rsa);
    }

    public async Task<SigningCredentials> GetPrivateKey()
    {
        var rsa = RSA.Create();
        var file = await File.ReadAllTextAsync(PrivatePath);
        rsa.ImportPkcs8PrivateKey(
            source: Convert.FromBase64String(file),
            bytesRead: out int _);
        var signingCredentials = new SigningCredentials(
            key: new RsaSecurityKey(rsa),
            algorithm: SecurityAlgorithms.RsaSha256);
        return signingCredentials;
    }
}