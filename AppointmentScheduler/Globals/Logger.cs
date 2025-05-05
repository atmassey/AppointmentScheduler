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
        public void Debug(string message)
        {
            newLogEntry(message, "DEBUG");
        }
        public void Info(string message)
        {
            newLogEntry(message, "INFO");
        }
        public void Warn(string message)
        {
            newLogEntry(message, "WARN");
        }
        public void Error(string message)
        {
            newLogEntry(message, "ERROR");
        }
        public void Fatal(string message)
        {
            newLogEntry(message, "FATAL");
        }
        private void newLogEntry(string message, string messageType)
        {
            try
            {
                // Log the message with the specified type  
                string logMessage = $"{DateTime.Now}: [{messageType}] - {message}";
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
