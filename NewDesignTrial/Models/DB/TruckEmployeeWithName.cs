using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
    

namespace NewDesignTrial.Models.DB
{
    public class TruckEmployeeWithName
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string OfficeAddress { get; set; } = null!;
        public string PhoneExtensionNumber { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
