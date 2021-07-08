using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class MenuModel
    {
      
        public Int64 MenuItemId { get; set; }
        public string Description { get; set; }
        public string FormName { get; set; }
        public int ItemOrder1 { get; set; }
        public int ItemOrder2 { get; set; }
        public int ItemOrder3 { get; set; }
        public int Active { get; set; }
        public int IconTag { get; set; }
        public int UserID { get; set; }
    }
}
