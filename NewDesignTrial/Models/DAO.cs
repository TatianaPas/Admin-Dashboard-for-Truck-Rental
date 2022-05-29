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

        //Customers

        public static void addCustomer(TruckCustomer cust)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.TruckCustomers.Add(cust);
                ctx.SaveChanges();
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
                        LicenseExpiryDate = te.LicenseExpiryDate.ToString("dd/MM/yyyy"),

                    }).ToList();
            }
        }

        public static List<TruckCustomerWithName> findCustomersByName(string name)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckCustomers.Include(p => p.Customer).Where(tc=>tc.Customer.Name==name).Select(
                    te => new TruckCustomerWithName()
                    {
                        CustomerId = te.CustomerId,
                        Name = te.Customer.Name,
                        Address = te.Customer.Address,
                        Telephone = te.Customer.Telephone,
                        LicenseNumber = te.LicenseNumber,
                        Age = te.Age,
                        LicenseExpiryDate = te.LicenseExpiryDate.ToString("dd/MM/yyyy"),
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


        //Trucks
        public static void addTruck(IndividualTruck it)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.IndividualTrucks.Add(it);
                ctx.SaveChanges();
            }
        }

        public static TruckFeature findFeature(int id)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckFeatures.Where(tf => tf.FeatureId == id).FirstOrDefault();
            }
        }

        public static IndividualTruck findTruck(int id)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.IndividualTrucks.Where(it => it.TruckId == id).FirstOrDefault();
            }
        }

        public static void addFeature(int id, TruckFeature tf)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                IndividualTruck it = findTruck(id);
                it.Features.Add(tf);
                ctx.SaveChanges();
            }

        }

        public static List<TrucksModelFeatures> getAllTrucks()
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.IndividualTrucks.Include(i => i.TruckModel).Select(
                    it => new TrucksModelFeatures()
                    {
                        TruckId = it.TruckId,
                        RegistrationNumber = it.RegistrationNumber,
                        Model = it.TruckModel.Model,
                        Size = it.TruckModel.Size,
                        WofexpiryDate=it.WofexpiryDate.ToString("dd/MM/yyyy"),
                        RegistrationExpiryDate = it.RegistrationExpiryDate.ToString("dd/MM/yyyy"),
                        ManufactureYear=it.ManufactureYear,
                        FuelType=it.FuelType,
                        Transmission=it.Transmission,
                        DailyRentalPrice =string.Format("{0:F2}",it.DailyRentalPrice),
                        AdvanceDepositRequired=string.Format("{0:F2}",it.AdvanceDepositRequired),
                        Status=it.Status,
                    }).ToList();
            }
        }

        public static List<TrucksModelFeatures> getAvailableTrucks()
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.IndividualTrucks.Include(i => i.TruckModel).Where(st=>st.Status=="available for rent").Select(
                    it => new TrucksModelFeatures()
                    {
                        TruckId = it.TruckId,
                        RegistrationNumber = it.RegistrationNumber,
                        Model = it.TruckModel.Model,
                        Size = it.TruckModel.Size,
                        WofexpiryDate = it.WofexpiryDate.ToString("dd/MM/yyyy"),
                        RegistrationExpiryDate = it.RegistrationExpiryDate.ToString("dd/MM/yyyy"),
                        ManufactureYear = it.ManufactureYear,
                        FuelType = it.FuelType,
                        Transmission = it.Transmission,
                        DailyRentalPrice = string.Format("{0:F2}", it.DailyRentalPrice),
                        AdvanceDepositRequired = string.Format("{0:F2}", it.AdvanceDepositRequired),
                        Status = it.Status,
                    }).ToList();
            }
        }

        public static List<TrucksModelFeatures> getRentedTrucks()
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.IndividualTrucks.Include(i => i.TruckModel).Where(st => st.Status == "rented").Select(
                    it => new TrucksModelFeatures()
                    {
                        TruckId = it.TruckId,
                        RegistrationNumber = it.RegistrationNumber,
                        Model = it.TruckModel.Model,
                        Size = it.TruckModel.Size,
                        WofexpiryDate = it.WofexpiryDate.ToString("dd/MM/yyyy"),
                        RegistrationExpiryDate = it.RegistrationExpiryDate.ToString("dd/MM/yyyy"),
                        ManufactureYear = it.ManufactureYear,
                        FuelType = it.FuelType,
                        Transmission = it.Transmission,
                        DailyRentalPrice = string.Format("{0:F2}", it.DailyRentalPrice),
                        AdvanceDepositRequired = string.Format("{0:F2}", it.AdvanceDepositRequired),
                        Status = it.Status,
                    }).ToList();
            }
        }

        public static IndividualTruck searchTruckByRego (string rego)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.IndividualTrucks.Where(it => it.RegistrationNumber==rego).FirstOrDefault();
            }
        }

        private static void changeTruckStatus(int truckId)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                IndividualTruck it = ctx.IndividualTrucks.Where(it => it.TruckId == truckId).FirstOrDefault();
                if (it != null)
                {
                    it.Status = "rented";
                    ctx.SaveChanges();
                }
            }
        }



        //Employees
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
                return ctx.TruckEmployees.Include(p => p.Employee).Where(emp => emp.Username == username && emp.Password == password).FirstOrDefault();
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
                        Role = te.Role,
                        Telephone = te.Employee.Telephone,
                        OfficeAddress = te.OfficeAddress,
                        PhoneExtensionNumber = te.PhoneExtensionNumber,
                        Username = te.Username,
                        Password = te.Password,                      
                    }).ToList();
            }
        }
        

        public static TruckEmployee findEmployeeById(int id)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
                return ctx.TruckEmployees.Include(p => p.Employee).Where(emp => emp.EmployeeId == id).FirstOrDefault();

        }

        public static TruckEmployee findEmployeeByName(string name)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
                return ctx.TruckEmployees.Include(p => p.Employee).Where(emp => emp.Employee.Name == name).FirstOrDefault();

        }

        

        public static void updateEmployee(TruckEmployee te, TruckPerson tp)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.Entry(te).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(tp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public static void updatePersonalDetails(TruckEmployee emp, TruckPerson tp)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(tp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }



        // Rentals

        public static void rentTruck(TruckRental tr, int id)
        {
            id = tr.TruckId;
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.TruckRentals.Add(tr);
                changeTruckStatus(id);
                ctx.SaveChanges();
            }
        }

    }
}
