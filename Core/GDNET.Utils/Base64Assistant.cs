using System;
using System.Text;

namespace GDNET.Utils
{
    public sealed class Base64Assistant
    {
        public static string Encrypt(string source)
        {
            if (source == null)
            {
                return null;
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(source));
        }

        public static string Decrypt(string base64)
        {
            if (base64 == null)
            {
                return null;
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
    }
}
