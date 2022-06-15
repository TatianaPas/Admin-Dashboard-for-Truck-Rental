using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewDesignTrial.Models.DB
{
    public class TopFiveTrucks
    {
        [Key]
        public int ID{ get; set; }
        public string Registration { get; set; } = null!;
        public decimal Total { get; set; }

    }
}
