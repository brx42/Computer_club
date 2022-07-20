using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Computer_club.Domain.Options.Signing;

public class Issuer
{
    private static RSA _rsa;
    
    public static RsaSecurityKey GetIssuerKey()
    {
        _rsa = RSA.Create();
        string publicXmlKey = File.ReadAllText("./Keys/Private_Key.xml");
        _rsa.FromXmlString(publicXmlKey);
        return new RsaSecurityKey(_rsa);
    }
}