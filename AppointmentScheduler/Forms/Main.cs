using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppointmentScheduler.Forms;
using AppointmentScheduler.Globals;

namespace AppointmentScheduler
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            // Set the current date and time in the status strip
            CurrentUser.Text = "Current User: " + GlobalConst.CurrentUser;
            ComponentHelper.InitializeDataGrid(CalendarView);
        }
        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }
        private void appointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appointment appointmentForm = new Appointment();
            appointmentForm.Show();
        }
        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customerForm = new Customer();
            customerForm.Show();
        }
        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports reportForm = new Reports();
            reportForm.Show();
        }
        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
           updateCalendarView();
        }
        private void MonthlyRadio_CheckedChanged(object sender, EventArgs e)
        {
            updateCalendarView();
        }
        private void DailyRadio_CheckedChanged(object sender, EventArgs e)
        {
            updateCalendarView();
        }
        private void updateCalendarView()
        {
            int month = Calendar.SelectionStart.Month;
            int year = Calendar.SelectionStart.Year;
            int day = Calendar.SelectionStart.Day;
            if (MonthlyRadio.Checked)
            {
                
                Database db = new Database();
                DataTable dt = db.GetMonthlyAppointments(month, year);
                CalendarView.DataSource = dt;
            }
            if (DailyRadio.Checked)
            {
                Database db = new Database();
                DataTable dt = db.GetDailyAppointments(month, year, day);
                CalendarView.DataSource = dt;
            }
        }
    }
}
