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
                MessageBox.Show("Please enter a username and password.");
                return;
            }
            Database db = new Database();
            var result = db.Login(username, password);
            if (!result)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }
            Database.CurrentUser = username;
            Main main = new Main();
            main.Show();
            this.Hide();
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
        }
    }
}
