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
using Telerik.WinControls.UI;

namespace EvoSetup_V_1._0
{
    public partial class FrmSpecialPermit : Form, IformControl, ISpecialPermit
    {
        int SearchinFlag = 0;
        int Flagstatus = 0;

        List<MenuModel> FillSuMenu;
       //List<SpecialPermitModel> _SpecialPermitModel;
        DataHelpers DataHelpers;
        DataTable ComboBoxDataResult;
        DataTable DataResult;
        List<MenuModel> MenuList;
        //List<MenuModel> SearchingMenuList;

        public FrmSpecialPermit()
        {
            DataHelpers = new DataHelpers();
            InitializeComponent();
            fillComboMenu();

          cbFormOption.AutoCompleteMode = AutoCompleteMode.Suggest;

        }

        #region Void Methods
       
        void Searching()
        {
            FindHelper FHelper = new FindHelper();
            cbFormOption.Focus();
            cbFormOption.SelectedIndex = 0;


            if (SearchinFlag == 0)
            {
                SearchinFlag = 1;
                Flagstatus = 1;
                FHelper.CambiarColoresCampos(0, this, null);

            }
            else
            {

                FHelper.CambiarColoresCampos(1, this, null);
                btnA.Text = "Ok";
                SearchinFlag = 0;
                dtgSpecialPermit.DataSource = null;
                dtgSpecialPermit.Rows.Clear();
                Flagstatus = 0;
            }

            
            Mensaje("");

          

        }
       

        void fillComboMenu()
        {
            ComboBoxDataResult = DataHelpers.FillComboMenu();
            MenuList = ComboBoxDataResult.AsEnumerable().Select(x => new MenuModel()
            {
                MenuItemId = x.Field<Int64>("MenuItemID"),
                Description = x.Field<string>("Description"),
                FormName = x.Field<string>("FormName"),
                ItemOrder1 = x.Field<int>("ItemOrder1"),
                ItemOrder2 = x.Field<int>("ItemOrder2"),
                ItemOrder3 = x.Field<int>("ItemOrder3"),
                Active = x.Field<int>("Active"),
                IconTag = x.Field<int>("IconTag"),
                UserID = x.Field<int>("UserID")

            }).ToList();
            FillCBGrpOption(1);
        }


        void FillCBGrpOption(int grpMenu)
        {

            if (grpMenu == 1)
            {
                FillSuMenu = MenuList.Where(x => x.ItemOrder3 > 0 && x.ItemOrder2 > 0 )
                                       .ToList();


                if (FillSuMenu.Count > 0)
                {
                    FillSuMenu.Insert(0, new MenuModel { ItemOrder3 = 0, Description = "" });

                    //cbFormOption.BindingContext = new BindingContext();
                    cbFormOption.DataSource = FillSuMenu;
                    cbFormOption.DisplayMember = "Description";
                    cbFormOption.ValueMember = "MenuItemID";
            
                }
            }
           
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
            }
            else if (Flagstatus == 2)
            {

                lblMensaje.Text = "New User Profile";
                btnA.Text = "Save";
                lblMensaje.Visible = true;
            }
            else if (Flagstatus == 3)
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
        //void Mensaje()
        //{
        //    lblMensaje.Visible = false;
        //    lblMensaje.Text = "";



        //    if (isediting == 1)
        //    {
        //        lblMensaje.Text = "Editing...";
               
        //        lblMensaje.Visible = true;
        //    }
        //    else
        //    {
        //        lblMensaje.Text = "";
        //        lblMensaje.Visible = false;
        //    }
        //    if (isNew == 1)
        //    {
        //        lblMensaje.Text = "Creating...";

        //        lblMensaje.Visible = true;
        //    }
        //    else
        //    {
        //        lblMensaje.Text = "";
        //        lblMensaje.Visible = false;
        //    }




        //    if (SearchinFlag == 1)
        //    {
        //        lblMensaje.Text = "Searching...";
        //        lblMensaje.Visible = true;
        //    }
        //    else
        //    {
        //        //lblMensaje.Text = "";
        //        lblMensaje.Visible = false;
        //    }


        //}



        

        #endregion
        #region bool methods
        //void AddAction()
        //{
        //    FindHelper FHelper = new FindHelper();

        //    SearchinFlag = 0;
        //    cbFormOption.Focus();
        //    if (isNew == 0)
        //    {

        //        isNew = 1;
        //        isediting = 0;
        //        btnA.Text = "Save";
        //        saving = 2;
        //        FHelper.CambiarColoresCampos(1, this, null);
               

        //    }
        //    else
        //    {

        //        saving = 0;

        //        isNew = 0;
        //        btnA.Text = "Ok";
               
        //    }
        //    cbFormOption.SelectedIndex = 0;
        //    Newadd();
        //    Mensaje();
        //}
        //void Newadd()
        //{


        //    dtgSpecialPermit.Rows.Clear();
        //     isediting = 0;


        //}
       

        #endregion
        public void New()
        {
            cbFormOption.SelectedIndex = 0;
            dtgSpecialPermit.DataSource = null;
            dtgSpecialPermit.Rows.Clear();
            //AddAction();
        }

        public void Save()
        {

            if (cbFormOption.SelectedIndex > 0)
            {

                DataTable dt = new DataTable();
            

                dt.Columns.Add("Description");
                dt.Columns.Add("Code");
                dt.Columns.Add("FormIconTag");
                dt.Columns.Add("ID");

                if (cbFormOption.SelectedIndex > 0)
                {
                    var MenuTemp = FillSuMenu.Where(x => x.MenuItemId == Convert.ToInt64(cbFormOption.SelectedValue)).FirstOrDefault();

                    foreach (var rowgrid in dtgSpecialPermit.Rows)
                    {
                        int SpecialPermitiD = rowgrid.Cells[0].Value.ToString() == "" ? 0 : Convert.ToInt32(rowgrid.Cells["SpecialPermitiD"].Value);



                        DataRow[] rows;

                        if (SpecialPermitiD != 0)
                        {
                            rows = DataResult.Select("SpecialPermitiD = " + SpecialPermitiD + "");

                            dt.Rows.Add(rowgrid.Cells[1].Value.ToString(), rowgrid.Cells[2].Value.ToString(), rowgrid.Cells[3].Value.ToString(), rowgrid.Cells["SpecialPermitID"].Value.ToString());



                        }


                        if (rowgrid.Cells[0].Value.ToString() == "")
                        {
                            dt.Rows.Add(rowgrid.Cells[1].Value.ToString(), 0, MenuTemp.IconTag, 0);
                        }
                    }

                    DialogResult dialogResult = MessageBox.Show("You are going to Update  information", "Updating", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataHelpers.SaveSpecialPermit(dt);
                       
                        LoadSpecialPermitByUser(Convert.ToInt32(cbFormOption.SelectedValue));
                        dtgSpecialPermit.DataSource = null;
                        dtgSpecialPermit.Rows.Clear();
                        dtgSpecialPermit.DataSource = DataResult;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
              


               
            }
            else
            {
                lblMensaje.Text = "Select a Menu Option";
                cbFormOption.Focus();
            }

            Mensaje("");

        }

        public void Search()
        {
            Searching();
        }

        public void Selected(SpecialPermitModel SpecialPermit)
        {
            throw new NotImplementedException();
        }

        void IformControl.Enter()
        {
  
        }
        void LoadSpecialPermitByUser(int Value) {
            DataResult = DataHelpers.FillMenuSpecialPermit(Value);
        }
        private void cbFormOption_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
     
            if (cbFormOption.SelectedIndex > 0)
            {
                LoadSpecialPermitByUser(Convert.ToInt32(cbFormOption.SelectedValue));



                dtgSpecialPermit.DataSource = DataResult;
                Flagstatus = 3;
                Mensaje(cbFormOption.SelectedText);

            }
          

           

        }

      
        private void btnA_Click(object sender, EventArgs e)
        {

            Save();
        }

        private void FrmSpecialPermit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SearchinFlag = 0;
                Flagstatus = 0;
                dtgSpecialPermit.DataSource = null;
                dtgSpecialPermit.Rows.Clear();
                cbFormOption.SelectedIndex = 0;
                Mensaje("");
            }
        }
    }
}
