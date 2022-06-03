using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewDesignTrial.Models.DB
{
    public class TruckRentalsWithCustomerName
    {
        [Key]
        public int RentalId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string RentDate { get; set; }
        
        public string ReturnDueDate { get; set; }

        private string returnDate;
        public string ReturnDate
        {
            get { return returnDate; }
            set
            {
                if(value=="01/01/0001")
                {
                    this.returnDate = null;
                }
                else
                {
                    this.returnDate = value;
                }
            }
        
        }
        public string TotalPrice { get; set; }
    }
}
