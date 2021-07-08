﻿using Data.Helpers;
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
    public partial class FrmSearchinRoles : Form
    {
        private IRole _IFindRoles;
        DataTable _UserData;
        DataTable _TempUserData = new DataTable();
        //List<string> SelectedColums = new List<string>() { "FirstName" };
        FindHelper FidHelper;
        public FrmSearchinRoles(IRole role)
        {
            _IFindRoles = role;
            InitializeComponent();
        }
        public FrmSearchinRoles(IRole role, DataTable DT)
        : this(role)
        {
            _UserData = DT;
            dtgData.DataSource = _UserData;
            FidHelper = new FindHelper();
        }

        private void dtgData_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                SelectData();
            }
        }

        void SelectData()
        {

            if (dtgData.RowCount > 0)
            {
                if (dtgData.CurrentRow.Cells[0].Value != null)
                {

                    var SelectedRow = _UserData.Rows.Find(dtgData.CurrentRow.Cells["Id"].Value);

                    RoleModel _RoleModel = new RoleModel
                    {
                        Id= Convert.ToInt32(SelectedRow[0]),
                        Code = SelectedRow["Code"].ToString(),
                        Descri = SelectedRow["Descri"].ToString(),
                        GrpRoleId = Convert.ToInt32(SelectedRow["GrpRoleId"])
                    };

                    _IFindRoles.Selected(_RoleModel);
                    
                    this.Close();
                }

            }


        }

        private void FrmSearchinRoles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
           
        }

        private void dtgData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectData();
            }
           
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFilter.Text != string.Empty)
            {

                _TempUserData = FidHelper.dtgUserFilterFilter(txtFilter.Text, _UserData, "Descri");
                dtgData.DataSource = null;
                dtgData.DataSource = _TempUserData;
            }
            else
            {

                _TempUserData = FidHelper.dtgUserFilterFilter("", _UserData, "Descri");
                dtgData.DataSource = _TempUserData;
                dtgData.Update();
                dtgData.Refresh();
            }

        }
    }
}
