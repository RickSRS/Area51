namespace HasherBCrypt
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Digite a senha a ser hasheada:");
            var password = Console.ReadLine();

            // Gera o hash da senha
            var hash = BCryptHasher.HashPassword(password);

            // Exibe o hash gerado
            Console.WriteLine($"Hash gerado: {hash}\n");

            Console.WriteLine("Digite a senha novamente para validação:");
            var passwordToValidate = Console.ReadLine();

            // Valida a senha
            var isValid = BCryptHasher.ValidatePassword(passwordToValidate, hash);

            // Exibe o resultado da validação
            Console.WriteLine($"Senha válida: {isValid}");
        }
    }

    public static class BCryptHasher
    {
        /// <summary>
        /// Gera um hash para a senha fornecida.
        /// </summary>
        /// <param name="password">A senha a ser hashed.</param>
        /// <returns>O hash gerado.</returns>
        public static string HashPassword(string? password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Valida uma senha fornecida em comparação com um hash armazenado.
        /// </summary>
        /// <param name="password">A senha fornecida para validação.</param>
        /// <param name="hash">O hash armazenado.</param>
        /// <returns>True se a senha for válida, caso contrário, false.</returns>
        public static bool ValidatePassword(string? password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}