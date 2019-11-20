using System;
using System.Security.Cryptography;
using System.Text;

namespace TestMusicAppServer.User.Domain.Helpers
{
    public static class PasswordHashProvider
    {
        public static string ComputeHash(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var bytes = Encoding.Unicode.GetBytes(password);
            var hashBytes = sha1.ComputeHash(bytes);
            var hashString = Convert.ToBase64String(hashBytes);

            return hashString;
        }
    }
}
