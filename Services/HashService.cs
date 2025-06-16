using System;
using System.Security.Cryptography;
using System.Text;

namespace SecureQRFields.Services
{
    public static class HashService
    {
        public static string Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash); // Representación amigable
            }
        }
    }
}
