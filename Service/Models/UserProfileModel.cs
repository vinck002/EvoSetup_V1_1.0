using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class UserProfileModel
    {
        
        public Int64 UserProfileId { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
    }
}
