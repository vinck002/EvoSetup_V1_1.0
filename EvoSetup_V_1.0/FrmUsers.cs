using Data.Models;
using Data.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Collections;
using System.Globalization;

namespace EvoSetup_V_1._0
{
    public partial class FrmUsers : Form, IUsers, IformControl
    {
        //Stado del Formulario (0- tab, 1-Searching, 2-New, 3-Editing, )
        int SearchinFlag = 0;
        int isediting = 0;
        int isNew= 0;
        int saving = 0;
        ControlShelper ControlHelper;
        UserModel _User;
        DataSet CombosDelUser;
        DataHelpers _Services;
        DataTable UserDataResult;
        public FrmUsers()
        {
            ControlHelper = new ControlShelper();
            _User = new UserModel();
            InitializeComponent();


 
            _Services = new DataHelpers();
            LoadCombosBoxUser();
        }
       
        private void keypressed(Object o, KeyPressEventArgs e)
        {

        }
        void Searching()
        {
            FindHelper FHelper = new FindHelper();
            txtFirtName.Focus();
            //btnNewUser.BackColor = Color.Transparent;


            if (SearchinFlag == 0)
            {
                txtConfirmPass.Enabled = false;
                saving = 1;
                SearchinFlag = 1;

                SearchControl(0);
                if (isNew == 1)
                {
                    var item = this.Controls.OfType<RadTextBox>();
                    var EmptyField = item.Where(x => x.Text == string.Empty).Count();
                    if (EmptyField == item.Count())
                    {
                        SearchinFlag = 1;
                        btnSearch.BackColor = Color.Red;
                        btnA.Text = "Search";
                        FHelper.CambiarColoresCampos(0, this, null);
                        isNew = 0;
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("You are going to lose the information", "Canceling", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            FHelper.CambiarColoresCampos(0, this, null);
                            isNew = 0;
                            saving = 1;

                        }
                        else if (dialogResult == DialogResult.No)
                        {

                            return;
                        }

                    }
                }
                else
                {
           
                    btnSearch.BackColor = Color.Red;
                    btnA.Text = "Search";
                    FHelper.CambiarColoresCampos(0, this, null);
                }
           
            }
            else
            {
                if (isediting == 1)
                {
                    btnSearch.BackColor = Color.Transparent;
                    FHelper.CambiarColoresCampos(1, this, null);
                    saving = 2;
                    btnA.Text = "Save";
                    txtConfirmPass.Enabled = true;
                }
                else
                {
                    FHelper.CambiarColoresCampos(1, this, null);

                    saving = 0;
                    btnSearch.BackColor = Color.Transparent;
                    btnA.Text = "Ok";
                    txtConfirmPass.Enabled = false;
                }
                SearchinFlag = 0;
            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Searching();   
        }
        #region Returning Methods

     

        #endregion

        #region Void Methods


        void SearchControl(int Mod)
        {
            if (Mod == 0)
            {
                FindHelper FH = new FindHelper();
                FH.CleanAllFields(this);
                foreach (ComboBox Combos in this.Controls.OfType<ComboBox>())
                {
                    Combos.SelectedIndex = -1;
                }
                CBType.SelectedValue = "";
            }
            btnSpecialPermit.Visible = false;
        }
      
        void NewUser()
        {
            _User = null;
            foreach (RadTextBox textBox in this.Controls.OfType<RadTextBox>())
            {
                textBox.Text = string.Empty;

            }

            foreach (var _comboBox in this.Controls.OfType<ComboBox>())
            {
                _comboBox.SelectedIndex = -1;

            }
            txtConfirmPass.Enabled = true;
            CBSaleFloor.SelectedValue = 1;
            isediting = 0;
            btnSpecialPermit.Visible = false;
        }
        void LoadCombosBoxUser()
        {
            if (_Services.Verificaconect())
            {
                CombosDelUser = _Services.FillCombosUsers();
                CBDepartment.DisplayMember = "Description";
                CBDepartment.ValueMember = "DepartmentID";
                CBDepartment.DataSource = CombosDelUser.Tables[0];
                CBDepartment.SelectedIndex = -1;

                CBUserprofile.DisplayMember = "Description";
                CBUserprofile.ValueMember = "UserProfileID";
                CBUserprofile.DataSource = CombosDelUser.Tables[1];
                CBUserprofile.SelectedIndex = -1;

                CBSaleFloor.DisplayMember = "Name";
                CBSaleFloor.ValueMember = "Id";
                CBSaleFloor.DataSource = CombosDelUser.Tables[2];
                CBSaleFloor.SelectedIndex = -1;

                CBCountry.DisplayMember = "Name";
                CBCountry.ValueMember = "Id";
                CBCountry.DataSource = CombosDelUser.Tables[3];
                CBCountry.SelectedIndex = -1;

                //CBRoles.DisplayMember = "Descri";
                //CBRoles.ValueMember = "Id";
                //CBRoles.DataSource = CombosDelUser.Tables[4];
                //CBRoles.SelectedIndex = -1;

                CBType.ValueMember = "Type";
                CBType.DataSource = CombosDelUser.Tables[4];
            }
            if (!_Services.Verificaconect())
            {
                MessageBox.Show("NO Conection");
            }
           


        }
        public void Selected(UserModel Users)
        {
            _User = Users;

            txtCode.Text = Users.Code;
            txtFirtName.Text = Users.FirstName;
            txtLastName.Text = Users.LastName;
            txtPassword.Text = Users.Password;
            txtConfirmPass.Text = Users.Password;
            txtAddress.Text = Users.Address;
            txtCity.Text = Users.city;
            txtPhone1.Text = Users.phone1;
            txtPhone2.Text = Users.phone2;
            txtZipCode.Text = Users.zipcode;
            txtEmail.Text = Users.email;
            CBDepartment.SelectedValue = $"{Users.DepartmentId}";
            CBUserprofile.SelectedValue = $"{Users.UserProfileId}";
            CBType.SelectedText = $"{Users.Types}";
            CBSaleFloor.SelectedValue = $"{Users.SalesFloorId}";
            CBCountry.SelectedValue = $"{Users.countryid}";
           


            isediting = 1;
          
            //btnSearch.PerformClick();
            Searching();
            txtFirtName.Focus();
            btnSpecialPermit.Visible = true;
        }

        #endregion

        private void btnA_Click(object sender, EventArgs e)
        {
                 
            int contador = 0;

            switch (saving)
            {
                case 1:
                    foreach (var item in this.Controls.OfType<RadTextBox>())
                    {
                        if (item.Text != string.Empty)
                        {
                            contador++;
                        }

                    }
                    foreach (var item in this.Controls.OfType<ComboBox>())
                    {
                        if (item.Text != string.Empty)
                        {
                            contador++;
                        }
                    }
                    if (contador != 0)
                    {
                        using (var UserDatas = new DataTable())
                        {
                            FrmSearchingUser FrmSearching;
                            UserModel User = new UserModel()
                            {
                                Code = txtCode.Text,
                                FirstName = txtFirtName.Text,
                                LastName = txtLastName.Text,
                                Types = CBType.Text,
                                Address = txtAddress.Text,
                                city = txtCity.Text,
                                country = CBCountry.Text,
                                zipcode = txtZipCode.Text,
                                phone1 = txtPhone1.Text,
                                phone2 = txtPhone2.Text,
                                email = txtEmail.Text,
                                UserProfile = CBUserprofile.Text,
                                Department = CBDepartment.Text,
                                SalesFloor = CBSaleFloor.Text
                                
                            };
                            UserDataResult = _Services.SearchUsers(User);
                            UserDataResult.PrimaryKey = new DataColumn[] { UserDataResult.Columns["Id"] };
                            FrmSearching = new FrmSearchingUser(this,UserDataResult);
                            FrmSearching.ShowDialog();

                        }
               
                    }


                    break;
                case 2:
                 
                    ValidationHelpers validation = new ValidationHelpers();
                    if (isNew == 1)
                    {
                        

                        if (validation.TagValidation(this,1))
                        {
                            _User = new UserModel
                            {
                                Code = txtCode.Text,
                                FirstName = txtFirtName.Text,
                                LastName = txtLastName.Text,
                                Password = txtPassword.Text,
                                Types = CBType.Text,
                                Address = txtAddress.Text,
                                city = txtCity.Text,
                                countryid = Convert.ToInt32(CBCountry.SelectedValue),
                                zipcode = txtZipCode.Text,
                                phone1 = txtPhone1.Text,
                                phone2 = txtPhone2.Text,
                                email = txtEmail.Text,
                                UserProfileId = Convert.ToInt32(CBUserprofile.SelectedValue),
                                DepartmentId = Convert.ToInt32(CBDepartment.SelectedValue),
                                SalesFloorId = Convert.ToInt32(CBSaleFloor.SelectedValue)
                            };
                            if (txtPassword.Text == txtConfirmPass.Text)
                            {
                                //_Services.SAVEUsers(_User);
                                if (_Services.SAVEUsers(_User))
                                {
                                    MessageBox.Show("Done!");
                                }
                                else
                                {
                                    MessageBox.Show("Code Allready Exist!");
                                    return;
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Password Mismatch");
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                        
                    }
                    if (isediting == 1)
                    {
                        if (validation.TagValidation(this, 2))
                        {
                            if (txtPassword.Text == txtConfirmPass.Text)
                            {
                                UserModel Temp_User = _User;

                                DialogResult dialogResult = MessageBox.Show("You are going to Update  information", "Updating", MessageBoxButtons.YesNo);

                                if (dialogResult == DialogResult.Yes)
                                {

                                    int Id = _User.Id;
                                    _User = new UserModel
                                    {
                                        Id = Id,
                                        Code = txtCode.Text,
                                        FirstName = txtFirtName.Text,
                                        LastName = txtLastName.Text,
                                        Password = txtPassword.Text,
                                        Types = CBType.Text,
                                        Address = txtAddress.Text,
                                        city = txtCity.Text,
                                        countryid = Convert.ToInt32(CBCountry.SelectedValue),
                                        zipcode = txtZipCode.Text,
                                        phone1 = txtPhone1.Text,
                                        phone2 = txtPhone2.Text,
                                        email = txtEmail.Text,
                                        UserProfileId = Convert.ToInt32(CBUserprofile.SelectedValue),
                                        DepartmentId = Convert.ToInt32(CBDepartment.SelectedValue),
                                        SalesFloorId = Convert.ToInt32(CBSaleFloor.SelectedValue)
                                    };


                                }
                                else if (dialogResult == DialogResult.No)
                                {

                                    return;
                                }
                                
                                
                                if (Temp_User == _User)
                                {
                                    MessageBox.Show("No Changes");
                                }
                                //_Services.SAVEUsers(_User);
                                if (_Services.SAVEUsers(_User))
                                {
                                    MessageBox.Show("Successfully Saved");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Password Mismatch");
                                return;
                            }
                          
                        }
                      
                    }
                    isNew = 0;
                    saving = 0;

                    break;
                
                default:
                   
                    this.GetNextControl(ActiveControl, true).Focus();
                    break;
            }
            contador = 0;
           
        }

        private void FrmUsers_KeyDown(object sender, KeyEventArgs e)
        {
            ControlHelper.ControlKeys(sender, e, this);



        }

        private void CBDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CBDepartment.SelectedIndex = -1;
            }
        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void AddAction()
        {
            FindHelper FHelper = new FindHelper();
            btnSearch.BackColor = Color.Transparent;
            SearchinFlag = 0;
            txtCode.Focus();
            if (isNew == 0)
            {
                btnNewUser.BackColor = Color.Red;
                isNew = 1;
                btnA.Text = "Save";
                saving = 2;
                FHelper.CambiarColoresCampos(1, this, null);
            }
            else
            {
                saving = 0;
                btnNewUser.BackColor = Color.Transparent;
                isNew = 0;
                btnA.Text = "Ok";

            }

            NewUser();
        }
        private void btnNewUser_Click(object sender, EventArgs e)
        {
            AddAction();
            
        }

        public void Save()
        {
            if (isNew == 1 || isediting == 1)
            {
                saving = 2;
            }

            btnA.PerformClick();

        }

        public void Select(Form Frm)
        {
            //throw new NotImplementedException();
        }

        public void Search()
        {
            Searching();
            //btnSearch.PerformClick();
            //btnNew.BackColor = Color.Transparent;
            isediting = 0;
        }

        void IformControl.New()
        {
            AddAction();
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

        private void btnSpecialPermit_Click(object sender, EventArgs e)
        {
            if (_User != null)
            {
                if (_User.Id > 0)
                {
                    FrmSpecialPermitByUser FrmSpecialPermitUser = new FrmSpecialPermitByUser(_User.Id);
                    FrmSpecialPermitUser.ShowDialog();
                }
            }
          
           
        }
    }
}
