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
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
            }
        }
        public int addressId { get; set; }
        public bool Active { get; set; }
        public DateTime createdDate { get; set; }
        private string _createdBy;
        public string createdBy
        {
            get { return _createdBy; }
            set
            {
                if (String.IsNullOrEmpty(value))
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
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last Updated By cannot be null or empty.");
                }
                _lastUpdateBy = value.Trim();
            }
        }
    }
}
