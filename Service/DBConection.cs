using Data.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    
    public class DBConection
    {
        private string _DescryptString;
        private SqlConnection DbConection;

        public SqlConnection GetConection()
        {
            EncryptHelper strcon = new EncryptHelper();
            _DescryptString = strcon.Decrypt(ConfigurationManager.ConnectionStrings["MYSQL_Conection"].ConnectionString);
            DbConection = new SqlConnection(_DescryptString);

            return DbConection;
        }

        //public string DescriptConnectionString(string )
        //{
        //    Helper strcon = new Helper();
        
        //    if (_DescryptString == null)
        //        _DescryptString = strcon.Decrypt(ConfigurationManager.ConnectionStrings["MYSQL_Conection"].ConnectionString);
        //    return _DescryptString;

        //}
    }
   
}
