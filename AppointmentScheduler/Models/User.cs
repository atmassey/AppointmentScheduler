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
        private string _userName;
        public string userName
        {
            get { return _userName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("User Name cannot be null or empty.");
                }
                _userName = value.Trim();
            }
        }
        private string _password;
        public string password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password cannot be null or empty.");
                }
                _password = value.Trim();
            }
        }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
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
        public Timestamp lastUpdate { get; set; }
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

    }
}
