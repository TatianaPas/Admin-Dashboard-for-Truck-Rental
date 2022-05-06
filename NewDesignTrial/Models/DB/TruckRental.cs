using System;
using System.Collections.Generic;

namespace NewDesignTrial.Models.DB
{
    public partial class TruckRental
    {
        public int RentalId { get; set; }
        public int TruckId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual TruckCustomer Customer { get; set; } = null!;
        public virtual IndividualTruck Truck { get; set; } = null!;
    }
}
