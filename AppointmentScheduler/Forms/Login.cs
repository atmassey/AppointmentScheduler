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
            Globals.Logger logger = new Globals.Logger();
            try
            {
                string username = LoginUsername.Text;
                string password = LoginPassword.Text;
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter a username and password.");
                    return;
                }
                Database db = new Database();
                db.Login(username, password);
                // Log the successful login
                logger.Info($"User {username} logged in successfully.");
                GlobalConst.CurrentUser = username;
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            catch (LoggerException ex)
            {
                MessageBox.Show("Failed to log message: " + ex.Message, GlobalConst.LoginError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (LoginException ex)
            {
                MessageBox.Show(ex.Message, GlobalConst.LoginError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while logging in " + ex.Message, GlobalConst.LoginError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
        }
    }
}
