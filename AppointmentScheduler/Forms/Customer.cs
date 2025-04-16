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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
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
        private void Customer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Customer_Load(object sender, EventArgs e)
        {
            ComponentHelper.InitializeDataGrid(CustomerGrid);
            CurrentUser.Text = "Current User: " + Database.CurrentUser;
            // Load customer data into the DataGridView
            Database db = new Database();
            // Get the data from the database
            DataTable customerData = db.GetAllCustomers();
            // Bind the data to the DataGridView
            CustomerGrid.DataSource = customerData;
            // Set the DataGridView to read-only
            CustomerGrid.ReadOnly = true;
        }
    }
}
