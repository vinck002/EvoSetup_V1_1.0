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
    public partial class FrmRoles : Form, IRole,IformControl
    {
        int Modul = 0;
        int isediting = 0;
        int isNew = 0;
        int saving = 0;
        ControlShelper ControlHelper;
        RoleModel _Role;
        DataHelpers DataHelpers;
        DataTable DataResult;
        DataTable ComboRoles;
        public FrmRoles()
        {
            ControlHelper = new ControlShelper();
            DataHelpers = new DataHelpers();
          
            InitializeComponent();
            LoadCombosBoxUser();
        }
        //public FrmRoles(Form frm)
        //{

        //}

        #region MyReVoid Methods
        void SearchControl(int Mod)
        {
            if (Mod == 0)
            {
                FindHelper FH = new FindHelper();
                FH.CleanAllFields(this);

            }

        }

        void Add()
        {

            foreach (RadTextBox textBox in this.Controls.OfType<RadTextBox>())
            {
                textBox.Text = string.Empty;

            }

            foreach (var _comboBox in this.Controls.OfType<ComboBox>())
            {
                _comboBox.SelectedIndex = -1;

            }

            //cbGroupRole.SelectedValue = 1;
            isediting = 0;

        }

        #endregion
        void Searching()
        {
            FindHelper FHelper = new FindHelper();
            txtDescription.Focus();
            //btnNew.BackColor = Color.Transparent;


            if (Modul == 0)
            {

                saving = 1;
                Modul = 1;
                cbGroupRole.SelectedIndex = -1;

                SearchControl(0);
                if (isNew == 1)
                {
                    var item = this.Controls.OfType<RadTextBox>();
                    var EmptyField = item.Where(x => x.Text == string.Empty).Count();
                    if (EmptyField == item.Count())
                    {
                        Modul = 1;
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

                }
                else
                {
                    FHelper.CambiarColoresCampos(1, this,null);

                    saving = 0;
                    btnSearch.BackColor = Color.Transparent;
                    btnA.Text = "Ok";

                }
                Modul = 0;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Searching();
        }

        private void FrmRoles_KeyDown(object sender, KeyEventArgs e)
        {
            ControlHelper.ControlKeys(sender, e, this);
            //if (e.KeyCode == Keys.S && e.Control)
            //{
            //    if (isNew == 1 || isediting == 1)
            //    {
            //        saving = 2;
            //    }

            //    btnA.PerformClick();


            //}
            //if (e.KeyCode == Keys.F && e.Control)
            //{
            //    btnSearch.PerformClick();
            //    btnNew.BackColor = Color.Transparent;
            //    isediting = 0;
            //}
            //if (e.KeyCode == Keys.Enter)
            //{


            //    if (this.btnA.Focused)
            //    {
            //        btnA.PerformClick();
            //    }
            //    else
            //    {

            //        this.SelectNextControl(ActiveControl, true, true, true, true);

            //    }

            //}
            //if (e.Control && e.KeyCode == Keys.N)
            //{

            //    btnNew.PerformClick();

            //}

        }

        void AddAction()
        {
            FindHelper FHelper = new FindHelper();
            btnSearch.BackColor = Color.Transparent;
            Modul = 0;
            txtCode.Focus();
            if (isNew == 0)
            {
                btnNew.BackColor = Color.Red;
                isNew = 1;
                btnA.Text = "Save";
                saving = 2;
                FHelper.CambiarColoresCampos(1, this,null);
            }
            else
            {
                saving = 0;
                btnNew.BackColor = Color.Transparent;
                isNew = 0;
                btnA.Text = "Ok";

            }

            Add();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                            FrmSearchinRoles FrmSearching;
                            RoleModel _role = new RoleModel()
                            {
                                Code = txtCode.Text,
                                Descri = txtDescription.Text,
                                GrpRole = cbGroupRole.Text

                            };
                            DataResult = DataHelpers.SearchRoles(_role);
                            DataResult.PrimaryKey = new DataColumn[] { DataResult.Columns["Id"] };
                            FrmSearching = new FrmSearchinRoles(this, DataResult);
                            FrmSearching.ShowDialog();

                        }

                    }


                    break;
                case 2:

                    ValidationHelpers validation = new ValidationHelpers();
                    if (isNew == 1)
                    {



                        if (validation.TagValidation(this, 1))
                        {
                            _Role = new RoleModel
                            {
                                Code = txtCode.Text,
                                Descri = txtDescription.Text,
                                GrpRoleId = Convert.ToInt32(cbGroupRole.SelectedValue) <= 0 ? 0 : Convert.ToInt32(cbGroupRole.SelectedValue)
                            };

                            if (DataHelpers.RolesManagment(_Role))
                            {
                                
                                LoadCombosBoxUser();
                                MessageBox.Show("Done!");
                                btnNew.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("Code Allready Exist!");
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
                            int IdRol = _Role.Id;
                            string RoldescriTemp = _Role.Descri;
                            string RolCodeTemp = _Role.Code;
                            int RolGroupTemp = _Role.GrpRoleId;

                            _Role = new RoleModel
                            {
                                Id = IdRol,
                                Code = txtCode.Text,
                                Descri = txtDescription.Text,
                                GrpRoleId = Convert.ToInt32(cbGroupRole.SelectedValue) <= 0 ? 0 : Convert.ToInt32(cbGroupRole.SelectedValue)
                            };

                            if (RoldescriTemp != _Role.Descri || RolCodeTemp != _Role.Code || RolGroupTemp != Convert.ToInt32(cbGroupRole.SelectedValue))
                            {
                                DialogResult dialogResult = MessageBox.Show("You are going to Update  information", "Updating", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {

                                    if (DataHelpers.RolesManagment(_Role))
                                    {
                                        MessageBox.Show("Done!");
                                    }

                                    btnA.Text = "Ok";

                                }
                                else if (dialogResult == DialogResult.No)
                                {

                                    return;
                                }

                            }
                            else
                            {
                                btnA.Text = "Ok";
                                MessageBox.Show("Done!");
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

        public void Selected(RoleModel Role)
        {
            _Role = Role;
            
            txtCode.Text = Role.Code;
            txtDescription.Text = Role.Descri;
            cbGroupRole.SelectedValue = $"{Role.GrpRoleId}";



            isediting = 1;
            //btnSearch.PerformClick();
            Searching();
            txtDescription.Focus();
        }

        void LoadCombosBoxUser()
        {
            if (DataHelpers.Verificaconect())
            {
                Dictionary<string, string> Data = new Dictionary<string, string>();
                Data.Add("", "");

                ComboRoles = DataHelpers.FillCombosRole();
                cbGroupRole.DisplayMember = "Descri";
                cbGroupRole.ValueMember = "Id";
                cbGroupRole.DataSource = ComboRoles;
                
                cbGroupRole.SelectedIndex = -1;
            }
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
            throw new NotImplementedException();
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
    }
}
