using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   public class SpecialPermitRestriction
    {
        public Int64 SpecialPermitiD { get; set; }
        public string Description { get; set; }
        public int FormIconTag { get; set; }
        public int Checked { get; set; }

        public int UserProfileStatus { get; set; }
    }
}
