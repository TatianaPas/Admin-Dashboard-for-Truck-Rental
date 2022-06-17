using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace NewDesignTrial.Models.DB
{
    public class Total
    {
        [Key]
        public int ID { get; set; }
        public decimal TotalPrice { get; set; } = 0;    
    }
}
