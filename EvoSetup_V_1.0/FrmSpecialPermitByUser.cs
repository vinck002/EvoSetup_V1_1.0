using Data.Helpers;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace EvoSetup_V_1._0
{
    public partial class FrmSpecialPermitByUser : Form, IformControl
    {
        int SearchinFlag = 0;
        int Flagstatus = 0;
        //int isediting = 0;
        //int isNew = 0;
        //int saving = 0;
        ControlShelper ControlHelper;
        DataSet LoadUserDataAndTree;
        Int64 UserID = 0;
        List<UserModel> Users;
        DataHelpers _DataHelpers;
        StringBuilder UpdatePermitsByUser;
        public List<MenuModel> _LoadMenu;
        public List<SpecialPermitRestriction> lst_SpecialPermitsRstrict;
        public FrmSpecialPermitByUser()
        {
            ControlHelper = new ControlShelper();
            UpdatePermitsByUser = new StringBuilder(" ");
           
            _DataHelpers = new DataHelpers();
            InitializeComponent();
            //dtgSpecialPMenu.RootElement.AutoToolTip = true;
            LoadallData();
        }
        public FrmSpecialPermitByUser(Int64 IdUser)
            :this()
        {

            selectUserId(IdUser);
           
        }



        #region Void Methodts
        void Mensaje(string mensaje)
        {
            lblMensajes.Text = mensaje;
            lblMensajes.Visible = true;
        }

        void selectUserId(Int64 Id = 0)
        {
            dtgSpecialPMenu.DataSource = null;
            dtgSpecialPMenu.Rows.Clear();
            if (Id == 0)
            {
                UserID = Convert.ToInt32(cbUsers.SelectedValue);
            }
            else
            {
                UserID = Id;
            }
            string name = Users.Find(x => x.Id == Convert.ToInt32(UserID)).FirstName.ToString();
            Mensaje(name);
            LoadSpecialPermitByUser(UserID);
            MenuTree.Focus();
        }
        void LoadallData()
        {

            LoadUserDataAndTree = _DataHelpers.LoadUserDataAndTree();


            Users = LoadUserDataAndTree.Tables[1].AsEnumerable().Select(X => new UserModel() { Id = X.Field<int>("Id"), FirstName = X.Field<string>("Descripcion") }).ToList();
            Users.Insert(0, new UserModel {Id = 0, FirstName = ""});
            cbUsers.DataSource = Users;
            cbUsers.DisplayMember = "FirstName";
            cbUsers.ValueMember = "Id";
            cbUsers.AutoCompleteMode = AutoCompleteMode.Suggest;
            treeChargnode();
        }
        void treeChargnode()
        {

            _LoadMenu = LoadUserDataAndTree.Tables[0].AsEnumerable().Select(X => new MenuModel()
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
        void LoadSpecialPermitByUser(Int64 Id)
        {
            if (Id > 0 )
            {
                lst_SpecialPermitsRstrict = _DataHelpers.Get_SpecialPErmitUser(Id).AsEnumerable()
                 .Select(x => new SpecialPermitRestriction()
                 {
                     SpecialPermitiD = x.Field<Int64>("SpecialPermitiD"),
                     Description = x.Field<string>("Description"),
                     FormIconTag = x.Field<int>("FormIconTag"),
                     Checked = x.Field<int>("Checked"),
                     UserProfileStatus = x.Field<int>("UserProfile")
                 }).ToList();

            }




        }
        #endregion

        public void New()
        {
           
        }

        public void Save()
        {
            UpdatePermitsByUser.Clear();
            //sp_Evo_SpecialPermitByUser
            //UpdatePermitsByUser
            if (UserID > 0)
            {
                lst_SpecialPermitsRstrict.ForEach(delegate (SpecialPermitRestriction item)
                {
                    if (item.UserProfileStatus != 1)
                    {
                        UpdatePermitsByUser.Append($"Exec sp_Evo_SpecialPermitByUser {item.Checked}, {item.SpecialPermitiD}, {UserID} ");
                    }
                   
                });
                _DataHelpers.PermitsUserProfile(UpdatePermitsByUser.ToString());
                MessageBox.Show("Done!");
            }


            //btnA.Text = "Ok";
        }

        public void Search()
        {
           
        }

        void IformControl.Enter()
        {
            if (this.btnA.Focused)
            {
                btnA.PerformClick();
            }
            else
            {

                this.SelectNextControl(ActiveControl, true, true, true, true);

            }
        }

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

                        if (selectedTag > 1 && UserID > 0)
                        {
                            dtgSpecialPMenu.Rows.Clear();

                            var lst = lst_SpecialPermitsRstrict.Where(x => x.FormIconTag == selectedTag).OrderBy(o => o.SpecialPermitiD).ToList();

                            //DefaultCellStyle.BackColor = Color.Yellow;
                            dtgSpecialPMenu.DataSource = lst;

                            ConditionalFormattingObject obj = new ConditionalFormattingObject("UserProfileStatus", ConditionTypes.Contains, "1", "", true);
                            obj.RowBackColor = Color.SkyBlue;
                            this.dtgSpecialPMenu.Columns["UserProfileStatus"].ConditionalFormattingObjectList.Add(obj);
                           
                            
                            
                            
                            //foreach (var row in dtgSpecialPMenu.Rows)
                            //{
                            //    var este = row.Cells[4].Value.ToString();
                            //    if (row.Cells[4].Value.ToString() == "1")
                            //    {

                            //        //e.RowElement.DrawFill = true;
                            //        //e.RowElement.GradientStyle = GradientStyles.Solid;
                            //        //e.RowElement.BackColor = Color.Aqua;
                            //    }

                            //    //if (row.Cells["UserProfile"].Value == "1")
                            //    //{
                            //    //    row.
                            //    //}
                            //    //else
                            //    //{
                            //    //    row.DefaultCellStyle.BackColor = Color.Tomato;
                            //    //}
                            //}

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

        private void cbUsers_MouseClick(object sender, MouseEventArgs e)
        {
            
               
        }

        private void cbUsers_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dtgSpecialPMenu_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0 )
            {
                if (int.Parse(dtgSpecialPMenu.CurrentRow.Cells["UserProfileStatus"].Value.ToString()) != 1)
                {
                    if (int.Parse(dtgSpecialPMenu.CurrentRow.Cells["Checked"].Value.ToString()) == 1)
                    {

                        dtgSpecialPMenu.CurrentRow.Cells["Checked"].Value = false;
                    }
                    else
                    {
                        dtgSpecialPMenu.CurrentRow.Cells["Checked"].Value = true;
                    }
                }
                
            }
        }

        private void cbUsers_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void cbUsers_TextChanged(object sender, EventArgs e)
        {
            if (cbUsers.Text == string.Empty)
            {
                cbUsers.SelectedValue = 0;
            }
        }

        private void dtgSpecialPMenu_RowPaint(object sender, GridViewRowPaintEventArgs e)
        {
            //GridDataRowElement dataRow = e.Row as GridDataRowElement;
            //if (dataRow != null)
            //{
            //    int value = Convert.ToInt32(dataRow.RowInfo.Cells["Checked"].Value);
            //    if (value == 1)
            //    {
                    
            //        e.Row.BackColor = Color.Red;
            //            //DefaultCellStyle.BackColor = Color.Yellow;
            //    }
            //}
        }

        private void dtgSpecialPMenu_RowFormatting(object sender, RowFormattingEventArgs e)
        {

            //ConditionalFormattingObject obj = new ConditionalFormattingObject("UserProfileStatus", ConditionTypes.Contains, "1", "", true);
            //obj.RowBackColor = Color.SkyBlue;
            //this.dtgSpecialPMenu.Columns["UserProfileStatus"].ConditionalFormattingObjectList.Add(obj);

            //if (e.RowElement.RowInfo.Cells["UserProfileStatus"].Value.ToString() == "1")
            //{
            //    e.RowElement.DrawFill = true;
            //    e.RowElement.GradientStyle = GradientStyles.Solid;
            //    e.RowElement.BackColor = Color.Red;
            //}
            //else
            //{

            //}



        }

        private void cbUsers_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cbUsers.SelectedValue) > 0)
            //{
            //    selectUserId();
            //}
           

        }

        private void cbUsers_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            if (Convert.ToInt32(cbUsers.SelectedIndex) > 0)
            {
                selectUserId(0);
            }
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            if (btnA.Text == "Ok")
            {
                this.Close();
            }
            else
            {
                Save();
            }
            
            btnA.Text = "Ok";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgSpecialPMenu_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (btnA.Text == "Ok")
            {
                btnA.Text = "Save";
            }
          
           

            int currentValue;
            int RowToChange;
          
                if (Convert.ToInt32(e.Row.Cells["UserProfileStatus"].Value) != 1)
                {
                    currentValue = Convert.ToInt32(e.Row.Cells["SpecialPermitID"].Value);
                    RowToChange = lst_SpecialPermitsRstrict.FindIndex(x => x.SpecialPermitiD == currentValue);


                    var lst = new SpecialPermitRestriction
                    {
                        Checked = (int) e.Row.Cells["Checked"].Value,
                        Description = e.Row.Cells["Description"].Value.ToString(),
                        FormIconTag = int.Parse(e.Row.Cells["FormIconTag"].Value.ToString()),
                        SpecialPermitiD = int.Parse(e.Row.Cells["SpecialPermitiD"].Value.ToString())
                    };
                    lst_SpecialPermitsRstrict[RowToChange] = lst;
                }
              
              
            

           
    
        }

        private void dtgSpecialPMenu_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Row.Index< 0)
            {
                return;
            }
           
          
            if ((int)e.Row.Cells[4].Value > 0)
            {
                e.CellElement.ToolTipText = "Not Editable ";
            }
            else
            {
                e.CellElement.ToolTipText = null;
            }
        }

        private void FrmSpecialPermitByUser_KeyDown(object sender, KeyEventArgs e)
        {
            ControlHelper.ControlKeys(sender, e, this);
        }
    }
}
