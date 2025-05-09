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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }
        private int? currentAppointmentId = null; // Nullable int to hold the appointment ID
        private int? currentCustomerId = null; // Nullable string to hold the customer name
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
            UpdateAppointmentGrid();
        }
        private void UpdateAppointmentGrid()
        {
            // Refresh the appointment grid
            Database db = new Database();
            var dt = db.GetAllAppointments();
            AppointmentGrid.DataSource = dt;
            // Change times to local time
            ChangeAppointmentTimesToLocalTime();
            AppointmentGrid.ClearSelection();
        }
        private void ChangeAppointmentTimesToLocalTime()
        {
            // Convert the appointment times to local time
            foreach (DataGridViewRow row in AppointmentGrid.Rows)
            {
                DateTime startUTC = Convert.ToDateTime(row.Cells["start"].Value);
                DateTime endUTC = Convert.ToDateTime(row.Cells["end"].Value);
                DateTime startLocal = startUTC.ToLocalTime();
                DateTime endLocal = endUTC.ToLocalTime();
                row.Cells["start"].Value = startLocal;
                row.Cells["end"].Value = endLocal;
            }
        }
        private void CustomerDropdown_DropDown(object sender, EventArgs e)
        {
            if (CustomerDropdown.Items.Count == 0)
            {
                // Populate the customer dropdown with customer names
                initializeCustomerDropdown();
            }
        }
        private void TypeDropdown_DropDown(object sender, EventArgs e)
        {
            if (TypeDropdown.Items.Count == 0)
            {
                TypeDropdown.Items.AddRange(GlobalConst.AppointmentTypes);
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppointmentGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an appointment to update.");
                    return;
                }
                if (string.IsNullOrEmpty(TitleField.Text) || string.IsNullOrEmpty(DescriptionField.Text) || string.IsNullOrEmpty(TypeDropdown.Text) || string.IsNullOrEmpty(CustomerDropdown.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }
                // Get the date and time values from the date time pickers
                DateTime start = StartTime.Value;
                DateTime end = EndTime.Value;
                // Get the day of the appointmnet
                DateTime date = DateSelector.Value;
                // Set the date of the start and end times
                start = new DateTime(date.Year, date.Month, date.Day, start.Hour, start.Minute, start.Second);
                end = new DateTime(date.Year, date.Month, date.Day, end.Hour, end.Minute, end.Second);
                currentCustomerId = Convert.ToInt32(CustomerDropdown.SelectedValue);
                // Convert the start and end times to UTC
                TimeZoneInfo localZone = TimeZoneInfo.Local;
                DateTime utcStart = TimeZoneInfo.ConvertTimeToUtc(start, localZone);
                DateTime utcEnd = TimeZoneInfo.ConvertTimeToUtc(end, localZone);
                // Create a new appointment object
                Models.Appointment appointment = new Models.Appointment
                {
                    Title = TitleField.Text,
                    Description = DescriptionField.Text,
                    Type = TypeDropdown.Text,
                    Start = utcStart,
                    End = utcEnd,
                    customerId = Convert.ToInt32(CustomerDropdown.SelectedValue),
                    Url = URLField.Text,
                };
                // Check appointment time
                checkAppointmentTime(appointment.Start, appointment.End);
                // Get the selected appointment ID
                int appointmentId = Convert.ToInt32(AppointmentGrid.SelectedRows[0].Cells["appointmentId"].Value);
                // Update the appointment ID
                appointment.Id = appointmentId;
                // Update the appointment in the database
                Database db = new Database();
                // Update the appointment in the database
                db.UpdateAppointment(appointment);
                // Refresh the appointment grid
                UpdateAppointmentGrid();
                // Clear the fields
                ClearFields();
                // Show success message
                MessageBox.Show("Appointment updated successfully.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, GlobalConst.ArgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, GlobalConst.DbError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the appointment: " + ex.Message, GlobalConst.GenericError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Prompt the user to confirm the add action
                DialogResult result = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                if (AppointmentGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an appointment to delete.");
                    return;
                }
                // Get the selected appointment ID
                int appointmentId = Convert.ToInt32(AppointmentGrid.SelectedRows[0].Cells["appointmentId"].Value);
                // Delete the appointment from the database
                Database db = new Database();
                db.RemoveAppointment(appointmentId);
                // Refresh the appointment grid
                UpdateAppointmentGrid();
                // Clear the fields
                ClearFields();
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, GlobalConst.DbError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the appointment: " + ex.Message, GlobalConst.GenericError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try {
            //Prompt the user to confirm the add action
            DialogResult result = MessageBox.Show("Are you sure you want to add a new appointment?", "Confirm Add", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }
                if (string.IsNullOrEmpty(TitleField.Text) || string.IsNullOrEmpty(DescriptionField.Text) || string.IsNullOrEmpty(TypeDropdown.Text) || string.IsNullOrEmpty(CustomerDropdown.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            // Get the date and time values from the date time pickers
            DateTime start = StartTime.Value;
            DateTime end = EndTime.Value;
            // Get the day of the appointmnet
            DateTime date = DateSelector.Value;
            // Set the date of the start and end times
            start = new DateTime(date.Year, date.Month, date.Day, start.Hour, start.Minute, start.Second);
            end = new DateTime(date.Year, date.Month, date.Day, end.Hour, end.Minute, end.Second);
            // Update customer ID
            currentCustomerId = Convert.ToInt32(CustomerDropdown.SelectedValue);
            // Convert the start and end times to UTC
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            DateTime utcStart = TimeZoneInfo.ConvertTimeToUtc(start, localZone);
            DateTime utcEnd = TimeZoneInfo.ConvertTimeToUtc(end, localZone);
                // Create a new appointment object
                Models.Appointment appointment = new Models.Appointment
            {
                Title = TitleField.Text,
                Description = DescriptionField.Text,
                Type = TypeDropdown.Text,
                Start = utcStart,
                End = utcEnd,
                customerId = Convert.ToInt32(CustomerDropdown.SelectedValue),
                Url = URLField.Text,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = GlobalConst.CurrentUser,
                LastUpdatedBy = GlobalConst.CurrentUser,
                userId = GlobalConst.CurrentUserId,
            };
            // Check appointment time
            checkAppointmentTime(appointment.Start, appointment.End);
            // Add the appointment to the database
            Database db = new Database();
            db.InsertAppointment(appointment);
            // Refresh the appointment grid
            UpdateAppointmentGrid();
            // Clear the fields
            ClearFields();
            // Show success message
            MessageBox.Show("Appointment added successfully.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, GlobalConst.ArgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, GlobalConst.DbError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the appointment: " + ex.Message, GlobalConst.GenericError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Clear all fields
            ClearFields();
        }
        private void AppointmentGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Initialize the dropdown lists if they are not already populated
            if (TypeDropdown.Items.Count == 0)
            {
                TypeDropdown.Items.AddRange(GlobalConst.AppointmentTypes);
            }
            if (CustomerDropdown.Items.Count == 0)
            {
                // Populate the customer dropdown with customer names
                initializeCustomerDropdown();
            }
            // Get the times
            DateTime start = Convert.ToDateTime(AppointmentGrid.Rows[e.RowIndex].Cells["start"].Value);
            DateTime end = Convert.ToDateTime(AppointmentGrid.Rows[e.RowIndex].Cells["end"].Value);
            DateTime dateTime = start.Date;
            // Display the selected information
            DataGridViewRow selectedRow = AppointmentGrid.Rows[e.RowIndex];
            TitleField.Text = selectedRow.Cells["title"].Value.ToString();
            currentAppointmentId = Convert.ToInt32(selectedRow.Cells["appointmentId"].Value);
            currentCustomerId = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
            DescriptionField.Text = selectedRow.Cells["description"].Value.ToString();
            DateSelector.Value = dateTime;
            string typeDropdownValue = selectedRow.Cells["type"].Value.ToString();
            // Get the index of the value
            int index = TypeDropdown.FindString(typeDropdownValue);
            // Set the selected index
            TypeDropdown.SelectedIndex = index;
            // Populate the start and end time fields with the local times
            StartTime.Value = start;
            EndTime.Value = end;
            // Set the selected customer ID
            int customerId = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
            CustomerDropdown.SelectedValue = customerId;
            URLField.Text = selectedRow.Cells["url"].Value.ToString();
        }
        private void checkAppointmentTime(DateTime start, DateTime end)
        {
            // Check if the start time is before the end time
            if (start >= end)
            {
                throw new ArgumentException("Start time must be before endtime");
            }
            // Check if the appointment is within business hours (9 AM to 5 PM EST)
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime estStart = TimeZoneInfo.ConvertTime(start, estZone);
            DateTime estEnd = TimeZoneInfo.ConvertTime(end, estZone);

            DateTime businessStart = new DateTime(estStart.Year, estStart.Month, estStart.Day, 9, 0, 0);
            DateTime businessEnd = new DateTime(estStart.Year, estStart.Month, estStart.Day, 17, 0, 0);

            if (estStart < businessStart || estEnd > businessEnd)
            {
                throw new ArgumentException("Start and end time must be within business hours (9 AM to 5 PM EST)");
            }
            // Check if the appointment overlaps with existing appointments
            Database db = new Database();
            var dt = db.GetAllAppointments();
            foreach (DataRow row in dt.Rows)
            {
                int rowAppointmentId = Convert.ToInt32(row["appointmentId"]);
                int rowCustomerId = Convert.ToInt32(row["customerId"]);

                // Skip the row if it is the same as the current appointment being modified
                if (currentAppointmentId.HasValue && rowAppointmentId == currentAppointmentId.Value && currentCustomerId == rowCustomerId)
                {
                    continue;
                }

                DateTime existingStart = Convert.ToDateTime(row[GlobalConst.AppointmentStart]);
                DateTime existingEnd = Convert.ToDateTime(row[GlobalConst.AppointmentEnd]);
                // Check if the new appointment overlaps with existing appointments
                if ((start >= existingStart && start < existingEnd) || (end > existingStart && end <= existingEnd) || (start == existingStart && end == existingEnd))
                {
                    throw new ArgumentException("Appointment can not overlap other appointments");
                }
            }
            // Check if the appointment is during the week
            if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new ArgumentException("Appointment can not be on the weekend");
            }
            // Check if the appointment is in the past
            if (start < DateTime.Now)
            {
                throw new ArgumentException("Appointment can not be in the past");
            }
        }
        private void ClearFields()
        {
            // Clear all fields
            TitleField.Clear();
            DescriptionField.Clear();
            TypeDropdown.SelectedIndex = -1;
            StartTime.Value = DateTime.Now;
            EndTime.Value = DateTime.Now;
            CustomerDropdown.SelectedIndex = -1;
            URLField.Clear();
            AppointmentGrid.ClearSelection();
        }
    }
}
