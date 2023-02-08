using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Model
{
    internal class Encryption
    {
        public static string Encrypt(string str)
        {
            if (str == null) throw new ArgumentNullException("str");
            var data = Encoding.Unicode.GetBytes(str);
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);

            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string str)
        {
            if (str == null) throw new ArgumentNullException("str");

            //parse base64 string
            byte[] data = Convert.FromBase64String(str);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }

    }
}
