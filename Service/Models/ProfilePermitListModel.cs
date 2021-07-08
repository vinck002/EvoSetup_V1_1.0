using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ProfilePermitListModel
    {

        public List<SpecialPermitRestriction1> SpecialPermitRestriction1 { get; set; }

        public List<DepartmentProfile> DepartmentProfile { get; set; }
        public List<RoleProfile> RoleProfile { get; set; }
        public List<ProfileSaleFloor> ProfileSaleFloor { get; set; }
        public List<ContractStatusProfile> ContractStatusProfile { get; set; }

        public ProfilePermitListModel()
        {
            //SpecialPermitRestriction1 = new List<SpecialPermitRestriction1>();
            DepartmentProfile = new List<DepartmentProfile>();
            RoleProfile = new List<RoleProfile>();
            ProfileSaleFloor = new List<ProfileSaleFloor>();
            ContractStatusProfile = new List<ContractStatusProfile>();
         }
    }

    public class SpecialPermitRestriction1
    {
        
        public int Checked { get; set; }
        public Int64 SpecialPermitId{ get; set; }


    }
    public class DepartmentProfile
        {
       
        public int Checked { get; set; }
        public Int64 DepartementId { get; set; }
    }
    public class RoleProfile
    {
  
        public int Checked { get; set; }
        public int RoleID { get; set; }
    }
    public class ProfileSaleFloor
    {
  
        public int Checked { get; set; }
        public int SaleFloorID { get; set; }
    }
    public class ContractStatusProfile
    {
 
        public int Checked { get; set; }
        public Int64 ContractStatusID { get; set; }
    }
}
