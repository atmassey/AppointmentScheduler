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
        private string _cityName;
        public string CityName
        {
            get { return _cityName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("City Name cannot be null or empty.");
                }
                _cityName = value.Trim();
            }
        }
        public int countryId { get; set; }
        public DateTime createDate { get; set; }
        private string _createdBy;
        public string createdBy
        {
            get { return _createdBy; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Created By cannot be null or empty.");
                }
                _createdBy = value.Trim();
            }
        }
        public Timestamp lastUpdate { get; set; }
        private string _lastUpdateBy;
        public string lastUpdateBy
        {
            get { return _lastUpdateBy; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last Updated By cannot be null or empty.");
                }
                _lastUpdateBy = value.Trim();
            }
        }
    }
}
