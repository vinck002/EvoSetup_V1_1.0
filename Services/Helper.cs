using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class Helper
    {

         string _connectionString;
        string EncryptDescrypt(string source, string key = "LSHVC_melvin_raul_felix_aldo")
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Encoding.UTF8.GetBytes(source);
                    return Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }
        }


       
       public string ConnectionString()
        {
           
                if (_connectionString == null)
                    _connectionString = EncryptDescrypt(ConfigurationManager.ConnectionStrings["cn"].ConnectionString, "real-soft-solutions");
                return _connectionString;
            
        }



    }
    
}
