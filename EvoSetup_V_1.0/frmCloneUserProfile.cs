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
    public partial class frmCloneUserProfile : Form
    {
        DataHelpers _DataHelpers;
        ICloneControl _CloneProfile;
        ProfilePermitListModel _ProfilePermitListModel;
        List<SpecialPermitRestriction> _lst_SpecialPermitsRstrict;
        Int64 NewUserProfile;
        StringBuilder UpdatePermitsByProfile;
        StringBuilder NewProfile;
        public frmCloneUserProfile(List<SpecialPermitRestriction> lst_SpecialPermitsRstrict,ProfilePermitListModel ObjClonar , ICloneControl CloneProfile)
        {
            _CloneProfile = CloneProfile;
            _lst_SpecialPermitsRstrict = lst_SpecialPermitsRstrict;
            _ProfilePermitListModel = ObjClonar;
            _DataHelpers = new DataHelpers();
            InitializeComponent();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            UpdatePermitsByProfile = new StringBuilder();
            NewProfile = new StringBuilder();
            int activo = chActive.Checked ? 1 : 0;

            NewProfile.Append($"Exec sp_Evo_SaveUpdateUserProfile 0, '{txtDescription.Text}','{activo}'");
            NewUserProfile = _DataHelpers.UserProfile(NewProfile.ToString());


            foreach (var item in _lst_SpecialPermitsRstrict)
            {
                UpdatePermitsByProfile.Append($"Exec sp_Evo_SpecialPermitRestrict {item.Checked}, {item.SpecialPermitiD}, {NewUserProfile} ");
            }
            foreach (var item in _ProfilePermitListModel.DepartmentProfile)
            {
                UpdatePermitsByProfile.Append($"Exec sp_Evo_DepartmentProfile {item.Checked}, {item.DepartementId}, {NewUserProfile} ");
            }
            foreach (var item in _ProfilePermitListModel.RoleProfile)
            {
                UpdatePermitsByProfile.Append($"Exec sp_Evo_RoleProfile {item.Checked}, {item.RoleID}, {NewUserProfile} ");
            }
            foreach (var item in _ProfilePermitListModel.ProfileSaleFloor)
            {
                UpdatePermitsByProfile.Append($"Exec sp_Evo_SaleFloorProfile {item.Checked}, {item.SaleFloorID}, {NewUserProfile} ");
            }
            foreach (var item in _ProfilePermitListModel.ContractStatusProfile)
            {
                UpdatePermitsByProfile.Append($"Exec sp_Evo_ContractStatusProfile {item.Checked}, {item.ContractStatusID}, {NewUserProfile} ");
            }


           

            DialogResult dialogResult = MessageBox.Show("Do you want to continue?", "Creating New UserProfile", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
               
                //UserProfileProcedure.ToString().Replace($"{_UserProfileId}", $"{NewUserProfile}");

                _DataHelpers.PermitsUserProfile(UpdatePermitsByProfile.ToString());

                _CloneProfile.Userprofile(NewUserProfile);
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
