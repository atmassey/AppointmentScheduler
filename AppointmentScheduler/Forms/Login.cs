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
using MySql.Data.MySqlClient;

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
            MySqlConnection conn = db.getConnection();

            string query = "SELECT userName, password FROM user WHERE userName = @username AND password = @password";
            MySqlCommand cmd = db.newQuery(conn, query);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                string userName = reader["userName"].ToString();
                string passWord = reader["password"].ToString();
                if (userName == username && passWord == password)
                {
                    Console.WriteLine("Login successful.");
                    break;
                }
            }
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }
    }
}
