using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Models
{
    public class User
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public Timestamp lastUpdate { get; set; }
        public string LastUpdatedBy { get; set; }

    }
}
