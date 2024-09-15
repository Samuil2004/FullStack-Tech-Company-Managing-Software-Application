using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Manages password-related operations, including hashing and salt generation.
    /// </summary>
    public class PasswordManager
    {
        public PasswordManager() { }

        /// <summary>
        /// Generates a SHA256 hash of the given password combined with the provided salt.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt to add to the password for hashing.</param>
        /// <returns>A base64 string representing the hashed password.</returns>
        public string GenerateSHA256Hash(string password, string salt)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);

            byte[] saltedInputBytes = new byte[saltBytes.Length + inputBytes.Length];
            Buffer.BlockCopy(saltBytes, 0, saltedInputBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(inputBytes, 0, saltedInputBytes, saltBytes.Length, inputBytes.Length);

            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(saltedInputBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }


        /// <summary>
        /// Generates a random salt string of the specified length.
        /// </summary>
        /// <param name="length">The length of the salt string to generate.</param>
        /// <returns>A randomly generated salt string.</returns>
        public string GenerateRandomSalt(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+";

            StringBuilder password = new StringBuilder();

            Random random = new Random();

            while (0 < length--)
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }

            return password.ToString();
        }

    }
}
