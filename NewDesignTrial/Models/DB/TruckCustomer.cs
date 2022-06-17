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

        private DateTime licenseExpiry;
        public DateTime LicenseExpiryDate
        {
            get {  return licenseExpiry; }
            set
            {
                if(value>DateTime.Today)
                {
                    licenseExpiry = value;
                }
                else
                {
                   // throw new Exception("License expired. Please provide new license.");
                }
            }
        }

        public virtual TruckPerson Customer { get; set; } = null!;
        public virtual ICollection<TruckRental> TruckRentals { get; set; }
    }
}
