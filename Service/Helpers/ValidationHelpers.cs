using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Data.Helpers
{
   public class ValidationHelpers
    {
       public bool TagValidation(Form formData, int tagType)
        {
            int Cont = 0;
            if (tagType == 0)
            {

            }
            else if (tagType == 1)
            {
                foreach (Control _Control in formData.Controls)
                {
                    if (_Control.Tag != null && _Control.Tag.ToString() != string.Empty)
                    {

                        if (Convert.ToInt32(_Control.Tag.ToString()) == tagType)
                        {

                            if (_Control.Text == string.Empty)
                            {
                                Cont++;
                                _Control.BackColor = Color.FromArgb(255, 255, 192);
                            }
                        }
                    }

                }


            }
            else
            {

            }

            if (Cont > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

    }
}
