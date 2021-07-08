using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data.Models
{
    public interface IformControl
    {
        void Save();
        void Select();
        void Search();
        void New();
        void Enter();
    }
}
