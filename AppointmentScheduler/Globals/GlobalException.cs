using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Globals
{
    public class GlobalException : Exception
    {
        public GlobalException(string message) : base(message)
        {
        }
        public GlobalException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public override string ToString()
        {
            return $"DatabaseException: {Message}";
        }
    }
}
