using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int countryId { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public Timestamp lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
    }
}
