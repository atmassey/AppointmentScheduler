using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int customerId { get; set; }
        public int userId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Timestamp lastUpdate { get; set; }
    }
}
