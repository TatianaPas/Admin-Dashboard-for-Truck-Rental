using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewDesignTrial.Models.DB;

namespace NewDesignTrial.Models
{
    internal class DAO
    {
        public static void addCustomer( TruckCustomer cust)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.TruckCustomers.Add(cust);
                ctx.SaveChanges();
            }
        }

        public static void addEmployee(TruckEmployee te)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.TruckEmployees.Add(te);
                ctx.SaveChanges();
            }
        }



    }
}
