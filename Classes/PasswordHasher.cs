#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
// Part: 2
#endregion

using System.Security.Cryptography;

namespace ST10023767_PROG.Classes
{
    /// <summary>
    /// This class provides functionality to hash and verify passwords using a secure algorithm.
    /// </summary>
    public class PasswordHasher
    {
        /// <summary>
        /// The size of the salt in bytes used for password hashing.
        /// </summary>
        public const int SaltSize = 16;

        /// <summary>
        /// The size of the hash in bytes produced by the password hashing process.
        /// </summary>
        public const int HashSize = 24;

        /// <summary>
        /// The number of iterations for the password hashing process. Higher values increase security.
        /// </summary>
        public const int Iterations = 10000;

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Hashes a password and generates a salt.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static (byte[] Salt, byte[] Hash) HashPassword(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[SaltSize];
                rng.GetBytes(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    var hash = pbkdf2.GetBytes(HashSize);
                    return (salt, hash);
                }
            }
        }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Verifies a password by comparing it with a stored hash and salt.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool VerifyPassword(string password, byte[] salt, byte[] hash)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] testHash = pbkdf2.GetBytes(HashSize);

                for (int i = 0; i < HashSize; i++)
                {
                    if (hash[i] != testHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        //・♫-------------------------------------------------------------------------------------------------♫・//
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
