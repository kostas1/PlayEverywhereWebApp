using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlayEv.WebUI.Infrastructure.Abstract;
using System.Security.Cryptography;
using System.Text;

namespace PlayEv.WebUI.Infrastructure.Concrete
{
    public class SHASecurePass:ISecurePass
    {
        private SHA256 sha = new SHA256CryptoServiceProvider();

        public string encriptPassword(string realPass)
        {
            byte[] b = sha.ComputeHash(Encoding.UTF8.GetBytes(realPass));
            StringBuilder sB = new StringBuilder();
            foreach (var a in b)
            {
                sB.Append(a);
            }
            return sB.ToString();
        }
    }
}