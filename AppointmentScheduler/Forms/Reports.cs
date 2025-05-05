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
            dr["Report ID"] = GlobalConst.AppointmentTypeByMonth;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Report Type"] = "User Schedule";
            dr["Report ID"] = GlobalConst.UserSchedule;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Report Type"] = "Appointments by Customer";
            dr["Report ID"] = GlobalConst.AppointmentsByCustomer;
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
            ComponentHelper.InitializeDataGrid(ReportGrid);
        }
        private void ReportDropdown_DropDown(object sender, EventArgs e)
        {
            // Check if the report dropdown is empty before populating it
            if (ReportDropdown.DataSource == null)
            {
                // Populate the report dropdown with report types
                ReportDropdown.DisplayMember = "Report Type";
                ReportDropdown.ValueMember = "Report ID";
                ReportDropdown.DataSource = GetReportTypes();
                foreach (DataRowView row in ReportDropdown.Items)
                {
                    Console.WriteLine(row["Report Type"]);
                    Console.WriteLine(row["Report ID"]);
                }
            }
        }
        private void ReportDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Check the datasoucre of the dropdown
            if (ReportDropdown.DataSource == null)
            {
                return;
            }
            int selectedReportId = (int)ReportDropdown.SelectedValue;
            Database db = new Database();
            DataTable dt = new DataTable();
            // Get the selected report type
            switch (selectedReportId)
            {
                case GlobalConst.AppointmentTypeByMonth:
                    dt = db.GetAppointmentCountByMonth();
                    ReportGrid.DataSource = dt;
                    break;
                case GlobalConst.UserSchedule:
                    dt = db.GetScheduleForUsers();
                    ReportGrid.DataSource = dt;
                    break;
                case GlobalConst.AppointmentsByCustomer:
                    dt = db.GetAppointmentsByCustomers();
                    ReportGrid.DataSource = dt;
                    break;
                default:
                    MessageBox.Show("Invalid report type selected.");
                    break;
            }
            Console.WriteLine("Selected Report ID: " + selectedReportId);
        }
    }
}
