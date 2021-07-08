using Data.Helpers;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace EvoSetup_V_1._0
{
    public partial class FrmMenu : Form, IformControl, IMenu
    {
        int Flagstatus = 0;
        int SearchinFlag = 0;

        //int isediting = 0;
        //int isNew = 0;
        //int saving = 0;
        ControlShelper ControlHelper;
        MenuModel _MenuModel;
        DataHelpers DataHelpers;
        DataTable ComboBoxDataResult;
        DataTable DataResult;
        List<MenuListModel> MenuCombosList;
        List<MenuModel> MenuList;
        List<MenuModel> SearchingMenuList;
        FindHelper FHelper;

        public FrmMenu()
        {
            ControlHelper = new ControlShelper();
            DataHelpers = new DataHelpers();
            FHelper = new FindHelper();
            InitializeComponent();
            fillComboMenu();
            //cbGrpOption.SelectedIndex = -1;

            //FrmSearchingMenu frmsearchin = new FrmSearchingMenu(MenuList);
            //frmsearchin.Show();
        }

        public void New()
        {
            AddAction();

        }

        public void Save()
        {
            if (Flagstatus > 1)
            {
                btnA.PerformClick();
            }
        }

        public void Search()
        {

            Searching();

        }

        public void Enter()
        {
            if (this.btnA.Focused)
            {
                if (Flagstatus > 1)
                {
                    btnA.PerformClick();
                }
                else
                {
                    this.SelectNextControl(ActiveControl, true, true, true, true);
                }

            }
            else
            {

                this.SelectNextControl(ActiveControl, true, true, true, true);

            }
        }

        #region Methods

        //void SearchControl(int Mod)
        //{

        //    if (Mod == 0)
        //    {
        //        FindHelper FH = new FindHelper();
        //        FH.CleanAllFields(this);
        //        cbGrpOption.SelectedIndex = 0;

        //    }


        //}
        void Searching()
        {
            fillComboMenu();
            txtDescription.Focus();

            SizeForm();
            lblHeader.Visible = true;
            cbGrpOption.Visible = true;
            lblSubHeader.Visible = true;
            cbSubHeader.Visible = true;

            Flagstatus = 1;
            SearchinFlag = 1;
            FHelper.CleanAllFields(this);
            cbGrpOption.SelectedIndex = -1;

            btnA.Text = "Search";
            FHelper.CambiarColoresCampos(0, this, new int[] { 242, 231, 128 });

            //if (SearchinFlag == 0)
            //{
            //    lblHeader.Visible = true;
            //    cbGrpOption.Visible = true;
            //    lblSubHeader.Visible = true;
            //    cbSubHeader.Visible = true;

            //    Flagstatus = 1;
            //    SearchinFlag = 1;
            //    FHelper.CleanAllFields(this);
            //    cbGrpOption.SelectedIndex = -1;

            //    btnA.Text = "Search";
            //    FHelper.CambiarColoresCampos(0, this, new int[] { 242, 231, 128 });

            //}
            //else
            //{
            //    lblHeader.Visible = false;
            //    cbGrpOption.Visible = false;
            //    lblSubHeader.Visible = false;
            //    cbSubHeader.Visible = false;

            //    foreach (var Combobox in this.Controls.OfType<RadDropDownList>())
            //    {
            //        Combobox.BackColor = Color.White;
            //    }

            //    FHelper.CambiarColoresCampos(1, this, null);
            //    SearchinFlag = 0;
            //    Flagstatus = 0;

            //}
            Mensaje();


        }

        void AddAction()
        {
            FindHelper FHelper = new FindHelper();

            SearchinFlag = 0;
            txtDescription.Focus();
            Flagstatus = 2;

            btnA.Text = "Save";
            FHelper.CambiarColoresCampos(1, this, null);
            lblFormName.Enabled = true;
            txtFormName.Enabled = true;
            txtFormName.Text = string.Empty;

          
            cbGrpOption.SelectedIndex = 0;
            Newadd();
            Mensaje();
        }
        void SizeForm(int w = 397, int h = 197)
        {
        
            this.Size = new Size(w, h);

        }

        void Newadd()
        {
        
            foreach (RadTextBox textBox in this.Controls.OfType<RadTextBox>())
            {
                textBox.Text = string.Empty;

            }
            chActive.Checked = true;
            //Flagstatus = 2;


        }

        void Mensaje()
        {
            lblMensaje.Visible = false;
            lblMensaje.Text = "";



            if (Flagstatus == 3)
            {
                lblMensaje.Text = "Updating...";
                btnA.Text = "Update";
                lblMensaje.Visible = true;
            }
            else if (Flagstatus == 2)
            {
                if (cbGrpOption.SelectedIndex < 1)
                {
                    lblMensaje.Text = "Creating a Header";

                }
                else if (cbGrpOption.SelectedIndex > 0)
                {
                    lblMensaje.Text = "Creating a Sub-Header";

                    if (cbSubHeader.SelectedIndex > 0)
                    {
                        lblMensaje.Text = "Creating a Form Option";
                    }
                    else
                    {

                        lblMensaje.Text = "Creating a Sub-Header";
                    }

                }


                lblMensaje.Visible = true;
            }
            else
            {
                if (SearchinFlag == 1)
                {
                    lblMensaje.Text = "Searching...";
                    lblMensaje.Visible = true;
                }
                else
                {
                    lblMensaje.Visible = false;
                    btnA.Text = "Ok";
                }

             
            }


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
                var FillCBGrpOption = MenuList.Where(x => x.ItemOrder3 == 0 && x.ItemOrder2 == 0 && x.ItemOrder1 > 0)
                    .ToList();


                if (FillCBGrpOption.Count > 0)
                {
                    FillCBGrpOption.Insert(0, new MenuModel { ItemOrder1 = 0, Description = "" });

              
                    cbGrpOption.DataSource = FillCBGrpOption;
                    cbGrpOption.DisplayMember = "Description";
                    cbGrpOption.ValueMember = "ItemOrder1";
                    cbGrpOption.AutoCompleteMode = AutoCompleteMode.Suggest;

                }
            }
            else if (grpMenu == 2)
            {
                if (cbGrpOption.SelectedIndex > 0)
                {
                    var FillSuMenu = MenuList.Where(x => x.ItemOrder3 == 0 && x.ItemOrder2 > 0 && x.ItemOrder1 == Convert.ToInt32(cbGrpOption.SelectedValue.ToString()))
                                      .ToList();
                    if (FillSuMenu.Count > 0)
                    {
                        FillSuMenu.Insert(0, new MenuModel { ItemOrder1 = 0, Description = "" });

              
                        cbSubHeader.DataSource = FillSuMenu;
                        cbSubHeader.DisplayMember = "Description";
                        cbSubHeader.ValueMember = "ItemOrder2";

                        cbSubHeader.AutoCompleteMode = AutoCompleteMode.Suggest;
                    }
                }




            }
            Mensaje();
        }


        #endregion

        private void cbGrpOption_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void btnA_Click(object sender, EventArgs e)
        {

            int ItemOrder1 = 0;
            int ItemOrder2 = 0;
            int SelectedItemOrder = 0;

            if (Convert.ToInt32(cbGrpOption.SelectedValue) > 0)
            {
                ItemOrder1 = Convert.ToInt32(cbGrpOption.SelectedValue.ToString());
            }
            if (Convert.ToInt32(cbSubHeader.SelectedValue) > 0)
            {
                ItemOrder2 = Convert.ToInt32(cbSubHeader.SelectedValue.ToString());
            }

            if (ItemOrder1 == 0 && ItemOrder2 == 0 && txtDescription.Text == "")
            {
                SelectedItemOrder = 1;
            }
            else if (ItemOrder1 > 0 && ItemOrder2 == 0)
            {
                SelectedItemOrder = 2;
            }
            else if (ItemOrder1 > 0 && ItemOrder2 > 0)
            {
                SelectedItemOrder = 3;
            }

            ValidationHelpers validation = new ValidationHelpers();
            if (Flagstatus == 1)
            {

                FrmSearchingMenu FrmSearching;
                
                DataResult = DataHelpers.SearchingMenuItem(txtDescription.Text, SelectedItemOrder, ItemOrder1, ItemOrder2);
                DataResult.PrimaryKey = new DataColumn[] { DataResult.Columns["MenuItemID"] };
                FrmSearching = new FrmSearchingMenu(this, DataResult);
                FrmSearching.ShowDialog();


            }
            else if (Flagstatus > 1)
            {
                if (Flagstatus == 2)
                {


                    if (validation.TagValidation(this, 1))
                    {
                        MenuModel _MenuModelTEMP = _MenuModel;
                        _MenuModel = new MenuModel()
                        {
                            MenuItemId = 0,
                            FormName = Convert.ToInt32(cbSubHeader.SelectedValue) > 0 ? txtFormName.Text : " ",
                            Description = txtDescription.Text,
                            ItemOrder1 = ItemOrder1,
                            ItemOrder2 = ItemOrder2,
                            ItemOrder3 = 0,
                            IconTag = 0,
                            Active = chActive.Checked ? 1 : 0

                        };
                        if (_MenuModel.FormName == "" && Convert.ToInt32(cbSubHeader.SelectedValue) > 0)
                        {
                            txtFormName.BackColor = Color.FromArgb(192, 255, 192);
                            return;
                            //_MenuModel.FormName = txtDescription.Text.Replace(" ", string.Empty);

                        }
                        if (DataHelpers.MenuItemsManagment(_MenuModel))
                        {
                            txtDescription.Text = string.Empty;
                            fillComboMenu();
                            MessageBox.Show("Done!");
                         
                        }
                        else
                        {
                            MessageBox.Show("Error!");
                            return;
                        }


                    }
                    else
                    {
                        return;
                    }
                }
                else if (Flagstatus == 3)
                {
                    if (validation.TagValidation(this, 2))
                    {
                        MenuModel TempMenuData = _MenuModel;
                        int Header = TempMenuData.ItemOrder1;
                        int subheader_Item2 = TempMenuData.ItemOrder2;
                        int Form_item3 = TempMenuData.ItemOrder3;
                        if (cbGrpOption.SelectedIndex == 0 && cbSubHeader.SelectedIndex == 0)
                        {
                            Header = TempMenuData.ItemOrder2 > 0?  MenuList.Where(x => x.ItemOrder3 == 0 && x.ItemOrder2 == 0)
                                      .ToList().Select(x => x.ItemOrder1).Max() + 1: TempMenuData.ItemOrder1;
                            subheader_Item2 = 0;
                            Form_item3 = 0;
                        }
                        else if (cbGrpOption.SelectedIndex > 0 && cbSubHeader.SelectedIndex == 0)
                        {
                            if (Header != Convert.ToInt32(cbGrpOption.SelectedValue))
                            {
                                Header = Convert.ToInt32(cbGrpOption.SelectedValue);
                            }
                                subheader_Item2 = TempMenuData.ItemOrder2 != Convert.ToInt32(cbSubHeader.SelectedValue) ? MenuList.Where(x => x.ItemOrder3 == 0 && x.ItemOrder2 > 0 && x.ItemOrder1 == Convert.ToInt32(cbGrpOption.SelectedValue))
                                      .ToList().Select(x => x.ItemOrder2).Max() + 1: TempMenuData.ItemOrder2;

                                 Form_item3 = 0;
                            //subheader_Item2 = MenuList.Where(x => x.ItemOrder3 == 0 && x.ItemOrder2 > 0 && x.ItemOrder1 == Convert.ToInt32(cbGrpOption.SelectedValue.ToString()))
                            //          .ToList().Select(x => x.ItemOrder2).Max();

                        }
                        else if (cbGrpOption.SelectedIndex > 0 && cbSubHeader.SelectedIndex > 0)
                        {
                            if (Header != Convert.ToInt32(cbGrpOption.SelectedValue))
                            {
                                Header = Convert.ToInt32(cbGrpOption.SelectedValue);
                            }

                            if (subheader_Item2 != Convert.ToInt32(cbSubHeader.SelectedValue))
                                {
                                    subheader_Item2 = Convert.ToInt32(cbSubHeader.SelectedValue);
                                }
          
                            //subheader_Item2 = Convert.ToInt32(cbSubHeader.SelectedValue);
                            Form_item3 = TempMenuData.ItemOrder3 == 0 ? MenuList.Where(x => x.ItemOrder1 == Convert.ToInt32(cbGrpOption.SelectedValue) && x.ItemOrder2 == Convert.ToInt32(cbSubHeader.SelectedValue))
                                      .ToList().Select(x => x.ItemOrder3).Max() + 1: TempMenuData.ItemOrder3;

                        }

                        _MenuModel = new MenuModel
                        {
                            MenuItemId = _MenuModel.MenuItemId,
                            FormName = Convert.ToInt32(cbSubHeader.SelectedValue) > 0 ? txtFormName.Text : " ",
                            Description = txtDescription.Text,
                            ItemOrder1 = Header,
                            ItemOrder2 = subheader_Item2,
                            ItemOrder3 =  Form_item3,
                            IconTag = TempMenuData.IconTag,
                            Active = chActive.Checked ? 1 : 0

                        };

                        if (_MenuModel.FormName == "" && Convert.ToInt32(cbSubHeader.SelectedValue) > 0)
                        {
                            txtFormName.BackColor = Color.FromArgb(192, 255, 192);
                            return;
                            //_MenuModel.FormName = txtDescription.Text.Replace(" ", string.Empty);

                        }

                        DialogResult dialogResult = MessageBox.Show("You are going to Update  information", "Updating", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (DataHelpers.MenuItemsManagment(_MenuModel))
                            {

                                MessageBox.Show("Done!");
                                fillComboMenu();
                                txtDescription.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show("No Row Afect!");
                                return;
                            }

                            //_MenuModel = new MenuModel
                            //{
                            //    MenuItemId = _MenuModel.MenuItemId,
                            //    FormName = Convert.ToInt32(cbSubHeader.SelectedValue) > 0 ? txtFormName.Text : " ",
                            //    Description = txtDescription.Text,
                            //    ItemOrder1 = TempMenuData.ItemOrder1 != Convert.ToInt32(cbGrpOption.SelectedValue) ? Convert.ToInt32(cbGrpOption.SelectedValue) : TempMenuData.ItemOrder1,
                            //    ItemOrder2 = TempMenuData.ItemOrder2 != Convert.ToInt32(cbSubHeader.SelectedValue) ? Convert.ToInt32(cbSubHeader.SelectedValue) : TempMenuData.ItemOrder2,
                            //    ItemOrder3 = TempMenuData.ItemOrder3,
                            //    IconTag = TempMenuData.IconTag,
                            //    Active = chActive.Checked ? 1 : 0

                            //};



                        }
                        else if (dialogResult == DialogResult.No)
                        {

                            return;
                        }
                       
                       


                    }
                }

                Searching();
                Mensaje();
           
            }
            else
            {
                this.GetNextControl(ActiveControl, true).Focus();
            }
            this.Refresh();
            FHelper.CambiarColoresCampos(1, this, null);
        }

        public void Selected(MenuModel menuModel)
        {
            _MenuModel = menuModel;

       
            if (menuModel.ItemOrder2 == 0 && menuModel.ItemOrder3 == 0 )
            {
                txtDescription.Text = menuModel.Description;
                cbGrpOption.SelectedValue = menuModel.ItemOrder1;
                int index = cbGrpOption.SelectedIndex;
                cbGrpOption.SelectedIndex = -1;
                cbGrpOption.Items.RemoveAt(index);

                int FillCBGrpOption = MenuList.Where(x => x.ItemOrder3 == 0 && x.ItemOrder2 > 0 && x.ItemOrder1 == menuModel.ItemOrder1)
                    .Count();
                if (FillCBGrpOption > 0)
                {

                    SizeForm(397, 133);

                }

            }
            else if (menuModel.ItemOrder1 > 0 && menuModel.ItemOrder3 == 0)
            {
                txtDescription.Text = menuModel.Description;
                cbGrpOption.SelectedValue = menuModel.ItemOrder1;
                cbSubHeader.SelectedValue = menuModel.ItemOrder2;
                int index = cbSubHeader.SelectedIndex;
                cbSubHeader.SelectedIndex = -1;
                cbSubHeader.Items.RemoveAt(index);

                int FillSubHeader = MenuList.Where(x => x.ItemOrder3 > 0 && x.ItemOrder2 == menuModel.ItemOrder2 && x.ItemOrder1 == menuModel.ItemOrder1)
                    .Count();
                if (FillSubHeader > 0)
                {
                    
                    SizeForm(397, 133);
                }

            }
            else if (menuModel.ItemOrder2 > 0 && menuModel.ItemOrder3 > 0)
            {
               
                txtDescription.Text = menuModel.Description;
                cbGrpOption.SelectedValue = menuModel.ItemOrder1;
                cbSubHeader.SelectedValue = menuModel.ItemOrder2;
                txtFormName.Text = menuModel.FormName;
            }

          
            txtDescription.Focus();

            SearchinFlag = 0;
            Flagstatus = 3;

            chActive.Checked = Convert.ToBoolean(menuModel.Active);

            Mensaje();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSubHeader_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmMenu_Layout(object sender, LayoutEventArgs e)
        {
            //Mensaje();
        }

        private void FrmMenu_Enter(object sender, EventArgs e)
        {
            Mensaje();
        }

        private void txtFormName_TextChanged(object sender, EventArgs e)
        {
            if (txtFormName.Text.Length > 0)
            {
                Mensaje();
            }
            if (txtFormName.Text.Length == 0)
            {
                Mensaje();
            }

        }

      
        private void cbSubHeader_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (Convert.ToInt32(cbSubHeader.SelectedIndex) > 0)
            {
                //lblFormName.Enabled = true;
                //txtFormName.Enabled = true;

                //397, 223
                SizeForm(397, 223);   
            }
            else
            {
                //lblFormName.Enabled = false;
                //txtFormName.Enabled = false;
                txtFormName.Text = string.Empty;
                SizeForm();
            }

            Mensaje();

        }

        private void cbSubHeader_TextChanged(object sender, EventArgs e)
        {
           
                if (cbSubHeader.Text == string.Empty)
                {
                    txtFormName.Text = "";
                    //txtFormName.Visible = false;
                    //lblFormName.Visible = false;
                    cbSubHeader.SelectedIndex = 0;
                    //Mensaje();
                }

        }

        private void cbGrpOption_TextChanged(object sender, EventArgs e)
        {

            if (cbGrpOption.SelectedText == string.Empty)
            {
                //cbGrpOption.SelectedIndex = 0;
                //Mensaje();
            }

        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            if (txtDescription.BackColor == Color.FromArgb(255, 255, 192))
            {
                txtDescription.BackColor = Color.White;
            }
        }

        private void FrmMenu_Resize(object sender, EventArgs e)
        {
            if (cbSubHeader.SelectedIndex > 0)
            {
                lblFormName.Visible = true;
                txtFormName.Visible = true;
            }
            else
            {
                lblFormName.Visible = false;
                txtFormName.Visible = false;
            }

            if (this.Size.Height < 134)
            {
                lblHeader.Visible = false;
                cbGrpOption.Visible = false;
                lblSubHeader.Visible = false;
                cbSubHeader.Visible = false;
                lblFormName.Visible = false;
                txtFormName.Visible = false;
            }
            else if (this.Size.Height > 134 && this.Size.Height < 198)
            {
                lblFormName.Visible = false;
                txtFormName.Visible = false;
            }
            else
            {
                lblHeader.Visible = true;
                cbGrpOption.Visible = true;
                lblSubHeader.Visible = true;
                cbSubHeader.Visible = true;
                //lblFormName.Visible = true;
                //txtFormName.Visible = true;
            }
        }

        private void cbGrpOption_SelectedIndexChanged_1(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbGrpOption.SelectedIndex > 0)
            {
                if (Flagstatus > 0)
                {
                    FillCBGrpOption(2);
                    cbSubHeader.Enabled = true;
                    //if (_MenuModel != null)
                    //{
                    //    if (_MenuModel.ItemOrder3 > 0)
                    //    {
                    //        cbSubHeader.SelectedValue = _MenuModel.ItemOrder2;
                    //    }
                       
                    //}
                    
                }
                else
                {

                    cbSubHeader.Enabled = false;
                }
            }
            else
            {
                cbSubHeader.SelectedIndex = 0;
            }

            Mensaje();
        }

        private void FrmMenu_KeyDown(object sender, KeyEventArgs e)
        {
            ControlHelper.ControlKeys(sender, e, this);
        }
    }
}
