using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Abp.Authorization
{
   /// <summary>
   /// Md5密码验证
   /// </summary>
   public class Md532PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            byte[] b = Encoding.UTF8.GetBytes(password);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');

            return ret;
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return HashPassword(providedPassword).Equals(hashedPassword, StringComparison.CurrentCultureIgnoreCase)
                ? PasswordVerificationResult.Success
                : PasswordVerificationResult.Failed;
        }
    }
}
