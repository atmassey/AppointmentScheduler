using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            Location.Text = localZone.StandardName;
            // Set localization based on the region
            Globalization();
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
                GlobalConst.CurrentUserId = db.GetUserId(username);
                // Check for upcoming appointments
                CheckUpcomingAppointments();
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            catch (LoggerException ex)
            {
                if (GlobalConst.IsTurkish)
                {
                    MessageBox.Show("Giriş işlemi sırasında bir hata oluştu: " + ex.Message, GlobalConst.LoggerErrorTurk, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("An error occurred while logging to a file: " + ex.Message, GlobalConst.LoggerError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (LoginException ex)
            {
                if (GlobalConst.IsTurkish)
                {
                    MessageBox.Show("Giriş işlemi sırasında bir hata oluştu: " + ex.Message, GlobalConst.LoginErrorTurk, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("An error occurred while logging in: " + ex.Message, GlobalConst.LoginError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (GlobalConst.IsTurkish)
                {
                    MessageBox.Show("Giriş işlemi sırasında bir hata oluştu: " + ex.Message, GlobalConst.GenericErrorTurk, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("An error occurred while logging in: " + ex.Message, GlobalConst.GenericError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void CheckUpcomingAppointments()
        {
            int userId = GlobalConst.CurrentUserId;
            DateTime currentDateTime = DateTime.UtcNow;
            DateTime nextFifteenMins = currentDateTime.AddMinutes(15);
            Database db = new Database();
            DataTable dt = db.GetUpcomingAppointments(userId, currentDateTime, nextFifteenMins);
            GlobalConst.Reminder = dt;
            if (dt.Rows.Count > 0)
            {
                Reminder reminder = new Reminder();
                reminder.Show();
                MessageBox.Show("You have upcoming appointments in the next 15 minutes.", "Upcoming Appointments", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Globalization()
        {
            // Set localization based on the region info
            switch (RegionInfo.CurrentRegion.TwoLetterISORegionName)
            {
                case "US":
                    // Set English localization
                    GlobalConst.IsTurkish = false;
                    // English localization
                    this.Text = "Appointment Scheduler - Login";
                    TitleLabel.Text = "Appointment Scheduler - Login";
                    UsernameLabel.Text = "Username";
                    PasswordLabel.Text = "Password";
                    LoginBtn.Text = "Login";
                    LocationLabel.Text = "Location: ";
                    Location.Text = localZone.StandardName;
                    break;
                case "TR":
                    GlobalConst.IsTurkish = true;
                    // Turkish localization
                    this.Text = "Randevu Planlayıcı - Giriş";
                    TitleLabel.Text = "Randevu Planlayıcı - Giriş";
                    UsernameLabel.Text = "Kullanıcı Adı";
                    PasswordLabel.Text = "Şifre";
                    LocationLabel.Text = "Konum: ";
                    Location.Text = $"UTC{localZone.BaseUtcOffset.ToString()}";
                    LoginBtn.Text = "Giriş Yap";
                    break;
                default:
                    // Default to English
                    this.Text = "Appointment Scheduler - Login";
                    LoginUsername.Text = "Username";
                    LoginPassword.Text = "Password";
                    LoginBtn.Text = "Login";
                    break;
            }
        }
        // Manual globalization for language selection 
        private void ManualGlobalization()
        {
            if (GlobalConst.IsTurkish)
            {
                this.Text = "Randevu Planlayıcı - Giriş";
                TitleLabel.Text = "Randevu Planlayıcı - Giriş";
                UsernameLabel.Text = "Kullanıcı Adı";
                PasswordLabel.Text = "Şifre";
                LocationLabel.Text = "Konum: ";
                LoginBtn.Text = "Giriş Yap";
                Location.Text = $"UTC{localZone.BaseUtcOffset.ToString()}";
            }
            else
            {
                this.Text = "Appointment Scheduler - Login";
                TitleLabel.Text = "Appointment Scheduler - Login";
                UsernameLabel.Text = "Username";
                PasswordLabel.Text = "Password";
                LocationLabel.Text = "Location: ";
                LoginBtn.Text = "Login";
                Location.Text = localZone.StandardName;
            }
        }
        private void EnglishBtn_Click(object sender, EventArgs e)
        {
            if (EnglishBtn.Checked)
            {
                GlobalConst.IsTurkish = false;
                ManualGlobalization();
            }
        }
        private void TurkishBtn_Click(object sender, EventArgs e)
        {
            if (TurkishBtn.Checked)
            {
                GlobalConst.IsTurkish = true;
                ManualGlobalization();
            }
        }
    }
}
