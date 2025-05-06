using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Globals
{
    public static class GlobalConst
    {
        // Constants for errors  
        public const string LoginError = "Login Error";
        public const string DbError = "Database Error";
        public const string ArgError = "Argument Error";
        public const string GenericError = "Generic Error";
        // Constants for database queries  
        public const string CustomerName = "customerName";
        public const string CustomerId = "customerId";
        public const string CountryId = "countryId";
        public const string CityId = "cityId";
        // Login Constants  
        public const string UserName = "userName";
        public const string Password = "password";
        // Appointment Constants  
        public const string AppointmentStart = "start";
        public const string AppointmentEnd = "end";
        // Query parameter constants  
        public const string AddressParameter = "@address";
        public const string Address2Parameter = "@address2";
        public const string CityParameter = "@city";
        public const string CountryParameter = "@country";
        public const string UsernameParameter = "@username";
        public const string PasswordParameter = "@password";
        public const string PostalCodeParameter = "@postalCode";
        public const string PhoneParameter = "@phone";
        public static string CurrentUser { get; set; } = string.Empty;
        public static int CurrentUserId { get; set; } = 0;
        // Appointment Type Constants
        public static readonly string[] AppointmentTypes = new string[] { "Follow-Up", "Consultation", "Presentation", "Scrum" };
        // Report Types  
        public const int AppointmentTypeByMonth = 0;
        public const int UserSchedule = 1;
        public const int AppointmentsByCustomer = 2;
        public static DataTable Reminder { get; set; } = new DataTable();
    }
}
