using System;
using System.Security.Cryptography;
using System.Text;

namespace CNM
{
    public class Encryptor
    {
        public string Encrypt(string valueToEncrypt)
        {
            string salt = "z0mg!";
            var encoding = new UnicodeEncoding();
            var hasher = SHA256Managed.Create();
            var bytes = hasher.ComputeHash(encoding.GetBytes(valueToEncrypt + salt));
            //return encoding.GetString(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
