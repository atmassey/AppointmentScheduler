using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Models
{
    public class Address
    {
        public int Id { get; set; }
        private string _address1;
        public string Address1
        {
            get { return _address1; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Address1 cannot be null or empty.");
                }
                _address1 = value.Trim();
            }
        }
        private string _address2;
        public string Address2
        {
            get { return _address2; }
            set
            {
                _address2 = value.Trim();
            }
        }
        public int cityId { get; set; }
        private string _postalCode;
        public string postalCode
        {
            get { return _postalCode; }
            set
            {
                _postalCode = value.Trim();
            }
        }
        private string _phone;
        public string phone
        {
            get { return _phone; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Phone cannot be null or empty.");
                }
                // Check if the phone number contains only digits and dashes and spaces
                if (!value.All(c => char.IsDigit(c) || c == '-'))
                {
                    throw new ArgumentException("Phone number can only contain digits and dashes");
                }
                _phone = value.Trim();
            }
        }
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
