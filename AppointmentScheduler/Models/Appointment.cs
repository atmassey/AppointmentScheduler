using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Crypto;
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
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be null or empty.");
                }
                _title = value.Trim();
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description cannot be null or empty.");
                }
                _description = value.Trim();
            }
        }
        private string _location;
        public string
            Location
        {
            get
            {
                if (_location.Length == 0)
                {
                    _location = "Bowling Green, KY";
                }
                return _location;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Location cannot be null or empty.");
                }
                _location = value.Trim();
            }
        }
        private string _contact;
        public string Contact
        {
            get
            {
                if (_contact.Length == 0)
                {
                    _contact = "555-555-5555";
                }
                return _contact;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Contact cannot be null or empty.");
                }
                _contact = value.Trim();
            }
        }
        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Type cannot be null or empty.");
                }
                _type = value.Trim();
            }
        }
        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("URL cannot be null or empty.");
                }
                _url = value.Trim();
            }
        }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private string _createdBy;
        public string CreatedBy
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
        public DateTime CreatedDate { get; set; }
        private string _lastUpdatedBy;
        public string LastUpdatedBy
        {
            get { return _lastUpdatedBy; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last Updated By cannot be null or empty.");
                }
                _lastUpdatedBy = value.Trim();
            }
        }
        public Timestamp lastUpdate { get; set; }
    }
}
