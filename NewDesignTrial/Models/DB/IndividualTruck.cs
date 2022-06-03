using System;
using System.Collections.Generic;

namespace NewDesignTrial.Models.DB
{
    public partial class IndividualTruck
    {
        public IndividualTruck()
        {
            TruckRentals = new HashSet<TruckRental>();
            Features = new HashSet<TruckFeature>();
        }

        public int TruckId { get; set; }
        public string Colour { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;

        private DateTime wofexpiry;
        public DateTime WofexpiryDate
        {
            get { return wofexpiry; }
            set
            {
                if(value <DateTime.Today)
                {
                    throw new Exception("Please enter correct warant of fitness expiry date");
                }
                else
                {
                    this.wofexpiry = value;
                }
            }
        }
        private DateTime registrationExpiry;
        public DateTime RegistrationExpiryDate
        {
            get { return registrationExpiry; }
            set
            {
                if (value < DateTime.Today)
                {
                    throw new Exception("Please enter correct registration expiry date");
                }
                else
                {
                    this.registrationExpiry = value;
                }

            }
        }
        private DateTime dateImported;
        public DateTime DateImported
        {
            get { return dateImported; }
            set
            {
                if(value > DateTime.Today)
                {
                    throw new Exception("Please enter correct import date");
                }
                else
                {
                    this.dateImported = value;
                }
            }
        }
        private int manufactureYear;
        public int ManufactureYear
        {
            get { return manufactureYear; }
            set
            {
                if(value<=DateTime.Now.Year)
                {
                    this.manufactureYear = value;
                }
                else
                {
                    throw new Exception("Please enter correct year of manufacture");
                }
            }
        }
        public string Status { get; set; } = null!;
        public string FuelType { get; set; } = null!;
        public string Transmission { get; set; } = null!;
        private decimal dailyRent;
        public decimal DailyRentalPrice
        {
            get { return dailyRent; }
            set
            {
                if (value >= 50 && value<500)
                {
                    this.dailyRent = value;
                }
                else
                {
                    throw new Exception("Daily rent can be between 50 and 500 nzd");

                }
            }
        }

        private decimal deposit;
        public decimal AdvanceDepositRequired
        {
            get { return deposit; }
            set
            {
                if (value >= 50 && value < 1000)
                {
                    this.deposit = value;
                }
                else
                {
                    throw new Exception("Deposit can be between 50 and 500 nzd");
                }
            }

        }
        public int TruckModelId { get; set; }

        public virtual TruckModel TruckModel { get; set; } = null!;
        public virtual ICollection<TruckRental> TruckRentals { get; set; }

        public virtual ICollection<TruckFeature> Features { get; set; }
    }
}
