using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Globals
{
    public static class Database
    {
        public static string Server = "127.0.01";
        public static int Port = 3306;
        public static string DatabaseName = "client_scheduler";
        public static string Username = "sqlUser";
        public static string Password = "Passw0rd!";
    }
}
