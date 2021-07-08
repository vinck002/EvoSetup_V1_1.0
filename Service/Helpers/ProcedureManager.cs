using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data.Helpers
{
   public class ProcedureManager
    {
         
        
       public static DataTable proceduremanager(DepartmentModel depart,int mod)
        {
            DataHelpers helper = new DataHelpers();
            DataTable dt = new DataTable();

              dt = helper.SqlData($"evo1_sp_DepartmentManager {depart.DepartmentID},'{depart.Description}',{depart.Active},{mod}");
     
            return dt;
        }

    }
}
