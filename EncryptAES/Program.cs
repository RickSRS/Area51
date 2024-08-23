using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptAES
{
    public static class EncryptAes
    {
        private const string Key = "Your16ByteKey123"; // Deve ter 16, 24 ou 32 caracteres

        private abstract class Program
        {
            private static void Main()
            {
                Console.Write("Enter text to encrypt: ");
                var plainText = Console.ReadLine();

                var encryptedText = plainText.EncryptString();
                Console.WriteLine($"Encrypted text: {encryptedText}");

                var decryptedText = encryptedText.DecryptString();
                Console.WriteLine($"Decrypted text: {decryptedText}");
            }
        }

        private static string EncryptString(this string plainText)
        {
            using var aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(Key);
            aesAlg.IV = new byte[16]; // Vetor de inicialização padrão (zeros)
            
            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using var swEncrypt = new StreamWriter(csEncrypt);
            swEncrypt.Write(plainText);
            swEncrypt.Close();
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        private static string DecryptString(this string cipherText)
        {
            using var aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(Key);
            aesAlg.IV = new byte[16]; // Vetor de inicialização padrão (zeros)
            
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
    }
}