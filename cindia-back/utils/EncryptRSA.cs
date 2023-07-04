using System.Security.Cryptography;


namespace cindia_back.utils;


public class EncryptRSA
{
    public static void Main(out string publicKey, out string privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            publicKey = rsa.ToXmlString(false); // Exporter la clé publique au format XML
            privateKey = rsa.ToXmlString(true); // Exporter la clé privée au format XML
        }
    }
}