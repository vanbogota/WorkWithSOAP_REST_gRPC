using System.Security.Cryptography;
using System.Text;

namespace ClinicService.Utils
{
    public static class PasswordUtils
    {
        private const string SecretKey = "MySecretCode";

        public static (string passwordSalt, string passwordHash) CreatePasswordHash(string password)
        {
            //generate random salt
            byte[] buffer = RandomNumberGenerator.GetBytes(16);             

            //create hash
            string passwordSalt = Convert.ToBase64String(buffer);
            string passwordHash = GetPasswordHash(password, passwordSalt);

            //done
            return(passwordSalt, passwordHash);
        }
        public static bool VerifyPassword(string password, 
            string passwordSalt, 
            string passwordHash)
        {
            return GetPasswordHash(password, passwordSalt) == passwordHash;
        }

        private static string GetPasswordHash(string password, string passwordSalt)
        {
            //built password string
            password = $"{password}~{passwordSalt}~{SecretKey}";
            byte[] buffer = Encoding.UTF8.GetBytes(password);

            //compute hash
            SHA512 sHA512 = SHA512.Create();
            byte[] passwordHash = sHA512.ComputeHash(buffer);

            //done
            return Convert.ToBase64String(passwordHash);
        }
    }
}
