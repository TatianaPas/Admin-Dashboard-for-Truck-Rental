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

    //---------->Customers

    //----------> And new customer
        public static void addCustomer(TruckCustomer cust)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.TruckCustomers.Add(cust);
                ctx.SaveChanges();
            }
        }

    //----------> Get customer details including personal details
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
    //----------> Find customer with personal details by his full name
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

     //----------> Find customer by his id
        public static TruckCustomer findCustomerById(int id)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
                return ctx.TruckCustomers.Include(p => p.Customer).Where(cust => cust.CustomerId == id).FirstOrDefault();

        }

    //----------> Find customer by his Driving License number
        public static TruckCustomer findCustomerByLicenseNumber(string license)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
                return ctx.TruckCustomers.Include(p => p.Customer).Where(cust => cust.LicenseNumber == license).FirstOrDefault();

        }

     //----------> Update Customer details
        public static void updateCustomer(TruckCustomer cust, TruckPerson tp)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.Entry(cust).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(tp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }


    //----------> Trucks

    //----------> Add a new truck including a new model
        public static void addTruck(IndividualTruck truck,List<TruckFeature> features)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.IndividualTrucks.Add(truck);
                ctx.SaveChanges();
                int id = truck.TruckId;

                if(features != null)
                {
                    foreach (var feature in features)
                    {
                        truck.Features.Add(feature);
                    }
                }
                ctx.SaveChanges();
            }
        }

    //----------> Add a new truck with existing model ( reorder same model)
        public static void reorderTruck(IndividualTruck it, List<TruckFeature> features)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.IndividualTrucks.Add(it);
                ctx.Entry(it.TruckModel).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                ctx.SaveChanges();
                int id = it.TruckId;

                if (features != null)
                {
                    foreach (var feature in features)
                    {
                        it.Features.Add(feature);
                    }
                }
                ctx.SaveChanges();
            }
        }

    //----------> Find truck by ID
        public static IndividualTruck findTruckById(int id)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.IndividualTrucks.Include(i => i.TruckModel).Where(it => it.TruckId == id).FirstOrDefault();
            }
        }

    //----------> Find truck by registration number
        public static IndividualTruck findTruckByRego(string rego)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.IndividualTrucks.Include(i => i.TruckModel).Where(it => it.RegistrationNumber == rego).FirstOrDefault();
            }
        }
    //----------> Update Truck details
        public static void updateTruck(IndividualTruck truck, TruckModel model)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.Entry(truck).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                ctx.SaveChanges();
            }
        }

       


        //----------> Find all trucks
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

     //----------> Find only available for rent trucks

        public static List<TrucksModelFeatures> getAvailableTrucks()
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.IndividualTrucks.Include(i => i.TruckModel).Where(st => st.Status == "available for rent").Select(
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

    //----------> Find all rented out trucks
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

     //----------> Change truck status ( used for truck renting)

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
     //----------> Truck Models

     //----------> Get all truck models
        public static List<TruckModel> getModels()
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckModels.ToList();
            }
        }

    //----------> Search Truck model by model name
        public static TruckModel searchModelByName(string name)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckModels.Where(tm => tm.Model == name).FirstOrDefault();
            }
        }

       

        //----------> Truck Features
        //----------> Find Feature by ID
        public static TruckFeature findFeatureById(int id)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckFeatures.Where(tf => tf.FeatureId == id).FirstOrDefault();
            }
        }

        //----------> Find Feature by name
        public static TruckFeature findFeatureByName(string feature)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckFeatures.Where(tf => tf.Description == feature).FirstOrDefault();
            }
        }
        //----------> Get list of features of the specific truck by truck ID
        public static List<TruckFeature> getTruckFeaturesById(int id)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckFeatures.Where(i => i.Trucks.Any(i => i.TruckId == id)).ToList();
            }
        }

    //----------> Get all features
        public static List<TruckFeature> getAllFeatures()
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckFeatures.ToList();
            }
        }

        //----------> Add new feature to the feature list
        public static void addFeature(TruckFeature feature)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.TruckFeatures.Add(feature);
                ctx.SaveChanges();
            }
        }

        //---------->Employees
        //----------> Add a new employee
        public static void addEmployee(TruckEmployee te)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.TruckEmployees.Add(te);
                ctx.SaveChanges();
            }
        }

    //----------> Login validation ( used on the main window)
        public static TruckEmployee loginValidation(string username, string password)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckEmployees.Include(p => p.Employee).Where(emp => emp.Username == username && emp.Password == password).FirstOrDefault();
            }
        }

    //---------->  Search contact details of any person in the system

        public static TruckPerson searchContact(int id)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.TruckPeople.Where(p => p.PersonId == id).FirstOrDefault();
            }
        }
    //----------> Get all employees including their personal details
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

    //----------> Find employee by his ID
        public static TruckEmployee findEmployeeById(int id)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
                return ctx.TruckEmployees.Include(p => p.Employee).Where(emp => emp.EmployeeId == id).FirstOrDefault();

        }

    //----------> Find employee by his full name
        public static TruckEmployee findEmployeeByName(string name)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
                return ctx.TruckEmployees.Include(p => p.Employee).Where(emp => emp.Employee.Name == name).FirstOrDefault();

        }

    //----------> Update employee details

        public static void updateEmployee(TruckEmployee te, TruckPerson tp)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.Entry(te).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(tp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }

    //----------> Logged in employee can update some of his details

        public static void updatePersonalDetails(TruckEmployee emp, TruckPerson tp)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(tp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }



     //----------> Rentals
     //----------> Rent truck 

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
