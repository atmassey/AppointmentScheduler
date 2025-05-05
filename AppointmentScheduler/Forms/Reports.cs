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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }
        public DataTable GetReportTypes()
        {
            DataRow dr = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Report Type", typeof(string));
            dt.Columns.Add("Report ID", typeof(int));
            dr = dt.NewRow();
            dr["Report Type"] = "Appointment Type by Month";
            dr["Report ID"] = (int)GlobalConst.ReportType.AppointmentTypeByMonth;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Report Type"] = "User Schedule";
            dr["Report ID"] = (int)GlobalConst.ReportType.UserSchedule;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Report Type"] = "Appointments by Customer";
            dr["Report ID"] = (int)GlobalConst.ReportType.AppointmentsByCustomer;
            dt.Rows.Add(dr);
            return dt;
        }
        private void appointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appointment appointmentForm = new Appointment();
            appointmentForm.Show();
        }
        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainForm = new Main();
            mainForm.Show();
        }
        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customerForm = new Customer();
            customerForm.Show();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }
        private void Reports_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Reports_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = "Current User: " + GlobalConst.CurrentUser;
        }
        private void ReportDropdown_DropDown(object sender, EventArgs e)
        {
            // Populate the report dropdown with report types
            ReportDropdown.DataSource = GetReportTypes();
            ReportDropdown.DisplayMember = "Report Type";
            ReportDropdown.ValueMember = "Report ID";
        }
    }
}
