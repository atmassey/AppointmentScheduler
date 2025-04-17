using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentScheduler.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace AppointmentScheduler.Globals
{
    public class Database
    {
        public static string Server = "127.0.0.1";
        public static int Port = 3306;
        public static string DatabaseName = "client_schedule";
        public static string Username = "sqlUser";
        public static string Password = "Passw0rd!";
        public static string CurrentUser {get; set; } = "";

        // Query strings
        private const string LoginQuery = "SELECT userName, password FROM user WHERE userName = @username AND password = @password";
        // Query to get all customers
        private const string AllCustomerQuery = 
            @"SELECT c.customerId, c.customerName, a.phone, a.address, a.address2, a.postalCode, ci.city, co.country, c.active 
            FROM customer c
            JOIN address a ON c.addressId = a.addressId
            JOIN city ci ON ci.cityId = a.cityId
            JOIN country co ON co.countryId = ci.countryId";
        // Query to update customer by customerId
        private const string UpdateCustomerQuery =
           @"UPDATE customer c
            JOIN address a ON c.addressId = a.addressId
                JOIN city ci ON ci.cityId = a.cityId
            JOIN country co ON co.countryId = ci.countryId
            SET
                c.customerName = @customerName,
                c.active = @active,
                a.phone = @phone,
                a.address = @address,
                a.address2 = @address2,
                a.postalCode = @postalCode,
                ci.city = @city,
                co.country = @country
            WHERE c.customerId = @customerId";

        public static string ConnectionString
        {
            get
            {
                return $"server={Server};uid={Username};pwd={Password};database={DatabaseName};";
            }
        }
        public MySqlConnection getConnection()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            return conn;
        }

        public MySqlCommand newQuery(MySqlConnection conn, string query, List<MySqlParameter> parameters)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            if (parameters == null || parameters.Count == 0)
            {
                return cmd;
            }
            foreach (var parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            return cmd;
        }
        public bool Login(string username, string password)
        {
            MySqlConnection conn = null;
            try
            {
                conn = getConnection();
                var parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@username", username),
                    new MySqlParameter("@password", password)
                };
                MySqlCommand cmd = newQuery(conn, LoginQuery, parameters);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string userName = reader["userName"].ToString();
                    string passWord = reader["password"].ToString();
                    if (userName == username && passWord == password)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                // Ensure the connection is closed even if an error occurs
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public DataTable GetAllCustomers()
        {
            MySqlConnection conn = null;
            try
            {
                conn = getConnection();
                MySqlCommand cmd = newQuery(conn, AllCustomerQuery, null);
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                // Ensure the connection is closed even if an error occurs
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public bool UpdateCustomer(int customerId, List<MySqlParameter> parameters)
        {
            MySqlConnection conn = null;
            try
            {
                conn = getConnection();
                MySqlCommand cmd = newQuery(conn, UpdateCustomerQuery, parameters);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                // Ensure the connection is closed even if an error occurs
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
