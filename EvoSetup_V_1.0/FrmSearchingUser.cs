using Data.Helpers;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvoSetup_V_1._0
{
    public partial class FrmSearchingUser : Form
    {
        //private string IdUserData;
        List<UserModel> tempSearching;
        private IUsers _IFindUsers;
        DataTable _UserData;
        DataTable _TempUserData = new DataTable();
        List<string> SelectedColums = new List<string>() { "FirstName" };
        FindHelper FidHelper;
        //FindHelper FidHelper;
        public FrmSearchingUser(IUsers user)
        {
            InitializeComponent();
            _IFindUsers = user;
            
            //dtgSearching.Focus();
        }

        public FrmSearchingUser(IUsers IUser,DataTable DT)
            :this(IUser)
        {
            _UserData = DT;
            dtgSearching.DataSource = _UserData;
            FidHelper = new FindHelper();
        }

        private void FrmSearching_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MasterTemplate_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
          
            if (e.RowIndex != -1)
            {
                SelectUserData();
            }
            else
            {
                SelectedColums.RemoveAt(0);
                SelectedColums.Add(e.Column.Name);

                //if (SelectedColums.Where(x => x.Equals(e.Column.Name)).ToList().Count()  == 0)
                //    {
                    
                //        SelectedColums.Add(e.Column.Name);
                //     }
              
            }

        }
        void SelectUserData()
        {

            //dtgSearching.CurrentRow.IsSelected = true;
            if (dtgSearching.RowCount > 0)
            {
                if (dtgSearching.CurrentRow.Cells["Id"].Value != null)
                {

                    var SelectUser = _UserData.Rows.Find(dtgSearching.CurrentRow.Cells["Id"].Value);

                    int CountryID = SelectUser["countryid"].ToString() != null && SelectUser["countryid"].ToString() != string.Empty?  Convert.ToInt32(SelectUser["countryid"]) :0 ;
                    int UserProfileID = SelectUser["UserProfileID"].ToString() != null && SelectUser["UserProfileID"].ToString() != string.Empty ? Convert.ToInt32(SelectUser["UserProfileID"]) : 0;
                    int DepartmentID = SelectUser["DepartmentID"].ToString() != null && SelectUser["DepartmentID"].ToString() != string.Empty ? Convert.ToInt32(SelectUser["DepartmentID"]) : 0;
                    int SaleFloorID = SelectUser["SalesFloorId"].ToString() != null && SelectUser["SalesFloorId"].ToString() != string.Empty ? Convert.ToInt32(SelectUser["SalesFloorId"]) : 0;

                   

                    UserModel _User = new UserModel
                    {
                        Id = Convert.ToInt32(SelectUser["Id"]),
                        Code = SelectUser["Code"].ToString(),
                        FirstName = SelectUser["FirstName"].ToString(),
                        LastName = SelectUser["Lastname"].ToString(),
                        Password = SelectUser["Password"].ToString(),
                        Types = SelectUser["Type"].ToString(),
                        Address = SelectUser["Address"].ToString(),
                        city = SelectUser["city"].ToString(),
                        countryid = CountryID,
                        zipcode = SelectUser["zipcode"].ToString(),
                        phone1 = SelectUser["phone1"].ToString(),
                        phone2 = SelectUser["phone2"].ToString(),
                        email = SelectUser["email"].ToString(),
                        UserProfileId = UserProfileID,
                        DepartmentId = DepartmentID,
                        SalesFloorId = SaleFloorID
                    };
                    //var user = (UserModel)dtgSearching.CurrentRow.DataBoundItem;
                    _IFindUsers.Selected(_User);

                    this.Close();
                }

            }


        }
        private void dtgSearching_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectUserData();
                
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            //try
            //{

            //    //_TempUserData = _UserData.AsEnumerable().Where(x => x.Field<string>(SelectedColums.First().ToString()) != null &&
            //    // x.Field<string>(SelectedColums.First().ToString()).ToLower().Contains(txtFilter.Text.ToLower()))
            //    //.CopyToDataTable();

            //   ////// tempSearching = _UserData.AsEnumerable().Where(x => x.Field<string>(SelectedColums.First().ToString()) != null &&
            //   //////x.Field<string>(SelectedColums.First().ToString()).ToLower().Contains(txtFilter.Text.ToLower())).AsEnumerable().Any(x=>x.)

            //    if (_TempUserData.Rows.Count != 0)
            //    {
            //        dtgSearching.DataSource = _TempUserData;
            //    }
            //    else
            //    {

            //        //dtgSearching.Rows.AddNew();
            //        dtgSearching.DataSource = _TempUserData;
            //    }


            //}
            //catch (Exception ex)
            //{
            //    var mes = ex.Message;
            //}
            #region Find With Dataview Methods
            if (txtFilter.Text != string.Empty)
            {

                _TempUserData = FidHelper.dtgUserFilterFilter(txtFilter.Text, _UserData, SelectedColums.First().ToString());
                dtgSearching.DataSource = null;
                dtgSearching.DataSource = _TempUserData;
            }
            else
            {

                _TempUserData = FidHelper.dtgUserFilterFilter("", _UserData, SelectedColums.First().ToString());
                dtgSearching.DataSource = _TempUserData;
                dtgSearching.Update();
                dtgSearching.Refresh();
            }


            #endregion


        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
                //FindHelper FidHelper = new FindHelper();
                //if (txtFilter.Text != string.Empty)
                //{

                //    dtgSearching.DataSource = FidHelper.dtgUserFilterFilter(txtFilter.Text, _UserData, dtgSearching, SelectedColums);
                //    //dtgSearching.DataSource = null;
                //    //dtgSearching.DataSource = _TempUserData;

                //    //_TempUserData = FidHelper.dtgUserFilterFilter(txtFilter.Text, _UserData, dtgSearching, SelectedColums);
                //    //dtgSearching.DataSource = null;
                //    //dtgSearching.DataSource = _TempUserData;
                //    //dtgSearching.Update();
                //    //dtgSearching.Refresh();


                //}
                //else
                //{
                //    //SelectedColums.RemoveAt(0);
                //    //SelectedColums.Add("FirstName");
                //    _TempUserData = FidHelper.dtgUserFilterFilter(txtFilter.Text, _UserData, dtgSearching, SelectedColums);
                //    dtgSearching.DataSource = _TempUserData;
                //    dtgSearching.Update();
                //    dtgSearching.Refresh();


                //}
                //_TempUserData = _UserData;
            //}
        }

        private void FrmSearching_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
