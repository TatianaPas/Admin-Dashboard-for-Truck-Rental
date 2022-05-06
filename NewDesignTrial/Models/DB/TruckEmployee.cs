using System;
using System.Collections.Generic;

namespace NewDesignTrial.Models.DB
{
    public partial class TruckEmployee
    {
        public int EmployeeId { get; set; }
        public string OfficeAddress { get; set; } = null!;
        public string PhoneExtensionNumber { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual TruckPerson Employee { get; set; } = null!;
    }
}
