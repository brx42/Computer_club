using System.Security.Cryptography;
using System.Text;

namespace Computer_club.Domain.Security;

public static class Encryptor
{
    public static string Md5Hash(string text)
    {
        MD5 md5 = new MD5CryptoServiceProvider();

        md5.ComputeHash(Encoding.UTF8.GetBytes(text));
        return BitConverter.ToString(md5.Hash).Replace("-", "");
    }
}