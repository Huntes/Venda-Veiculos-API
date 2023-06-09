using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace VendaVeiculosAPI.Utils
{
    public static class Utils
    {
        public static string EncryptPassword(string password)
        {
            // Gerar um "salt" aleatório
            byte[] saltBytes = GenerateSalt();

            // Configurar os parâmetros do PBKDF2
            int iterations = 10000; // Número de iterações
            int hashSize = 32; // Tamanho do hash em bytes

            // Criar o derivador de chave PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, iterations))
            {
                // Gerar o hash da senha
                byte[] hashBytes = pbkdf2.GetBytes(hashSize);

                // Combinar o "salt" e o hash em um único array
                byte[] combinedBytes = new byte[saltBytes.Length + hashBytes.Length];
                Array.Copy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
                Array.Copy(hashBytes, 0, combinedBytes, saltBytes.Length, hashBytes.Length);

                // Retornar o resultado em formato Base64
                return Convert.ToBase64String(combinedBytes);
            }
        }

        public static bool VerifyPassword(string password, string storedPassword)
        {
            // Obter o "salt" e o hash da senha armazenada
            byte[] storedBytes = Convert.FromBase64String(storedPassword);
            byte[] saltBytes = new byte[16];
            byte[] hashBytes = new byte[32];

            Array.Copy(storedBytes, 0, saltBytes, 0, saltBytes.Length);
            Array.Copy(storedBytes, saltBytes.Length, hashBytes, 0, hashBytes.Length);

            // Configurar os parâmetros do PBKDF2
            int iterations = 10000; // Número de iterações
            int hashSize = 32; // Tamanho do hash em bytes

            // Criar o derivador de chave PBKDF2 com o "salt" armazenado
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, iterations))
            {
                // Gerar o hash da senha fornecida
                byte[] newHashBytes = pbkdf2.GetBytes(hashSize);

                // Comparar os hashes
                return CompareByteArrays(hashBytes, newHashBytes);
            }
        }

        private static byte[] GenerateSalt()
        {
            // Gerar um "salt" aleatório
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return saltBytes;
        }

        private static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            // Verificar se os arrays têm o mesmo tamanho
            if (array1.Length != array2.Length)
            {
                return false;
            }

            // Comparar cada byte dos arrays
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
