using System;
using System.Collections.Generic;

namespace NewDesignTrial.Models.DB
{
    public partial class TruckCustomer
    {
        public TruckCustomer()
        {
            TruckRentals = new HashSet<TruckRental>();
        }

        public int CustomerId { get; set; }
        public string LicenseNumber { get; set; } = null!;
        public int Age { get; set; }
        public DateTime LicenseExpiryDate { get; set; }

        public virtual TruckPerson Customer { get; set; } = null!;
        public virtual ICollection<TruckRental> TruckRentals { get; set; }
    }
}
