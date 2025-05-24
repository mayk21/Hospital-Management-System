using System.Security.Cryptography;
using System.Text;

namespace HMS
{
    public class SecureData
    {
        public static string HashString(string PasswordString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(PasswordString))
                sb.Append(b.ToString("X3"));
            return sb.ToString();

            //     MD5 md5 = new MD5CryptoServiceProvider();
            //     byte[] passwordhash = Encoding.UTF8.GetBytes(PasswordString);   
            //     return Encoding.UTF8.GetString(md5.ComputeHash(passwordhash));

        }

        public static byte[] GetHash(string passwordString)
        {
            using (HashAlgorithm algo = SHA256.Create())
                return algo.ComputeHash(Encoding.UTF8.GetBytes(passwordString));

        }
    }
}
