using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace NewDesignTrial.Models.DB
{
    public class TrucksModelFeatures
    {
        [Key]
        public int TruckId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string WofexpiryDate { get; set; }
        public string RegistrationExpiryDate { get; set; }
        public int ManufactureYear { get; set; }
        public string FuelType { get; set; } = null!;
        public string Transmission { get; set; } = null!;
        public string DailyRentalPrice { get; set; }
        public string AdvanceDepositRequired { get; set; }
        public string Status { get; set; } = null!;

    }
}
