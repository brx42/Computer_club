using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace ComputerClub.Domain.Options;

public class RsaKeys
{
    public string PublicPath { get; set; }
    public string PrivatePath { get; set; }
    

    public async Task<RsaSecurityKey> GetPublicKey()
    {
        RSA rsa = new RSACryptoServiceProvider(2048);

        string publicPrivateKeyXML = rsa.ToXmlString(true);
        string publicOnlyKeyXML = rsa.ToXmlString(false);

        RsaSecurityKey securityKey = new RsaSecurityKey(rsa);
        return securityKey;

        // RSA? rsa = RSA.Create();
        // string? file = await File.ReadAllTextAsync(PublicPath);
        // rsa.ImportRSAPublicKey(
        //     source: Convert.FromBase64String(file),
        //     bytesRead: out int _);
        // return new RsaSecurityKey(rsa);
    }

    public async Task<SigningCredentials> GetPrivateKey()
    {
        RSA rsa = RSA.Create();
        string file = await File.ReadAllTextAsync(PrivatePath);
        rsa.ImportPkcs8PrivateKey(
            source: Convert.FromBase64String(file),
            bytesRead: out int _);
        SigningCredentials signingCredentials = new SigningCredentials(
            key: new RsaSecurityKey(rsa),
            algorithm: SecurityAlgorithms.RsaSha256);
        return signingCredentials;
    }
}