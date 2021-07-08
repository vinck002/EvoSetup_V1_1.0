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
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace EvoSetup_V_1._0
{
    public partial class FrmSearchingMenu : Form
    {
        IMenu _IMenu;
        DataTable _SearchingData;
        DataTable _TempUserData = new DataTable();
        FindHelper FidHelper;
       
        public FrmSearchingMenu(IMenu Menu)

        {
            InitializeComponent();
            _IMenu = Menu;
        }
        public FrmSearchingMenu(IMenu FormControl,DataTable SearchingData)
            :this(FormControl)
        {
            _SearchingData = SearchingData;
            FidHelper = new FindHelper();
            dtgSearching.DataSource = _SearchingData;
                }

       
        private void dtgSearching_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                SelectData();
            }
        }

        void SelectData()
        {

            if (dtgSearching.RowCount > 0)
            {
                if (dtgSearching.CurrentRow.Cells[0].Value != null)
                {

                    var SelectedRow = _SearchingData.Rows.Find(dtgSearching.CurrentRow.Cells["MenuItemID"].Value);

                    MenuModel _MenuModelModel = new MenuModel
                    {
                        MenuItemId = Convert.ToInt64(SelectedRow["MenuItemID"]),
                        Description = SelectedRow["Description"].ToString(),
                        FormName = SelectedRow["FormName"].ToString(),
                        ItemOrder1 = Convert.ToInt32(SelectedRow["ItemOrder1"]),
                        ItemOrder2 = Convert.ToInt32(SelectedRow["ItemOrder2"]),
                        ItemOrder3 = Convert.ToInt32(SelectedRow["ItemOrder3"]),
                        IconTag = Convert.ToInt32(SelectedRow["IconTag"]),
                        Active = Convert.ToInt32(SelectedRow["Active"]),
                      

                    };

                    _IMenu.Selected(_MenuModelModel);

                    this.Close();
                }

            }


        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilter_TextChanged_1(object sender, EventArgs e)
        {
            if (txtFilter.Text != string.Empty)
            {

                _TempUserData = FidHelper.dtgUserFilterFilter(txtFilter.Text, _SearchingData, "Description");
                dtgSearching.DataSource = null;
                dtgSearching.DataSource = _TempUserData;
            }
            else
            {

                _TempUserData = FidHelper.dtgUserFilterFilter("", _SearchingData, "Description");
                dtgSearching.DataSource = _TempUserData;
                dtgSearching.Update();
                dtgSearching.Refresh();
            }

        }

        private void dtgSearching_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                    SelectData();
                
            }
        }

       

    }
}
