using AppointmentScheduler.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentScheduler
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Forms.Login());
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("An invalid operation error occurred: " + ex.Message, GlobalConst.GenericError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, GlobalConst.GenericError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
