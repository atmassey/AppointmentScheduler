using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int addressId { get; set; }
        public bool Active { get; set; }
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
        public Timestamp lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
    }
}
