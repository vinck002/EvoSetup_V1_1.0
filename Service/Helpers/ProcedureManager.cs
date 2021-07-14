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
         
        
       public static DataTable Departmentmanager(DepartmentModel model,int mod)
        {
            DataHelpers helper = new DataHelpers();
            DataTable dt = new DataTable();

              dt = helper.SqlData($"exec evo1_sp_DepartmentManager {model.DepartmentID},'{model.Description}',{model.Active},{mod}");
     
            return dt;
        }

        public static DataTable Rolesmanager(RoleModel model, int mod)
        {
            DataHelpers helper = new DataHelpers();
            DataTable dt = new DataTable();

            dt = helper.SqlData($"exec Evo_sp_RoleManager {model.Id},'{model.Code}','{model.Descri}',{model.GrpRoleId},{mod}");

            return dt;
        }
     
    }


    //Evo_sp_FillComboRole  Evo_sp_RoleManager
}
