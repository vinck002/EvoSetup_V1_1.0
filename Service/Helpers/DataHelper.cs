using Data.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Data.Helpers
{
    public class DataHelpers
    {
        private DBConection _ConectionInstance;
        public DataHelpers()
        {
            _ConectionInstance = new DBConection();

        }
        public bool Verificaconect()
        {

            using (var cnn = _ConectionInstance.GetConection())
            {
                try
                {
                    cnn.Open();
                    cnn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }

            }

        }

        #region Users


        public DataSet FillCombosUsers()
        {
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            using (var cnn = _ConectionInstance.GetConection())
            {
                cnn.Open();
                string SPPendientes = "sp_Evo_SelectFillCombosUsers";
                SqlCommand cmd = new SqlCommand(SPPendientes, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@User", 1);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(ds);
                return ds;

            }

        }

        public bool SAVEUsers(UserModel USer)
        {
            bool succed = true;
            try
            {
                using (var cnn = _ConectionInstance.GetConection())
                {

                    cnn.Open();
                    string SPPendientes = "sp_Evo_Users_CREATE_UPDATE";
                    SqlCommand cmd = new SqlCommand(SPPendientes, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", USer.Id);
                    cmd.Parameters.AddWithValue("@Code", USer.Code);
                    cmd.Parameters.AddWithValue("@FirstName", USer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", USer.LastName);
                    cmd.Parameters.AddWithValue("@Password", USer.Password);
                    cmd.Parameters.AddWithValue("@Type", USer.Types);
                    cmd.Parameters.AddWithValue("@Address", USer.Address);
                    cmd.Parameters.AddWithValue("@city", USer.city);
                    cmd.Parameters.AddWithValue("@countryid", USer.countryid);
                    cmd.Parameters.AddWithValue("@zipcode", USer.zipcode);
                    cmd.Parameters.AddWithValue("@phone1", USer.phone1);
                    cmd.Parameters.AddWithValue("@phone2", USer.phone2);
                    cmd.Parameters.AddWithValue("@email", USer.email);
                    cmd.Parameters.AddWithValue("@UserProfileId", USer.UserProfileId);
                    cmd.Parameters.AddWithValue("@DepartmentId", USer.DepartmentId);
                    cmd.Parameters.AddWithValue("@SalesFloorId", USer.SalesFloorId);


                    cmd.ExecuteNonQuery();
                    cnn.Close();


                }
            }
            catch (Exception ex)
            {
                //ex.Message.Contains("Violation of UNIQUE KEY");
                if (ex.Message.Contains("Violation of UNIQUE KEY"))
                {
                    succed = false;
                }

                //throw;
            }

            return succed;
        }


        public DataTable SearchUsers(UserModel USer)
        {
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            using (var cnn = _ConectionInstance.GetConection())
            {

                cnn.Open();
                string SPPendientes = "Sp_Evo_SearchinUser";
                SqlCommand cmd = new SqlCommand(SPPendientes, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Code", USer.Code);
                cmd.Parameters.AddWithValue("@FirstName", USer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", USer.LastName);
                cmd.Parameters.AddWithValue("@Type", USer.Types);
                cmd.Parameters.AddWithValue("@Address", USer.Address);
                cmd.Parameters.AddWithValue("@city", USer.city);
                cmd.Parameters.AddWithValue("@country", USer.country);
                cmd.Parameters.AddWithValue("@zipcode", USer.zipcode);
                cmd.Parameters.AddWithValue("@phone1", USer.phone1);
                cmd.Parameters.AddWithValue("@phone2", USer.phone2);
                cmd.Parameters.AddWithValue("@email", USer.email);
                cmd.Parameters.AddWithValue("@UserProfile", USer.UserProfile);
                cmd.Parameters.AddWithValue("@Department", USer.Department);
                cmd.Parameters.AddWithValue("@SalesFloor", USer.SalesFloor);


                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(dt);
                return dt;

            }

        }
        #endregion

        #region Department

        public DataTable SqlData(string  SQL)
        {
            DataTable DT = new DataTable();
            using (var Cnn = _ConectionInstance.GetConection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL, Cnn);
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    Cnn.Open();
                    DA.Fill(DT);
                    Cnn.Close();
                }
                catch (/*SqlException ex*/ Exception)
                {
                   
                    //System.Windows.Forms.MessageBox.Show(ex.Message, "EVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DT.Columns.Add("result");
                    DT.Rows.Add("0");
                }
               

                return DT;
            }
        }
        public DataTable SearchDepartment(String Department)
        {
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            using (var cnn = _ConectionInstance.GetConection())
            {

                cnn.Open();
                string SPPendientes = "Sp_Evo_SearchinDepartment";
                SqlCommand cmd = new SqlCommand(SPPendientes, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Description", Department);
             

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(dt);
                return dt;

            }
         
        }
        public bool DepartmentManagment(DepartmentModel department)
        {
            bool result = true; 
            try
            {
                using (var cnn = _ConectionInstance.GetConection())
                {
                    cnn.Open();
                    SqlCommand command = new SqlCommand("sp_DepartmentManager", cnn);
                    command.Parameters.AddWithValue("@Id", department.DepartmentID);
                    command.Parameters.AddWithValue("@Description", department.Description);
                    command.Parameters.AddWithValue("@Active", department.Active);

                    command.CommandType = CommandType.StoredProcedure;


                    command.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        #endregion


        #region Roles

        public DataTable FillCombosRole()
        {
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();

            using (var cnn = _ConectionInstance.GetConection())
            {
                cnn.Open();
                string SPPendientes = "sp_Evo_FillComboRole";
                SqlCommand cmd = new SqlCommand(SPPendientes, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@User", 1);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(dt);
                return dt;

            }

        }
        public DataTable SearchRoles(RoleModel role)
        {
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            using (var cnn = _ConectionInstance.GetConection())
            {

                cnn.Open();
                string SPPendientes = "Sp_Evo_SearchinRoles";
                SqlCommand cmd = new SqlCommand(SPPendientes, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Code", role.Code);
                cmd.Parameters.AddWithValue("@Description", role.Descri);
                cmd.Parameters.AddWithValue("@GrpRole", role.GrpRole);
                
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(dt);
                return dt;

            }

        }
        public bool RolesManagment(RoleModel role)
        {
            bool result = true; ;
            try
            {
                using (var cnn = _ConectionInstance.GetConection())
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Evo_RoleSaving", cnn);
                    cmd.Parameters.AddWithValue("@Id", role.Id);
                    cmd.Parameters.AddWithValue("@Code", role.Code);
                    cmd.Parameters.AddWithValue("@Description", role.Descri);
                    cmd.Parameters.AddWithValue("@GrpRoleId", role.GrpRoleId);

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                //ex.Message.Contains("Violation of UNIQUE KEY");
                if (ex.Message.Contains("Violation of UNIQUE KEY"))
                {
                    result = false;
                }

                //throw;
            }
            return result;
        }
        #endregion

        #region MenuItem
        
            public bool MenuItemsManagment(MenuModel menu)
        {
            bool result = true; 
            try
            {
                using (var cnn = _ConectionInstance.GetConection())
                {
                    cnn.Open();
                    SqlCommand command = new SqlCommand("sp_MenuItemManager", cnn);
                    command.Parameters.AddWithValue("@MenuItemID", menu.MenuItemId);
                    command.Parameters.AddWithValue("@Description", menu.Description);
                    command.Parameters.AddWithValue("@FormName", menu.FormName);
                    command.Parameters.AddWithValue("@ItemOrder1", menu.ItemOrder1);
                    command.Parameters.AddWithValue("@ItemOrder2", menu.ItemOrder2);
                    command.Parameters.AddWithValue("@ItemOrder3", menu.ItemOrder3);
                    command.Parameters.AddWithValue("@Active", menu.Active);
                    command.Parameters.AddWithValue("@IconTag", menu.IconTag);
                 

                    command.CommandType = CommandType.StoredProcedure;


                    command.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch (Exception)
            {
                throw;
                result = false;
            }
            return result;
        }
        public DataTable SearchingMenuItem(string Description,int SelectedItemOrder = 0, int ItemOrder1 =0, int ItemOrder2 = 0)
        {
            //DataTable dt = new DataTable();
            DataTable dt = new DataTable();

            using (var cnn = _ConectionInstance.GetConection())
            {
                cnn.Open();
                string SP = "sp_Evo_SearchingMenuItem";
                SqlCommand cmd = new SqlCommand(SP, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@SelectedItemOrder", SelectedItemOrder);
                cmd.Parameters.AddWithValue("@ItemOrder1", ItemOrder1);
                cmd.Parameters.AddWithValue("@ItemOrder2", ItemOrder2);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(dt);
                return dt;

            }

        }
        public DataTable FillComboMenu()
        {
            //DataTable dt = new DataTable();
            DataTable dt = new DataTable();

            using (var cnn = _ConectionInstance.GetConection())
            {
                cnn.Open();
                string SP = "sp_Evo_MenuItemSelect";
                SqlCommand cmd = new SqlCommand(SP, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@User", 1);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(dt);
                return dt;

            }

        }
        public DataSet FillUserProfileData()
        {
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            using (var cnn = _ConectionInstance.GetConection())
            {
                cnn.Open();
                string SP = "sp_Evo_MenuItemSelect";
                SqlCommand cmd = new SqlCommand(SP, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@User", 1);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(ds);
                return ds;

            }

        }
        public DataTable RefreshUserProfile()
        {
            //DataTable dt = new DataTable();
            DataTable dt = new DataTable();

            using (var cnn = _ConectionInstance.GetConection())
            {
                cnn.Open();
                string SP = "sp_Evo_RefreshUserProfile";
                SqlCommand cmd = new SqlCommand(SP, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@User", 1);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(dt);
                return dt;

            }

        }
        public DataSet LoadUserDataAndTree()
        {
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            using (var cnn = _ConectionInstance.GetConection())
            {
                cnn.Open();
                string SP = "sp_Evo_LoadUserDataAndTree";
                SqlCommand cmd = new SqlCommand(SP, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@User", 1);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(ds);
                return ds;

            }

        }

        public DataTable FillMenuSpecialPermit(int ID)
        {
            //DataTable dt = new DataTable();
            DataTable dt = new DataTable();

            using (var cnn = _ConectionInstance.GetConection())
            {
                cnn.Open();
                string SP = "sp_Evo_MenuSpecialPermit";
                SqlCommand cmd = new SqlCommand(SP, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MenuItemID", ID);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(dt);
                return dt;

            }

        }


        #endregion

        #region SpecialPermit
        public void SaveSpecialPermit(DataTable dt)
        {
            try
            {

                using (var cnn = _ConectionInstance.GetConection())
                {
              
                    SqlCommand command = new SqlCommand("sp_SpecialPermitManager", cnn);
                    //var parametroLista = new SqlParameter("@SpecialPermitTable", SqlDbType.Structured);
                    command.Parameters.AddWithValue("@SpecialPermitTable", dt);
                    //parametroLista.TypeName = "dbo.SpecialPermitTable1";
                    //parametroLista.Value = dt;

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    //command.Parameters.Add(parametroLista);
                    //command.Parameters.AddWithValue("@UserProfileID", UserProfileID);

                    cnn.Open();
                    command.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }




        }
        #endregion

        #region Special Permit Profile

       

        public Int64 UserProfile(string UserProfile)
        {
            Int64 id = 0;
            try
            {
              
                DataTable dt = new DataTable();
                using (var cnn = _ConectionInstance.GetConection())
                {

                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(UserProfile, cnn);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);

                    Da.Fill(dt);

                    id = Convert.ToInt64(dt.Rows[0][0]);

                }
               
            }
            catch (Exception)
            {
                throw;
                id = -1;

            }
            return id;
        }

        public void PermitsUserProfile(string ProfilesPermits)
        {
        
            try
            {

             
                using (var cnn = _ConectionInstance.GetConection())
                {

                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(ProfilesPermits, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                }

            }
            catch (Exception)
            {
              

            }
         
        }

        public DataTable GetTableUserProfile()
        {
            //DataTable dt = new DataTable();
            DataTable dt = new DataTable();

            using (var cnn = _ConectionInstance.GetConection())
            {
                cnn.Open();
                string SPPendientes = "sp_Evo_GetTableUserProfile";
                SqlCommand cmd = new SqlCommand(SPPendientes, cnn);
                //cmd.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(dt);
                return dt;

            }

        }
        public DataTable Get_SpecialPErmitUser(Int64 UserID)
        {
            //DataTable dt = new DataTable();
            DataTable dt = new DataTable();

            using (var cnn = _ConectionInstance.GetConection())
            {
                cnn.Open();
                string SPPendientes = "sp_Evo_GetSpecialPErmitUser";
                SqlCommand cmd = new SqlCommand(SPPendientes, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User", UserID);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(dt);
                return dt;

            }
        }

            public DataSet Get_Dep_Rol_Sal_Spe(Int64 UserProfile)
        {
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            using (var cnn = _ConectionInstance.GetConection())
            {
                cnn.Open();
                string SPPendientes = "SP_Get_Dep_Rol_Sal_Cont";
                SqlCommand cmd = new SqlCommand(SPPendientes, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserProfile", UserProfile);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(ds);
                return ds;

            }

        }


        //public DataSet Get_Dep_Rol_Sal_Spe(Int64 UserProfile)
        //{
        //    //DataTable dt = new DataTable();
        //    DataSet ds = new DataSet();

        //    using (var cnn = _ConectionInstance.GetConection())
        //    {
        //        cnn.Open();
        //        string SPPendientes = "SP_Get_DepArtment_Rol_Sales_Pertmit_";
        //        SqlCommand cmd = new SqlCommand(SPPendientes, cnn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@UserProfileID", UserProfile);

        //        SqlDataAdapter DA = new SqlDataAdapter(cmd);
        //        DA.Fill(ds);
        //        return ds;

        //    }

        //}
        #endregion
    }
}
