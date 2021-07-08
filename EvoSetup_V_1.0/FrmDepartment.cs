using Data.Helpers;
using Data.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace EvoSetup_V_1._0
{
    public partial class FrmDepartment : Form, IDepartment,IformControl
    {
        int Modul = 0;
        int isediting = 0;
        int isNew = 0;
        int saving = 0;
        ControlShelper ControlHelper;
        DepartmentModel _Departement;
        DataHelpers DataHelpers;
        DataTable DataResult;
        public FrmDepartment()
        {
            ControlHelper = new ControlShelper();
            InitializeComponent();
            DataHelpers = new DataHelpers();
        }

        private void FrmDepartment_KeyDown(object sender, KeyEventArgs e)
        {

            ControlHelper.ControlKeys(sender, e, this);

          
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

                    if (contador != 0)
                    {
                        using (var UserDatas = new DataTable())
                        {
                            FrmSearchinDepartments FrmSearching;
                            DepartmentModel _department = new DepartmentModel()
                            {
                                DepartmentID = 0,
                                Description = txtDescription.Text,
                                Active =  0

                            };
                            DataResult = ProcedureManager.proceduremanager(_department,1);
                            //DataHelpers.SqlData($"evo1_sp_DepartmentManager 0,'{_department.Description}', 0,1");
                            DataResult.PrimaryKey = new DataColumn[] { DataResult.Columns["DepartmentID"] };
                            FrmSearching = new FrmSearchinDepartments(this, DataResult);
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

                            _Departement = new DepartmentModel
                            {
                                DepartmentID = 0,
                                Description = txtDescription.Text,
                                Active = chActive.Checked ? 1 : 0

                            };
                       
                            if (ProcedureManager.proceduremanager(_Departement, 0).Rows[0]["result"] != null)
                            {
                                MessageBox.Show("Done!");
                            }
                            else
                            {
                                MessageBox.Show("No Row Afect!");
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
                            int DepartmentID = _Departement.DepartmentID;
                            string DescriptionTemp = _Departement.Description;
                            DialogResult dialogResult = MessageBox.Show("You are going to Update  information", "Updating", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {

                                _Departement = new DepartmentModel
                                {
                                    DepartmentID = DepartmentID,
                                    Description = txtDescription.Text,
                                    Active = chActive.Checked ? 1 : 0
                                };


                            }
                            else if (dialogResult == DialogResult.No)
                            {

                                return;
                            }
                            if (DescriptionTemp != _Departement.Description)
                            {
                                
                                if (ProcedureManager.proceduremanager(_Departement, 0).Rows[0]["result"] != null)
                                {
                                    MessageBox.Show("Done!");
                                }
                                else
                                {
                                    MessageBox.Show("No Row Afect!");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No Changes!");
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
        #region void Methods
        void SearchControl(int Mod)
        {
            if (Mod == 0)
            {
                FindHelper FH = new FindHelper();
                FH.CleanAllFields(this);

            }

        }

        void New()
        {

            foreach (RadTextBox textBox in this.Controls.OfType<RadTextBox>())
            {
                textBox.Text = string.Empty;

            }

            foreach (var _comboBox in this.Controls.OfType<ComboBox>())
            {
                _comboBox.SelectedIndex = -1;

            }
            chActive.Checked = true;
            isediting = 0;

        }
         void Searching()
        {
            FindHelper FHelper = new FindHelper();
            txtDescription.Focus();
            btnNew.BackColor = Color.Transparent;


            if (Modul == 0)
            {

                saving = 1;
                Modul = 1;

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
                    FHelper.CambiarColoresCampos(0, this, new int[] { 242, 231, 128 });
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
                    FHelper.CambiarColoresCampos(1, this, null);

                    saving = 0;
                    btnSearch.BackColor = Color.Transparent;
                    btnA.Text = "Ok";

                }
                Modul = 0;
            }
        }

        void AddAction()
        {
            FindHelper FHelper = new FindHelper();
            btnSearch.BackColor = Color.Transparent;
            Modul = 0;
            txtDescription.Focus();
            if (isNew == 0)
            {
                btnNew.BackColor = Color.Red;
                isNew = 1;
                btnA.Text = "Save";
                saving = 2;
                FHelper.CambiarColoresCampos(1, this, null);
            }
            else
            {
                saving = 0;
                btnNew.BackColor = Color.Transparent;
                isNew = 0;
                btnA.Text = "Ok";

            }

            New();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        #endregion
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Searching();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Selected(DepartmentModel Department)
        {
            _Departement = Department;
            txtDescription.Text = Department.Description;
            chActive.Checked = Convert.ToBoolean(Department.Active);
            isediting = 1;
            //btnSearch.PerformClick();
            Searching();
            txtDescription.Focus();
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
            btnNew.BackColor = Color.Transparent;
            isediting = 0;
        }

        void IformControl.New()
        {
            AddAction();
            //btnNew.PerformClick();
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
