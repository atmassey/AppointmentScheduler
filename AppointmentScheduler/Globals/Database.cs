using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        // Query strings
        public const string LoginQuery = "SELECT userName, password FROM user WHERE userName = @username AND password = @password";

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

        public MySqlCommand newQuery(MySqlConnection conn, string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            return cmd;
        }
        public bool Login(string username, string password)
        {
            MySqlConnection conn = getConnection();
            MySqlCommand cmd = newQuery(conn, LoginQuery);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
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
    }
}
