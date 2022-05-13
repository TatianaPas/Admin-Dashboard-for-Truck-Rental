using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewDesignTrial.Models.DB;

namespace NewDesignTrial.Models
{
    internal class DAO
    {
        public static void addCustomer(TruckCustomer cust)
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

        public static TruckEmployee loginValidation(string username, string password)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckEmployees.Where(emp => emp.Username == username && emp.Password == password).FirstOrDefault();
            }
        }


        public static TruckPerson searchContact(int id)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckPeople.Where(p => p.PersonId == id).FirstOrDefault();
            }
        }

        public static List<TruckEmployeeWithName> getEmployees()
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckEmployees.Include(p => p.Employee).Select(
                    te => new TruckEmployeeWithName()
                    {
                        EmployeeId = te.EmployeeId,
                        Name = te.Employee.Name,
                        Address = te.Employee.Address,
                        Telephone = te.Employee.Telephone,
                        OfficeAddress = te.OfficeAddress,
                        PhoneExtensionNumber = te.PhoneExtensionNumber,
                        Username = te.Username,
                        Password = te.Password
                    }).ToList();
            }
        }
        public static List<TruckCustomerWithName> getCustomers()
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckCustomers.Include(p => p.Customer).Select(
                    te => new TruckCustomerWithName()
                    {
                        CustomerId = te.CustomerId,
                        Name = te.Customer.Name,
                        Address = te.Customer.Address,
                        Telephone = te.Customer.Telephone,
                        LicenseNumber = te.LicenseNumber,
                        Age = te.Age,
                        LicenseExpiryDate = te.LicenseExpiryDate

                    }).ToList();
            }
        }

        public static TruckCustomer findCustomerById(int id)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
                return ctx.TruckCustomers.Include(p => p.Customer).Where(cust => cust.CustomerId == id).FirstOrDefault();

        }

        public static TruckCustomer findCustomerByLicenseNumber(string license)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
                return ctx.TruckCustomers.Include(p => p.Customer).Where(cust => cust.LicenseNumber == license).FirstOrDefault();

        }

        public static void updateCustomer(TruckCustomer cust, TruckPerson tp)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            { 
                ctx.Entry(cust).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(tp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
