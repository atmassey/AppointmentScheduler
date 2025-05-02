using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Globals
{
    public class LoggerException:Exception
    {
        public LoggerException() { }
        public LoggerException(string message) : base(message) { }
        public LoggerException(string message, Exception inner) : base(message, inner) { }
        public override string ToString()
        {
            return $"Logger Exception: {Message}";
        }
    }
}
