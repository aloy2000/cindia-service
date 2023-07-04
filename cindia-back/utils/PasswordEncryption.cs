using System.Security.Cryptography;
using System.Text;

public class PasswordEncryption
{
    public static string EncryptPassword(string password, string publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Importer la clé publique à partir de sa représentation XML
            rsa.FromXmlString(publicKey);

            // Convertir le mot de passe en tableau de bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Chiffrer le mot de passe avec la clé publique RSA
            byte[] encryptedBytes = rsa.Encrypt(passwordBytes, true);

            // Convertir le résultat chiffré en une chaîne Base64
            string encryptedPassword = Convert.ToBase64String(encryptedBytes);

            // Retourner le mot de passe chiffré
            return encryptedPassword;
        }
    }
}