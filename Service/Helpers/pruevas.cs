using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace Data.Helpers
{
    public class pruevas
    {
        //   _TempUserData = _UserData.AsEnumerable().Where(x => Regex.IsMatch(x.Field<string>(SelectedColums.First().ToString()),txtFilter.Text))
        //.CopyToDataTable();


        void dtgMenuItemFormFilter(string fiter, DataTable dt, RadGridView dtg, RadTextBox txt)
        {

            string fieldName = string.Concat("[", dt.Columns["Description"].ColumnName, "]");
            dt.DefaultView.Sort = fieldName;
            DataView view = dt.DefaultView;
            view.RowFilter = string.Empty;
            if (txt.Text != string.Empty)
                view.RowFilter = fieldName + " LIKE '%" + fiter + "%'";
            dtg.DataSource = view;
        }
        public DataTable dtgUserFilterFilter(string fiter, DataTable dt, RadGridView dtg, List<string> columnas /*RadTextBox txt*/)
        {
            DataTable NewDt = new DataTable();
            int count = 0;
            foreach (var item in columnas)
            {
                string fieldName = string.Concat("[", dt.Columns[item].ColumnName, "]");

                if (NewDt.Rows.Count != 0)
                {
                    NewDt.DefaultView.Sort = fieldName;
                }
                else
                {
                    dt.DefaultView.Sort = fieldName;

                }


                DataView view;
                if (count > 0)
                {
                    view = NewDt.DefaultView;
                    view.RowFilter = string.Empty;
                }
                else
                {
                    view = dt.DefaultView;
                    view.RowFilter = string.Empty;
                }


                //view.RowFilter = string.Empty;
                //if (txt.Text != string.Empty)

                view.RowFilter = item.ToString() + " LIKE '%" + fiter + "%'";
                NewDt = view.ToTable();

                count++;
            }
            return NewDt;
        }
    }
}
