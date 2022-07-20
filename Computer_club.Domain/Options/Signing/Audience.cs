using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Computer_club.Domain.Options.Signing;

public class Audience
{
    private static RSA _rsa;

    public static SigningCredentials GetAudienceKey()
    {
        _rsa = RSA.Create();
        string privateXmlKey = File.ReadAllText("./Keys/PrivateKey.xml");
        _rsa.FromXmlString(privateXmlKey);
        return new SigningCredentials(
            key: new RsaSecurityKey(_rsa),
            algorithm: SecurityAlgorithms.RsaSha256
            );
    }
}