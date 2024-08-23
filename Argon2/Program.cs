using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Argon2;

public static class Argon2
{
    public static void Main()
    {
        const string password = "suaSenhaAqui";
        var salt = GenerateSalt();

        var hashedPassword = HashPassword(password, salt);
        Console.WriteLine($"Senha Hasheada: {hashedPassword}");

        var isValid = ValidatePassword("suaSenhaAqui", hashedPassword);
        Console.WriteLine($"Senha é válida: {isValid}");
    }
    
    // Gera um salt aleatório
    private static byte[] GenerateSalt(int length = 16)
    {
        var salt = new byte[length];
        RandomNumberGenerator.Fill(salt);
        return salt;
    }
    
    private static string HashPassword(string password, byte[] salt)
    {
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = 4,  // Número de threads proporcional ao número de núcleos da CPU
            MemorySize = 16384,       // 16 MB de memória, útil para aumentar a proteção contra ataques de análise
            Iterations = 6            // Número maior de iterações para aumentar a segurança
        };

        var hashBytes = argon2.GetBytes(16);  // Gera um hash de 16 bytes

        // Combina o salt e o hash como uma string base64
        var hash = Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(hashBytes);
        return hash;
    }

    private static bool ValidatePassword(string password, string hashedPassword)
    {
        var parts = hashedPassword.Split('|');
        var salt = Convert.FromBase64String(parts[0]);
        var hash = HashPassword(password, salt);

        return hash == hashedPassword;
    }
}