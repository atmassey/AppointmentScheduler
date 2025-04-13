using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentScheduler.Forms
{
    public partial class Reminder : Form
    {
        public Reminder()
        {
            InitializeComponent();
        }
        private void DismissBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
