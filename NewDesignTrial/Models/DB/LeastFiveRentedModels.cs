using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewDesignTrial.Models.DB
{
    public class LeastFiveRentedModels
    {
        [Key]
        public int ModelID { get; set; }
        public string Model { get; set; }
        public decimal Total { get; set; }

    }
}
