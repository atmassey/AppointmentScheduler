﻿using System;
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
using AppointmentScheduler.Models;

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
            CurrentUser.Text = "Current User: " + GlobalConst.CurrentUser;
            // Load customer data into the DataGridView
            Database db = new Database();
            // Get the data from the database
            DataTable customerData = db.GetAllCustomers();
            // Bind the data to the DataGridView
            CustomerGrid.DataSource = customerData;
            // Set the DataGridView to read-only
            CustomerGrid.ReadOnly = true;
            if (CustomerGrid.Rows.Count > 0)
            {
                // Load the customer details into the form fields
                LoadCustomerDetails();
            }
            // Clear the form fields
            ClearFields();
        }
        private void LoadCustomerDetails()
        {
            CustomerName.Text = CustomerGrid.SelectedRows[0].Cells["customerName"].Value.ToString();
            Address.Text = CustomerGrid.SelectedRows[0].Cells["address"].Value.ToString();
            AddressTwo.Text = CustomerGrid.SelectedRows[0].Cells["address2"].Value.ToString();
            PostalCode.Text = CustomerGrid.SelectedRows[0].Cells["postalCode"].Value.ToString();
            City.Text = CustomerGrid.SelectedRows[0].Cells["city"].Value.ToString();
            Country.Text = CustomerGrid.SelectedRows[0].Cells["country"].Value.ToString();
            Phone.Text = CustomerGrid.SelectedRows[0].Cells["phone"].Value.ToString();
            string ActiveString = CustomerGrid.SelectedRows[0].Cells["active"].Value.ToString();
            if (ActiveString == "True")
            {
                Active.Checked = true;
            }
            else
            {
                Active.Checked = false;
            }
        }
        private void CustomerGrid_SelectionChanged(object sender, EventArgs e)
        {
            // Check if the row is selected
            if (CustomerGrid.SelectedRows.Count > 0)
            {
                // Load the customer details into the form fields
                LoadCustomerDetails();
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            try {
            // Check if a customer is selected
            if (CustomerGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }
            //Prompt the user to confirm the save action
            DialogResult result = MessageBox.Show("Are you sure you want to save the changes?", "Confirm Save", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }
            // Initialize the customer object
            Models.Customer customer = new Models.Customer();
            customer.Name = CustomerName.Text;
            customer.Active = Active.Checked;
            // Initialize the address object
            Address address = new Address();
            address.Address1 = Address.Text;
            address.Address2 = AddressTwo.Text;
            address.postalCode = PostalCode.Text;
            address.phone = Phone.Text;
            // Initialize the city object
            City city = new City();
            city.CityName = City.Text;
            // Initialize the country object
            Models.Country country = new Country();
            country.CountryName = Country.Text;
            // Get the selected customer ID
            int customerId = Convert.ToInt32(CustomerGrid.SelectedRows[0].Cells["customerId"].Value);
            // Get the updated customer details from the form fields
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@customerId", customerId),
                new MySqlParameter("@customerName", customer.Name),
                new MySqlParameter("@active", customer.Active),
                new MySqlParameter("@phone", address.phone),
                new MySqlParameter("@address", address.Address1),
                new MySqlParameter("@address2", address.Address2),
                new MySqlParameter("@postalCode", address.postalCode),
                new MySqlParameter("@city", city.CityName),
                new MySqlParameter("@country", country.CountryName)
            };
            // Update the customer in the database
            Database db = new Database();
            db.UpdateCustomer(customerId, parameters);
            // Refresh the DataGridView
            DataTable customerData = db.GetAllCustomers();
            CustomerGrid.DataSource = customerData;
            // Clear the form fields
            ClearFields();
            // Feedback
            MessageBox.Show("Customer updated successfully.");
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show("An error occurred while saving the customer: " + ex.Message, GlobalConst.DbError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error occurred while saving the customer: " + ex.Message, GlobalConst.ArgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the customer: " + ex.Message, GlobalConst.GenericError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            // Clear the form fields
            CustomerName.Text = "";
            Address.Text = "";
            AddressTwo.Text = "";
            PostalCode.Text = "";
            City.Text = "";
            Country.Text = "";
            Phone.Text = "";
            Active.Checked = false;
            CustomerGrid.ClearSelection();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all fields are filled
                if (string.IsNullOrWhiteSpace(CustomerName.Text) || string.IsNullOrWhiteSpace(Address.Text) || string.IsNullOrWhiteSpace(Phone.Text))
                {
                    MessageBox.Show("Please enter customer name, phone number, and address to add a customer.");
                    return;
                }
                //Prompt the user to confirm the add action
                DialogResult result = MessageBox.Show("Are you sure you want to add a new customer?", "Confirm Add", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                bool isActive = Active.Checked;
                // Create a new customer object
                Models.Customer customer = new Models.Customer();
                customer.Name = CustomerName.Text;
                customer.Active = isActive;
                // Create a new address object
                Address address = new Address();
                address.Address1 = Address.Text;
                address.Address2 = AddressTwo.Text;
                address.postalCode = PostalCode.Text;
                address.phone = Phone.Text;
                // Create a new city object
                City city = new City();
                city.CityName = City.Text;
                // Create a new country object
                Country country = new Country();
                country.CountryName = Country.Text;
                // Add the customer to the database
                Database db = new Database();
                db.AddCustomer(city, country, customer, address);
                // Refresh the DataGridView
                DataTable customerData = db.GetAllCustomers();
                CustomerGrid.DataSource = customerData;
                // Clear the form fields
                ClearFields();
                // Feedback
                MessageBox.Show("Customer added successfully.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error occurred while adding the customer: " + ex.Message, GlobalConst.ArgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show("An error occurred while adding the customer: " + ex.Message, GlobalConst.DbError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the customer: " + ex.Message, GlobalConst.GenericError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a customer is selected
                if (CustomerGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a customer to delete.");
                    return;
                }
                //Prompt the user to confirm the delete action
                DialogResult result = MessageBox.Show("Are you sure you want to delete the customer?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                // Get the selected customer ID
                int customerId = Convert.ToInt32(CustomerGrid.SelectedRows[0].Cells["customerId"].Value);
                // Delete the customer from the database
                Database db = new Database();
                db.RemoveCustomer(customerId);
                // Refresh the DataGridView
                DataTable customerData = db.GetAllCustomers();
                CustomerGrid.DataSource = customerData;
                ClearFields();
                // Feedback
                MessageBox.Show("Customer deleted successfully.");
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show("An error occurred while deleting the customer: " + ex.Message, GlobalConst.DbError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("An error occurred while deleting the customer: " + ex.Message, GlobalConst.ArgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the customer: " + ex.Message, GlobalConst.GenericError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
