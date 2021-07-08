using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Descri { get; set; }
        public int GrpRoleId { get; set; }
        public string GrpRole { get; set; }

    }
}
