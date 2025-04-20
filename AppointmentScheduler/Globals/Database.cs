using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AppointmentScheduler.Models;
using MySql.Data.MySqlClient;

namespace AppointmentScheduler.Globals
{
    public class Database
    {
        public static string Server = "127.0.0.1";
        public static int Port = 3306;
        public static string DatabaseName = "client_schedule";
        public static string Username = "sqlUser";
        public static string Password = "Passw0rd!";
        public static string DbError = "Database Error";
        public static string CurrentUser { get; set; } = "";

        // Query strings
        private const string LoginQuery = "SELECT userName, password FROM user WHERE userName = @username AND password = @password";
        // Query to get all customers
        private const string AllCustomerQuery =
            @"SELECT c.customerId, c.customerName, a.phone, a.address, a.address2, a.postalCode, ci.city, co.country, c.active 
            FROM customer c
            JOIN address a ON c.addressId = a.addressId
            JOIN city ci ON ci.cityId = a.cityId
            JOIN country co ON co.countryId = ci.countryId
            ORDER BY c.customerId ASC";
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
        // Query to get city by name
        private const string GetCityQuery = "SELECT city FROM city WHERE city = @city";
        // Query to get cityId by name
        private const string GetCityIdQuery = "SELECT cityId FROM city WHERE city = @city";
        // Query to get all countries
        private const string AllCountryQuery = "SELECT country FROM country WHERE country = @country";
        // Query Country name to get countryId
        private const string GetCountryIdQuery = "SELECT countryId FROM country WHERE country = @country";
        // Query to insert city
        private const string InsertCityQuery =
        @"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) 
        VALUES (@city, @countryId, @createdDate, @createdBy, @lastUpdate, @lastUpdatedBy)";
        // Query to insert country
        private const string InsertCountryQuery =
        @"INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy)
        VALUES (@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
        private const string InsertAddressQuery =
            @"INSERT INTO address (address, address2, postalCode, phone, cityId, createDate, createdBy, lastUpdate, lastUpdateBy)
            VALUES (@address, @address2, @postalCode, @phone, @cityId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
        private const string GetAddressIdQuery =
            @"SELECT addressId FROM address WHERE address = @address AND address2 = @address2 AND postalCode = @postalCode AND phone = @phone";
        private const string InsertCustomerQuery =
            @"INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) 
            VALUES (@customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
        private const string RemoveCustomerQuery =
            @"DELETE FROM customer WHERE customerId = @customerId";

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
        public void Login(string username, string password)
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
                        return;
                    }
                }
                throw new LoginException("Invalid username or password.");
            }
            catch (Exception ex)
            {
                throw new LoginException("Login failed: " + ex.Message);
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
        // Check if city exists in the database
        public bool GetCity(string city)
        {
            MySqlConnection conn = null;
            try
            {
                conn = getConnection();
                var parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@city", city)
                };
                MySqlCommand cmd = newQuery(conn, GetCityQuery, parameters);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string cityName = reader["city"].ToString();
                    if (cityName == city)
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
        public int GetCityId(string city)
        {
            MySqlConnection conn = null;
            try
            {
                conn = getConnection();
                var parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@city", city)
                };
                MySqlCommand cmd = newQuery(conn, GetCityIdQuery, parameters);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int cityId = Convert.ToInt32(reader["cityId"]);
                    return cityId;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
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
        // Check if the country exists in the database
        public bool GetCountry(string country)
        {
            MySqlConnection conn = null;
            try
            {
                conn = getConnection();
                var parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@country", country)
                };
                MySqlCommand cmd = newQuery(conn, AllCountryQuery, parameters);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string countryName = reader["country"].ToString();
                    if (countryName == country)
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
        public int GetCountryId(string country)
        {
            MySqlConnection conn = null;
            try
            {
                conn = getConnection();
                var parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@country", country)
                };
                MySqlCommand cmd = newQuery(conn, GetCountryIdQuery, parameters);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int countryId = Convert.ToInt32(reader["countryId"]);
                    return countryId;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
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
        public int GetAddressId(Address address)
        {
            MySqlConnection conn = null;
            try
            {   
                conn = getConnection();
                var parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@address", address.Address1),
                    new MySqlParameter("@address2", address.Address2),
                    new MySqlParameter("@postalCode", address.postalCode),
                    new MySqlParameter("@phone", address.phone)
                };
                MySqlCommand cmd = newQuery(conn, GetAddressIdQuery, parameters);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int addressId = Convert.ToInt32(reader["addressId"]);
                    return addressId;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
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
        public bool AddCustomer(string city, string country, Customer customer, Address address)
        {
            MySqlConnection conn = null;
            try
            {
                conn = getConnection();
                // Check if the country exists
                if (!GetCountry(country))
                {
                    // If not, insert the country
                    var countryParameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@country", country),
                        new MySqlParameter("@createDate", DateTime.Now),
                        new MySqlParameter("@createdBy", CurrentUser),
                        new MySqlParameter("@lastUpdate", DateTime.Now),
                        new MySqlParameter("@lastUpdateBy", CurrentUser)
                    };
                    MySqlCommand countryCmd = newQuery(conn, InsertCountryQuery, countryParameters);
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    countryCmd.ExecuteNonQuery();
                }
                // Get the countryId for the inserted or existing country
                int countryId = GetCountryId(country);
                if (countryId == 0)
                {
                    Console.WriteLine("Error: Country ID not found.");
                    return false;
                }
                // Check if the city exists
                if (!GetCity(city))
                {
                    // If not, insert the city
                    var cityParameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@city", city),
                        new MySqlParameter("@countryId", countryId),
                        new MySqlParameter("@createdDate", DateTime.Now),
                        new MySqlParameter("@createdBy", CurrentUser),
                        new MySqlParameter("@lastUpdate", DateTime.Now),
                        new MySqlParameter("@lastUpdatedBy", CurrentUser)
                    };
                    MySqlCommand cityCmd = newQuery(conn, InsertCityQuery, cityParameters);
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    cityCmd.ExecuteNonQuery();
                }
                // Get the cityId for the inserted or existing city
                int cityId = GetCityId(city);
                if (cityId == 0)
                {
                    Console.WriteLine("Error: City ID not found.");
                    return false;
                }
                // Add the customer address to the database
                var addressParameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@address", address.Address1),
                    new MySqlParameter("@address2", address.Address2),
                    new MySqlParameter("@postalCode", address.postalCode),
                    new MySqlParameter("@phone", address.phone),
                    new MySqlParameter("@cityId", cityId),
                    new MySqlParameter("@createDate", DateTime.Now),
                    new MySqlParameter("@createdBy", CurrentUser),
                    new MySqlParameter("@lastUpdate", DateTime.Now),
                    new MySqlParameter("@lastUpdateBy", CurrentUser)
                };
                MySqlCommand addressCmd = newQuery(conn, InsertAddressQuery, addressParameters);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                addressCmd.ExecuteNonQuery();
                // Get the addressId for the inserted address
                int addressId = GetAddressId(address);
                if (addressId == 0)
                {
                    Console.WriteLine("Error: Address ID not found.");
                    return false;
                }
                // Add the customer to the database
                var customerParameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@customerName", customer.Name),
                    new MySqlParameter("@addressId", addressId),
                    new MySqlParameter("@active", customer.Active),
                    new MySqlParameter("@createDate", DateTime.Now),
                    new MySqlParameter("@createdBy", CurrentUser),
                    new MySqlParameter("@lastUpdate", DateTime.Now),
                    new MySqlParameter("@lastUpdateBy", CurrentUser)
                };
                MySqlCommand customerCmd = newQuery(conn, InsertCustomerQuery, customerParameters);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                customerCmd.ExecuteNonQuery();
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
        public bool RemoveCustomer(int customerId)
        {
            MySqlConnection conn = null;
            try
            {
                conn = getConnection();
                var parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@customerId", customerId)
                };
                MySqlCommand cmd = newQuery(conn, RemoveCustomerQuery, parameters);
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
