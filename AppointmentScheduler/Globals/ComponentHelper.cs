using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AppointmentScheduler.Globals
{
    public static class ComponentHelper
    {
        public static void InitializeDataGrid(DataGridView dg)
        {
            dg.ClearSelection();
            dg.ColumnHeadersDefaultCellStyle.SelectionBackColor = dg.ColumnHeadersDefaultCellStyle.BackColor;
            dg.EnableHeadersVisualStyles = false;
            dg.MultiSelect = false;
            dg.RowHeadersVisible = false;
            dg.AllowUserToAddRows = false;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dg.ReadOnly = true;
            dg.AllowUserToResizeRows = false;
        }
    }
}
