using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentScheduler.Forms
{
    public partial class Login : Form
    {
        private TimeZoneInfo localZone = TimeZoneInfo.Local;
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Login form loaded.");
            Location.Text = localZone.StandardName;
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Login button clicked.");
            string username = LoginUsername.Text;
            string password = LoginPassword.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }
            // Simulate a successful login
            MessageBox.Show("Login successful!");
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }
    }
}
