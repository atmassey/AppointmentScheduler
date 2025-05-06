using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppointmentScheduler.Globals;

namespace AppointmentScheduler.Forms
{
    public partial class Reminder : Form
    {
        public Reminder()
        {
            InitializeComponent();
        }
        private void Reminder_Load(object sender, EventArgs e)
        {
            // Set the location of the form to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            // Set the text of the form
            this.Text = "Upcoming Appointments Reminder";
            // Populate the DataGridView with the upcoming appointments
            ComponentHelper.InitializeDataGrid(ReminderGrid);
            DataTable dt = GlobalConst.Reminder;
            ReminderGrid.DataSource = dt;
            ReminderGrid.ClearSelection();
        }
        private void DismissBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
