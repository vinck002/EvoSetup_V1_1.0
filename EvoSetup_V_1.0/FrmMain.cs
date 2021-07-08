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

namespace EvoSetup_V_1._0
{

    public partial class FrmMain : Form
    {

        //private IformControl _FormControl;
        bool Searching = true;
        bool Adding = true;
        public FrmMain()
        {

            InitializeComponent();
        }



        //List<string> SelectedColums = new List<string>() { "FirstName" };


        private void FrmMenubtn_Click(object sender, EventArgs e)
        {


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.MainFormPanel.Controls.Count > 0)
            {
                if (Searching)
                {
                    Searching = false;

                    //btnSearch.BackColor = Color.Red;
                }
                else
                {
                    Searching = true;
                    btnSearch.BackColor = Color.Transparent;
                }
                //_FormControl.Search();
                btnNew.BackColor = Color.Transparent;
            }

        }

        private void Roles_Click(object sender, EventArgs e)
        {

        }
        #region Methods
        private void OpenFormEnPanel(Form FrmChild)
        {
            Form Frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == FrmChild.Name);

            if (Frm != null)
            {
                //this.MainFormPanel.Controls.Add(Frm);

                Frm.BringToFront();
                Frm.WindowState = FormWindowState.Normal;
                return;
            }
            else
            {
                Frm = FrmChild;
                Frm.TopLevel = false;
                this.MainFormPanel.Controls.Add(Frm);

                Frm.Show();
            }



        }
        void checkBtnBackColor()
        {
            btnSearch.BackColor = Color.Transparent;
            btnNew.BackColor = Color.Transparent;
        }
        #endregion
        private void FrmRoleTab_Click(object sender, EventArgs e)
        {

            //_FormControl = 
            //if (new FrmRoles().IsDisposed)
            //{

            //}
                OpenFormEnPanel(new FrmRoles());


        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            if (this.MainFormPanel.Controls.Count > 0)
            {

                if (Adding)
                {
                    Adding = false;
                    //btnNew.BackColor = Color.Red;
                }
                else
                {
                    Adding = true;
                    btnNew.BackColor = Color.Transparent;
                }
                //_FormControl.New();
                btnSearch.BackColor = Color.Transparent;
            }

        }

        private void FrmDepartmentMenu_Click(object sender, EventArgs e)
        {
            //Form Frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FrmDepartment);

            //if (Frm != null)
            //{
            //    FrmChild.BringToFront();
            //    return;
            //}
            //else
            //{
            //    Frm = FrmChild;
            //    Frm.Show();
            //}

            OpenFormEnPanel(new FrmDepartment());

        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (this.MainFormPanel.Controls.Count > 0)
                {
                    //_FormControl.Save();
                }

            }
            if (e.KeyCode == Keys.F && e.Control)
            {
                btnSearch.PerformClick();

            }
            if (e.KeyCode == Keys.Enter)
            {

                if (this.MainFormPanel.Controls.Count > 0)
                {
                    //_FormControl.Enter();
                }

            }
            if (e.Control && e.KeyCode == Keys.N)
            {

                //_FormControl.New();

            }

        }

        private void FrmUsersMenu_Click(object sender, EventArgs e)
        {
            //_FormControl =
                OpenFormEnPanel(new FrmUsers());
        }

        private void MainFormPanel_Layout(object sender, LayoutEventArgs e)
        {
          
           
            checkBtnBackColor();

        }

        private void FrmOptionMenu_Click(object sender, EventArgs e)
        {
            //_FormControl = 
                OpenFormEnPanel(new FrmMenu());
        }

        private void MenuSpecialPermit_Click(object sender, EventArgs e)
        {
            //_FormControl = 
                OpenFormEnPanel(new FrmSpecialPermit());
        }

        private void frmPermisionByProfile_Click(object sender, EventArgs e)
        {
            //_FormControl = 
                OpenFormEnPanel(new FrmSpecialPermiByUserProfile());
        }

        private void FrmSpecialPermitByUser_Click(object sender, EventArgs e)
        {
            //_FormControl =
                OpenFormEnPanel(new FrmSpecialPermitByUser());
        }

    }
}
