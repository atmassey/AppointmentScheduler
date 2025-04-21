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
            get { return _location; }
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
            get { return _contact; }
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
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Timestamp lastUpdate { get; set; }
    }
}
