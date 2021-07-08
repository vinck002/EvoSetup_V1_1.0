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
    public partial class FrmSearchinDepartments : Form
    {
        private IDepartment _IFindDepartments;
        DataTable _UserData;
        DataTable _TempUserData = new DataTable();
      
        FindHelper FidHelper;
        public FrmSearchinDepartments(IDepartment department)
        {
            _IFindDepartments = department;
            InitializeComponent();
        }
        public FrmSearchinDepartments(IDepartment department, DataTable DT)
            :this(department)
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

                    var SelectedRow = _UserData.Rows.Find(dtgData.CurrentRow.Cells["DepartmentID"].Value);

                    DepartmentModel _DepartmentModel = new DepartmentModel
                    {
                        DepartmentID = Convert.ToInt32(SelectedRow[0]),
                        Description = SelectedRow["Description"].ToString(),
                        Active = Convert.ToInt32(SelectedRow["Active"])
                    };

                    _IFindDepartments.Selected(_DepartmentModel);

                    this.Close();
                }

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

                _TempUserData = FidHelper.dtgUserFilterFilter(txtFilter.Text, _UserData, "Description");
                dtgData.DataSource = null;
                dtgData.DataSource = _TempUserData;
            }
            else
            {

                _TempUserData = FidHelper.dtgUserFilterFilter("", _UserData, "Description");
                dtgData.DataSource = _TempUserData;
                dtgData.Update();
                dtgData.Refresh();
            }


        }

        private void FrmSearchinDepartments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
