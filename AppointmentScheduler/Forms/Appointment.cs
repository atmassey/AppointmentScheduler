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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }
        private void initializeCustomerDropdown()
        {
            // Populate the customer dropdown with customer names
            Database db = new Database();
            var dt = db.GetAllCustomers();
            CustomerDropdown.DataSource = dt;
            CustomerDropdown.DisplayMember = GlobalConst.CustomerName;
            CustomerDropdown.ValueMember = GlobalConst.CustomerId;
        }
        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customerForm = new Customer();
            customerForm.Show();
        }
        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainForm = new Main();
            mainForm.Show();
        }
        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports reportForm = new Reports();
            reportForm.Show();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }
        private void Appointment_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Appointment_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = "Current User: " + GlobalConst.CurrentUser;
            // Initialize the datagrid
            ComponentHelper.InitializeDataGrid(AppointmentGrid);
            Database db = new Database();
            var dt = db.GetAllAppointments();
            AppointmentGrid.DataSource = dt;
        }
        private void CustomerDropdown_DropDown(object sender, EventArgs e)
        {
            if (CustomerDropdown.Items.Count == 0)
            {
                // Populate the customer dropdown with customer names
                initializeCustomerDropdown();
            }
        }
        private void checkAppointmentTime(DateTime start, DateTime end)
        {
            // Convert the start and end times to UTC
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            DateTime utcStart = TimeZoneInfo.ConvertTimeToUtc(start, localZone);
            DateTime utcEnd = TimeZoneInfo.ConvertTimeToUtc(end, localZone);
            // Check if the start time is before the end time
            if (start >= end)
            {
                MessageBox.Show("Start time must be before end time.");
                return;
            }
            // Check if the appointment is within business hours (9 AM to 5 PM) EST
            DateTime businessStart = new DateTime(start.Year, start.Month, start.Day, 9, 0, 0);
            DateTime businessEnd = new DateTime(start.Year, start.Month, start.Day, 17, 0, 0);
            if (start < businessStart || end > businessEnd)
            {
                MessageBox.Show("Appointment must be within business hours (9 AM to 5 PM EST).");
                return;
            }
            // Check if the appointment overlaps with existing appointments
            Database db = new Database();
            var dt = db.GetAllAppointments();
            foreach (DataRow row in dt.Rows)
            {
                DateTime existingStart = Convert.ToDateTime(row[GlobalConst.AppointmentStart]);
                DateTime existingEnd = Convert.ToDateTime(row[GlobalConst.AppointmentEnd]);
                if ((start >= existingStart && start < existingEnd) || (end > existingStart && end <= existingEnd))
                {
                    MessageBox.Show("Appointment time overlaps with an existing appointment.");
                    return;
                }
            }
        }
    }
}
