using System;
using System.Collections.Generic;

namespace NewDesignTrial.Models.DB
{
    public partial class IndividualTruck
    {
        public IndividualTruck()
        {
            TruckRentals = new HashSet<TruckRental>();
            Features = new HashSet<TruckFeature>();
        }

        public int TruckId { get; set; }
        public string Colour { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
        public DateTime WofexpiryDate { get; set; }
        public DateTime RegistrationExpiryDate { get; set; }
        public DateTime DateImported { get; set; }
        public int ManufactureYear { get; set; }
        public string Status { get; set; } = null!;
        public string FuelType { get; set; } = null!;
        public string Transmission { get; set; } = null!;
        public decimal DailyRentalPrice { get; set; }
        public decimal AdvanceDepositRequired { get; set; }
        public int TruckModelId { get; set; }

        public virtual TruckModel TruckModel { get; set; } = null!;
        public virtual ICollection<TruckRental> TruckRentals { get; set; }

        public virtual ICollection<TruckFeature> Features { get; set; }
    }
}
