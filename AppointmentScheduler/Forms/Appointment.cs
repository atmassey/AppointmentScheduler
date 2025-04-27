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
            // Initialize the customer dropdown
            var customerDt = db.GetAllCustomers();
            CustomerDropdown.DataSource = customerDt;
            CustomerDropdown.DisplayMember = GlobalConst.CustomerName;
            CustomerDropdown.ValueMember = GlobalConst.CustomerId;
        }
    }
}
