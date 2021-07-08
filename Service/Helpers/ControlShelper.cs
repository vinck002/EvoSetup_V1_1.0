using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Data.Helpers
{
   
    public class ControlShelper
    {
        //public IformControl _FormControl;
        public void ControlKeys(object sender, KeyEventArgs e, IformControl Frm)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                Frm.Save();            
            }
            if (e.KeyCode == Keys.F && e.Control)
            {
                Frm.Search();
            }
            if (e.KeyCode == Keys.Enter)
            {
                Frm.Enter();
            }
            if (e.Control && e.KeyCode == Keys.N)
            {
                Frm.New();
            }
        }
       public void Mensaje(RadLabel lblMensaje, string Descrip,int Flagstatus,RadButton btnA)
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

    }
}
