using System.Security.Cryptography;
using System.Text;

public class PasswordDecryption
{
    public static string DecryptPassword(string encryptedPassword, string privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Importer la clé privée à partir de sa représentation XML
            rsa.FromXmlString(privateKey);

            // Convertir la chaîne Base64 du mot de passe chiffré en tableau de bytes
            byte[] encryptedBytes = Convert.FromBase64String(encryptedPassword);

            // Déchiffrer le mot de passe avec la clé privée RSA
            byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, true);

            // Convertir les bytes déchiffrés en une chaîne
            string decryptedPassword = Encoding.UTF8.GetString(decryptedBytes);

            // Retourner le mot de passe déchiffré
            return decryptedPassword;
        }
    }
}