using System;
using System.Collections.Generic;

namespace NewDesignTrial.Models.DB
{
    public partial class TruckEmployee
    {
        public int EmployeeId { get; set; }
        public string OfficeAddress { get; set; } = null!;
        public string PhoneExtensionNumber { get; set; } = null!;
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                if(value.Length>=7)
                {
                    username = value;
                }
                else
                {
                    throw new Exception("Username must contain at least 7 characters");
                }
                
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if(value.Length>=7)
                {
                    password = value;
                }
                else
                {
                    throw new Exception("Password must contain at least 7 characters");
                }
            }
        }
        public string Role { get; set; } = null!;

        public virtual TruckPerson Employee { get; set; } = null!;
    }
}
