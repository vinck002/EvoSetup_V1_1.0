using Data.Helpers;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace EvoSetup_V_1._0
{
    public partial class FrmSpecialPermiByUserProfile : Form, IformControl, ICloneControl
    {
        int SearchinFlag = 0;
        int Flagstatus = 0;
        ControlShelper ControlHelper;
        DataSet Dep_Rol_Con_Sal_Data;
        DataSet UserprofileandTree;
        FindHelper _FindHelper;
        DataHelpers _DataHelpers;
        public List<MenuModel> _LoadMenu;
        public List<SpecialPermitRestriction> lst_SpecialPermitsRstrict;

        public DataTable DTUserProfile;
       public Int64 UserProfileId = 0;
        StringBuilder UserProfileProcedure  = new StringBuilder();
        StringBuilder UpdatePermitsByProfile;
        UserProfileModel _UserProfileModel;



        public FrmSpecialPermiByUserProfile()
        {
            ControlHelper = new ControlShelper();
            UpdatePermitsByProfile = new StringBuilder(" ");
            _FindHelper = new FindHelper();
            _DataHelpers = new DataHelpers();
            //_ProfilePermitList = new ProfilePermitListModel();
            InitializeComponent();
            SizeForm();

            //312, 664
            //1016, 664
            LoadMainData();
        }

        public void New()
        {
            SizeForm(1016, 664);
            chActive.Checked = true;
            Flagstatus = 2;

            //if (Flagstatus == 2)
            //{
            //    SizeForm();
            //    Flagstatus = 0;
            //    chActive.Checked = false;
            //}
            //else
            //{
            //    SizeForm(1016, 664);
            //    chActive.Checked = true;
            //    Flagstatus = 2;
            //}

            SearchinFlag = 0;
            UserProfileId = 0;
            LoadProfileData(0);
            chActive.Enabled = true;
            Mensaje("");
            btnClone.Enabled = false;
        }

        public void Save()
        {
            UpdatePermitsByProfile.Clear();
            UserProfileProcedure.Clear();
    
            int active = chActive.Checked ? 1 : 0;
            
            if (UserProfileId == 0)
            {
                if (txtDescription.Text == string.Empty)
                {
                    txtDescription.BackColor = Color.FromArgb(192, 255, 192);
                    return;
                }
                UserProfileProcedure.Append($"Exec sp_Evo_SaveUpdateUserProfile {UserProfileId}, '{txtDescription.Text}',{active}");

            }
            else
            {
                    if (_UserProfileModel.Description != txtDescription.Text || _UserProfileModel.Active != active)
                    {
                        if (txtDescription.Text != string.Empty)
                        {
                        DialogResult dialogResult = MessageBox.Show("The description has been modified, Do you want to continue?", "Updating Description", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                UserProfileProcedure.Append($"Exec sp_Evo_SaveUpdateUserProfile {_UserProfileModel.UserProfileId}, '{txtDescription.Text}',{active}");
                            }
                            else
                            {
                                return;
                            }
                       
                        }
                        else
                        {
                            UserProfileProcedure.Append($"Exec sp_Evo_SaveUpdateUserProfile {_UserProfileModel.UserProfileId},' {_UserProfileModel.Description}',{active}");
                        }
                    }
            }


            UserProfileId = _DataHelpers.UserProfile(UserProfileProcedure.ToString());

            //Recargar Userprofile
            DTUserProfile = _DataHelpers.GetTableUserProfile();
            DTUserProfile.PrimaryKey = new DataColumn[] { DTUserProfile.Columns["UserProfileID"] };


            ListSpecialPermitProfile();


            _DataHelpers.PermitsUserProfile(UpdatePermitsByProfile.ToString());
            
            DataRow UserProfileRow = DTUserProfile.Rows.Find(UserProfileId);
           
            _UserProfileModel = new UserProfileModel
            {
                UserProfileId = UserProfileId,
                Description = UserProfileRow["Description"].ToString(),
                Active = Convert.ToInt32(UserProfileRow["Active"])

            };
            
            dtgUserProfile.DataSource = DTUserProfile;

            MessageBox.Show("Done!");
            Flagstatus = 3;
            Mensaje(_UserProfileModel.Description);
            chActive.Enabled = true;
        }

        public void Search()
        {

            FindHelper FHelper = new FindHelper();
            SizeForm();
            txtDescription.Focus();
            chActive.Enabled = false;
            FHelper.CambiarColoresCampos(0, this, null);
            LoadDataTOInitial();
            SearchinFlag = 1;
            Flagstatus = 1;

            //if (SearchinFlag == 0)
            //{
            //    //SearchinFlag = 1;
            //    //Flagstatus = 1;
            //    //FHelper.CambiarColoresCampos(0, this, null);
               
                
            //}
            //else
            //{
               
            //    FHelper.CambiarColoresCampos(1, this, null);
            //    btnA.Text = "Ok";
            //    SearchinFlag = 0;
            //    Flagstatus = 0;
            //}
            
            //isediting = 0;
            Mensaje("");
        }

        void IformControl.Enter()
        {
            this.SelectNextControl(ActiveControl, true, true, true, true);
            if (this.btnA.Focused)
            {
                btnA.PerformClick();
            }
            
                      
        }


        #region Void Methods
        void CheckGrid(RadGridView grv, GridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {

                if (int.Parse(grv.CurrentRow.Cells["Checked"].Value.ToString()) == 1)
                {

                    grv.CurrentRow.Cells["Checked"].Value = false;
                }
                else
                {
                    grv.CurrentRow.Cells["Checked"].Value = true;
                }
            }
        }
        void LoadDataTOInitial()
        {
            dtgContracStatus.DataSource = null;
            dtgDepartment.DataSource = null;
            dtgRole.DataSource = null;
            dtgSpecialPMenu.DataSource = null;
            dgtSalesfloor.DataSource = null;

            dtgContracStatus.Rows.Clear();
            dtgDepartment.Rows.Clear();
            dtgRole.Rows.Clear();
            dtgSpecialPMenu.Rows.Clear();
            dgtSalesfloor.Rows.Clear();



        }
        void LoadMainData()
        {
            UserprofileandTree = _DataHelpers.FillUserProfileData();
            treeChargnode();
            LoadUserProfile();

        }
        void LoadUserProfile()
        {
            DTUserProfile = UserprofileandTree.Tables[1];
            DTUserProfile.PrimaryKey = new DataColumn[] { DTUserProfile.Columns["UserProfileID"] };
            dtgUserProfile.DataSource = DTUserProfile;
        }
        void RefreshProfile()
        {
            DTUserProfile = _DataHelpers.RefreshUserProfile();
            DTUserProfile.PrimaryKey = new DataColumn[] { DTUserProfile.Columns["UserProfileID"] };
            dtgUserProfile.DataSource = DTUserProfile;
        }

        void treeChargnode()
        {

            _LoadMenu = UserprofileandTree.Tables[0].AsEnumerable().Select(X => new MenuModel()
            {
                MenuItemId = X.Field<Int64>("MenuItemId"),
                Description = X.Field<string>("Description"),
                FormName = X.Field<string>("FormName"),
                ItemOrder1 = X.Field<int>("ItemOrder1"),
                ItemOrder2 = X.Field<int>("ItemOrder2"),
                ItemOrder3 = X.Field<int>("ItemOrder3"),
                Active = X.Field<int>("Active"),
                IconTag = X.Field<int>("IconTag"),
                UserID = X.Field<int>("UserID")
            }).ToList();

            var MenuFiltredItems = _LoadMenu
                      .ToList();

            MenuTree.Nodes.Clear();


            RadTreeNode node = new RadTreeNode(); ;
            RadTreeNode node2 = new RadTreeNode(); ;
            RadTreeNode node3;
            int iteminitial = 0;

            foreach (var item in MenuFiltredItems)
            {


                if (item.ItemOrder2 == 0 && item.ItemOrder3 == 0)
                {


                    if (iteminitial != item.ItemOrder1)
                    {
                        iteminitial = item.ItemOrder1;
                        MenuTree.Nodes.Add(node);

                    }

                    node = new RadTreeNode();
                    node.Text = item.Description;
                    node.Value = item.IconTag;
                }
                else if (item.ItemOrder2 > 0 && item.ItemOrder3 == 0)
                {
                    node2 = new RadTreeNode();
                    node2.Text = item.Description;
                    node2.Value = item.IconTag;
                    node.Nodes.Add(node2);
                }
                else if (item.ItemOrder2 > 0 && item.ItemOrder3 > 0)
                {
                    if (true)
                    {

                    }
                    node3 = new RadTreeNode();
                    node3.Text = item.Description;
                    node3.Value = item.IconTag;
                    node2.Nodes.Add(node3);
                }


            }
            MenuTree.Nodes.Add(node);

        }

      
       public void LoadProfileData(Int64 Id)
        {

            Dep_Rol_Con_Sal_Data = _DataHelpers.Get_Dep_Rol_Sal_Spe(Id);
            dgtSalesfloor.DataSource = Dep_Rol_Con_Sal_Data.Tables[2];
            dtgContracStatus.DataSource = Dep_Rol_Con_Sal_Data.Tables[3];
            dtgDepartment.DataSource = Dep_Rol_Con_Sal_Data.Tables[0];
            dtgRole.DataSource = Dep_Rol_Con_Sal_Data.Tables[1];

     
           lst_SpecialPermitsRstrict = Dep_Rol_Con_Sal_Data.Tables[4].AsEnumerable()
                .Select(x => new SpecialPermitRestriction()
                {
                    SpecialPermitiD = x.Field<Int64>("SpecialPermitiD"),
                    Description = x.Field<string>("Description"),
                    FormIconTag = x.Field<int>("FormIconTag"),
                    Checked = x.Field<int>("Checked")
                }).ToList();

       
        }

        void SizeForm(int w= 312, int h=664 )
        {
            //312, 664
            //1016, 664
            this.Size = new Size(w,h);

        }

        void Mensaje(string Descrip)
        {
            lblMensaje.Visible = false;
            lblMensaje.Text = "";



            if (Flagstatus == 1)
            {
                lblMensaje.Text = "Searching... ";
              
                lblMensaje.Visible = true;
                btnA.Text = "Ok";
            } else if (Flagstatus == 2)
            {

                lblMensaje.Text = "New User Profile";
                btnA.Text = "Save";
                lblMensaje.Visible = true;
            } else if (Flagstatus == 3)
            {
                lblMensaje.Text = $"Updating: {Descrip} ";
                btnA.Text = "Update";
                lblMensaje.Visible = true;
            }
            else
            {
                //lblMensaje.Text = "";
                btnA.Text = "Ok";
                lblMensaje.Visible = false;
            }


        }


        #endregion

        private void MenuTree_NodeMouseClick(object sender, RadTreeViewEventArgs e)
        {
            try
            {
                dtgSpecialPMenu.Rows.Clear();
                if (lst_SpecialPermitsRstrict != null)
                {
                    if (lst_SpecialPermitsRstrict.Count > 0)
                    {
                        int selectedTag = (int)e.Node.Value;

                        if (selectedTag > 1 && dtgUserProfile.CurrentRow.IsSelected)
                        {
                            dtgSpecialPMenu.Rows.Clear();

                            var lst = lst_SpecialPermitsRstrict.Where(x => x.FormIconTag == selectedTag).OrderBy(o => o.SpecialPermitiD).ToList();


                            dtgSpecialPMenu.DataSource = lst;

                        }

                    }
                    else
                    {
                        MessageBox.Show("Select a Profiles");
                    }
                }
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtFirtName_TextChanged(object sender, EventArgs e)
        {
            if (Flagstatus == 1)
            {
                if (txtDescription.Text == string.Empty)
                {
                    dtgUserProfile.DataSource = _FindHelper.dtgUserFilterFilter("", DTUserProfile, "Description");
                }
                else
                {
                    dtgUserProfile.DataSource = _FindHelper.dtgUserFilterFilter(txtDescription.Text, DTUserProfile, "Description");
                }

            }
            else
            {
                dtgUserProfile.DataSource = null;
                dtgUserProfile.Rows.Clear();
                dtgUserProfile.DataSource = DTUserProfile;
            }
          
        }

        void UserProfilePerformDoubleClick(Int64 Id = 0)
        {
            Int64 CurrentIdFormGrid = Convert.ToInt32(dtgUserProfile.CurrentRow.Cells["UserProfileID"].Value);
            

            _FindHelper.CambiarColoresCampos(1, this, null);
            UserProfileId = Id == 0 ? CurrentIdFormGrid : Id;
            LoadProfileData(UserProfileId);
            var UserProfileRow = DTUserProfile.Rows.Find(UserProfileId);
            chActive.Checked = Convert.ToBoolean(UserProfileRow["Active"]);
            chActive.Enabled = true;
            _UserProfileModel = new UserProfileModel { UserProfileId = UserProfileId, Description = UserProfileRow["Description"].ToString(), Active = Convert.ToInt32(UserProfileRow["Active"]) };
            Flagstatus = 3;
            Mensaje(UserProfileRow["Description"].ToString());
            txtDescription.Text = "";
           

        }

        private void dtgUserProfile_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            SearchinFlag = 0;
            UserProfilePerformDoubleClick();
            SizeForm(1016, 664);
            txtDescription.Text = string.Empty;
            dtgUserProfile.DataSource = _FindHelper.dtgUserFilterFilter("", DTUserProfile, "Description");
          
            txtDescription.BackColor = Color.White;
        }

        private void dtgSpecialPMenu_CellClick(object sender, GridViewCellEventArgs e)
        {

           
                if (dtgSpecialPMenu.RowCount > 0)
                {
                   

                  CheckGrid(dtgSpecialPMenu, e);

             
            }

        }

        private void MasterTemplate_CellClick(object sender, GridViewCellEventArgs e)
        {

            CheckGrid(dtgDepartment, e);
           
        }

        private void dtgRole_CellClick(object sender, GridViewCellEventArgs e)
        {


            CheckGrid(dtgRole, e);

        }

        private void dtgContracStatus_CellClick(object sender, GridViewCellEventArgs e)
        {
           
            CheckGrid(dtgContracStatus, e);
        }

        private void dgtSalesfloor_CellClick(object sender, GridViewCellEventArgs e)
        {

            CheckGrid(dgtSalesfloor, e);
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            if (Flagstatus > 1)
            {
                Save();
            }
            else if (Flagstatus == 1)
            {
                Search();
            }
     
            
        }

        private void dtgUserProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dtgUserProfile.Focused)
            {
                SearchinFlag = 0;
                UserProfilePerformDoubleClick();
                SizeForm(1016, 664);
            }
                     
        }

        private void DtgUserProfile_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgSpecialPMenu_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            int currentValue;
            int RowToChange;
          
          
                currentValue = Convert.ToInt32(e.Row.Cells["SpecialPermitID"].Value);
                RowToChange = lst_SpecialPermitsRstrict.FindIndex(x => x.SpecialPermitiD == currentValue);


                var lst = new SpecialPermitRestriction
                {
                    Checked = (int)e.Row.Cells["Checked"].Value,
                    Description = e.Row.Cells["Description"].Value.ToString(),
                    FormIconTag = int.Parse(e.Row.Cells["FormIconTag"].Value.ToString()),
                    SpecialPermitiD = int.Parse(e.Row.Cells["SpecialPermitiD"].Value.ToString())
                };
                lst_SpecialPermitsRstrict[RowToChange] = lst;
           

        }
        void ListSpecialPermitProfile()
        {
      
          
            foreach (var item in lst_SpecialPermitsRstrict)
            {
                UpdatePermitsByProfile.Append($"Exec sp_Evo_SpecialPermitRestrict {item.Checked}, {item.SpecialPermitiD}, {UserProfileId} ");
            }
            foreach (var item in dtgDepartment.Rows)
            {
                UpdatePermitsByProfile.Append($"Exec sp_Evo_DepartmentProfile {item.Cells["Checked"].Value}, {item.Cells["DepartmentID"].Value}, {UserProfileId} ");
            }
            foreach (var item in dtgRole.Rows)
            {
                UpdatePermitsByProfile.Append($"Exec sp_Evo_RoleProfile {item.Cells["Checked"].Value}, {item.Cells["Id"].Value}, {UserProfileId} ");
            }
            foreach (var item in dgtSalesfloor.Rows)
            {
                UpdatePermitsByProfile.Append($"Exec sp_Evo_SaleFloorProfile {item.Cells["Checked"].Value}, {item.Cells["Id"].Value}, {UserProfileId} ");
            }
            foreach (var item in dtgContracStatus.Rows)
            {
                UpdatePermitsByProfile.Append($"Exec sp_Evo_ContractStatusProfile {item.Cells["Checked"].Value}, {item.Cells["ContractStatusID"].Value}, {UserProfileId} ");
            }

        }
        private void btnClone_Click(object sender, EventArgs e)
        {
           ProfilePermitListModel _ProfilePermitListModel = new ProfilePermitListModel();
           
            foreach (var item in dtgDepartment.Rows)
            {

                _ProfilePermitListModel.DepartmentProfile.Add(new DepartmentProfile { DepartementId = Convert.ToInt64(item.Cells["DepartmentID"].Value), Checked = Convert.ToInt32(item.Cells["Checked"].Value) });
            }
            foreach (var item in dtgRole.Rows)
            {
                _ProfilePermitListModel.RoleProfile.Add(new RoleProfile { RoleID = Convert.ToInt32(item.Cells["Id"].Value), Checked = Convert.ToInt32(item.Cells["Checked"].Value) });
                
            }
            foreach (var item in dgtSalesfloor.Rows)
            {
                _ProfilePermitListModel.ProfileSaleFloor.Add(new ProfileSaleFloor { SaleFloorID = Convert.ToInt32(item.Cells["Id"].Value), Checked = Convert.ToInt32(item.Cells["Checked"].Value) });

            }
            foreach (var item in dtgContracStatus.Rows)
            {
                _ProfilePermitListModel.ContractStatusProfile.Add(new ContractStatusProfile { ContractStatusID = Convert.ToInt32(item.Cells["ContractStatusID"].Value), Checked = Convert.ToInt32(item.Cells["Checked"].Value) });

            }

            UpdatePermitsByProfile.Clear();
            UserProfileProcedure.Clear();
            int active = chActive.Checked ? 1 : 0;
            ListSpecialPermitProfile();
            frmCloneUserProfile UseProfileClone = new frmCloneUserProfile(lst_SpecialPermitsRstrict, _ProfilePermitListModel,this);
            UseProfileClone.ShowDialog();
        }

        private void FrmSpecialPermiByUserProfile_Resize(object sender, EventArgs e)
        {
            if (this.Size.Width < 315)
            {
                btnClone.Visible = false;
            }
            else
            {
                btnClone.Visible = true;
            }
        }

        public void Userprofile(long Id)
        {
            RefreshProfile();
            UserProfilePerformDoubleClick(Id);

        }

        private void FrmSpecialPermiByUserProfile_KeyDown(object sender, KeyEventArgs e)
        {
            ControlHelper.ControlKeys(sender, e, this);
        }
    }
}
