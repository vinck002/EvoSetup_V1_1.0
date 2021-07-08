using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Data.Helpers
{
    public class FindHelper
    {
      
        Color _BackColor;
        public FindHelper()
        {
            _BackColor = Color.FromArgb(192, 255, 192);
        }
        //public static AutoCompleteStringCollection LoadAutoComplete(DataTable dt)
        //{
        //    //DataTable dt = LoadDataTable();

        //    AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        stringCol.Add(Convert.ToString(row["Nombre"]));
        //    }

        //    return stringCol;
        //}

        public DataTable dtgUserFilterFilter(string fiter, DataTable dt, string columnas)
        {

            string fieldName = dt.Columns[columnas].ColumnName;
                 //string.Concat("[", dt.Columns[columnas].ColumnName, "]");

            dt.DefaultView.Sort = fieldName;

                DataView view;
             
                    view = dt.DefaultView;
                    view.RowFilter = string.Empty;

                view.RowFilter = columnas + " LIKE '%" + fiter + "%'";
            dt = view.ToTable();

            return dt;
        }
        public void CleanAllFields(Form formData)
        {
           
            foreach (Control _Control in formData.Controls)
            {
                if (_Control is RadTextBox)
                {
                    _Control.Text = string.Empty;
                }
                if (_Control.HasChildren)
                {
                    if (_Control is RadTextBox)
                        foreach (var child in _Control.Controls.OfType<Control>())
                           child.Text = string.Empty;
                    
                }
               
                   
                
            }
        }
       public void CambiarColoresCampos(int Tagoption, Form formData,int[] BackColor )
        {
            if (BackColor == null )
            {
                _BackColor = Color.FromArgb(192, 255, 192);
            }
            else
            {
                _BackColor = Color.FromArgb(BackColor[0], BackColor[1], BackColor[2]);
            }
            
            if (Tagoption == 1)
            {
                foreach (Control _Control in formData.Controls)
                {
                    if (_Control.HasChildren)
                    {
                        foreach (var child in _Control.Controls.OfType<Control>())
                            if (child is RadTextBox)
                            {
                                child.BackColor = Color.White;
                            }
                            
                    }
                }

          

               foreach (RadTextBox textBox in formData.Controls.OfType<RadTextBox>())
                {
                   textBox.BackColor = Color.White;
                   

                }
                foreach (var textBox in formData.Controls.OfType<ComboBox>())
                {
                    textBox.BackColor = Color.White;

                }
                foreach (var Combobox in formData.Controls.OfType<RadDropDownList>())
                {
                    Combobox.BackColor = Color.White;

                }
            }
            else
            {
             
                foreach (Control _Control in formData.Controls)
                {

                    if (_Control.HasChildren)
                    {
                        foreach (var child in _Control.Controls.OfType<Control>())
                            if (!(child is RadLabel))
                            {
                                child.BackColor = _BackColor;
                            }
                        
                    }
                }

            foreach (RadTextBox textBox in formData.Controls.OfType<RadTextBox>())
                {
                    textBox.BackColor = _BackColor;

                }
                foreach (var textBox in formData.Controls.OfType<ComboBox>())
                {
                    textBox.BackColor = _BackColor;

                }
                foreach (var Combobox in formData.Controls.OfType<RadDropDownList>())
                {
                    Combobox.BackColor = _BackColor;

                }
            }

        }
    }
}
