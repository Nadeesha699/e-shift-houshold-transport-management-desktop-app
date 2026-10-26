using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EShift.Helpers
{
    internal class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            const int iterations = 100000;
            byte[] salt = new byte[16];

            using (RNGCryptoServiceProvider rng =
                   new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            using (Rfc2898DeriveBytes pbkdf2 =
                   new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] hash = pbkdf2.GetBytes(32);

                return "PBKDF2$" + iterations + "$" +
                       Convert.ToBase64String(salt) + "$" +
                       Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            try
            {
                string[] parts = storedHash.Split('$');

                if (parts.Length != 4 || parts[0] != "PBKDF2")
                    return false;

                int iterations = int.Parse(parts[1]);
                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] expectedHash = Convert.FromBase64String(parts[3]);

                using (System.Security.Cryptography.Rfc2898DeriveBytes pbkdf2 =
                       new System.Security.Cryptography.Rfc2898DeriveBytes(
                           password, salt, iterations))
                {
                    byte[] actualHash = pbkdf2.GetBytes(expectedHash.Length);

                    if (actualHash.Length != expectedHash.Length)
                        return false;

                    int difference = 0;

                    for (int i = 0; i < actualHash.Length; i++)
                    {
                        difference |= actualHash[i] ^ expectedHash[i];
                    }

                    return difference == 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
