using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Globals
{
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
        public LoginException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public override string ToString()
        {
            return $"LoginException: {Message}";
        }
    }
}
