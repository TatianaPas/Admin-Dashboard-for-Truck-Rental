using System;
using System.Collections.Generic;

namespace NewDesignTrial.Models.DB
{
    public partial class TruckModel
    {
        public TruckModel()
        {
            IndividualTrucks = new HashSet<IndividualTruck>();
        }

        public int ModelId { get; set; }
        public string Model { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string Size { get; set; } = null!;
        public int Seats { get; set; }
        public int Doors { get; set; }

        public virtual ICollection<IndividualTruck> IndividualTrucks { get; set; }
    }
}
