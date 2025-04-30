using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Globals
{
    public static class GlobalConst
    {
        public const string LoginError = "Login Error";
        public const string DbError = "Database Error";
        public const string ArgError = "Argument Error";
        public const string GenericError = "Generic Error";
        public const string CustomerName = "customerName";
        public const string CustomerId = "customerId";
        public const string CountryId = "countryId";
        public const string CityId = "cityId";
        // Login
        public const string UserName = "userName";
        public const string Password = "password";
        public static string CurrentUser { get; set; } = string.Empty;
    }
}
