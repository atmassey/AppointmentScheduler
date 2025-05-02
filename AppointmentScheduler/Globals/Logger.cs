using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppointmentScheduler.Globals
{
    public class Logger
    {
        public enum EntryType
        {
            DEBUG,
            INFO,
            WARNING,
            ERROR,
            FATAL
        }
        public void NewLogEntry(string message, EntryType type)
        {
            try
            {
                // Log the message with the specified type  
                string logMessage = $"{DateTime.Now}: [{type.ToString()}] - {message}";
                // Here you would typically write the logMessage to a file or a logging system  
                File.AppendAllText("Login_History.txt", logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw new LoggerException("Failed to log message", ex);
            }
        }
    }
}
