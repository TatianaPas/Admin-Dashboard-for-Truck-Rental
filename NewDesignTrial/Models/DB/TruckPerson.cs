using System;
using System.Collections.Generic;

namespace NewDesignTrial.Models.DB
{
    public partial class TruckPerson
    {
        public int PersonId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Telephone { get; set; } = null!;

        public virtual TruckCustomer TruckCustomer { get; set; } = null!;
        public virtual TruckEmployee TruckEmployee { get; set; } = null!;
    }
}
