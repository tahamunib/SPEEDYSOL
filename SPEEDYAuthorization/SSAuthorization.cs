using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SPEEDYAuthorization
{
    public class SSAuthorization
    {
        public static string GetHash(string stringToHash)
        {
            using (SHA256 sha = SHA256.Create())
            {
                sha.Initialize();
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(stringToHash);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        public static bool IsOldPasswordMatch(string passwordHash,string oldPasswordString)
        {
            var hash = GetHash(oldPasswordString);
            if (hash.Equals(passwordHash))
                return true;
            else
                return false;
        }

        
    }
}
