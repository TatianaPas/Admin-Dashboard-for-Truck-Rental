using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewDesignTrial.Models.DB;
using NewDesignTrial.Models;

namespace NewDesignTrial.View
{
    /// <summary>
    /// Interaction logic for RentTruck.xaml
    /// </summary>
    public partial class RentTruck : UserControl
    {
        public RentTruck()
        {
// set data in customers name combobox and in truck registration combobox
            InitializeComponent();
            nameComboBox.ItemsSource = DAO.getCustomers();
            nameComboBox.DisplayMemberPath = "Name";
            registrationComboBox.ItemsSource = DAO.getAvailableTrucks();
            registrationComboBox.DisplayMemberPath = "RegistrationNumber";


            //linked value to the combobox
            nameComboBox.SelectedValuePath = "Name";
            registrationComboBox.SelectedValuePath = "RegistrationNumber";
        }
// if customer name was choosen, combobox will display license number (in case if there more than 1 customer with same name)
        private void nameComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string customerName = nameComboBox.Text;
            licenseComboBox.ItemsSource = DAO.findCustomersByName(customerName);
            licenseComboBox.DisplayMemberPath = "LicenseNumber";
            licenseComboBox.SelectedValuePath = "LicenseNumber";
        }
// set rent day to today
        private void rentTruckWindow_Loaded(object sender, RoutedEventArgs e)
        {
            rentDayDatePicker.SelectedDate = DateTime.Today;
            
        }
// set data of the selected truck
        private void registrationComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string registration = registrationComboBox.Text;
            if(registration !=null)
            {
                string deposit = string.Format("{0:F2}", DAO.findTruckByRego(registration).AdvanceDepositRequired);
                DepositTextBox.Text = deposit;
            }
            
        }

        private void rentDayDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(rentDayDatePicker.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please select correct day");
                return;
            }
        }
// chek if due back day correct
        private void dueBackDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dueBackDatePicker.SelectedDate < DateTime.Today && dueBackDatePicker.SelectedDate < rentDayDatePicker.SelectedDate)
            {
                MessageBox.Show("Please select correct day");
                return;
            }
            else
            {
                string registration = registrationComboBox.Text;
                double price = (double)DAO.findTruckByRego(registration).DailyRentalPrice;
                DateTime rentDate = DateTime.Parse(rentDayDatePicker.SelectedDate.ToString());
                DateTime rentDue = DateTime.Parse(dueBackDatePicker.SelectedDate.ToString());
                int days = (int)(rentDue - rentDate).TotalDays;
                if(rentDue==rentDate)
                {
                    days = 1;
                }
                double totalPrice = days * price;

                TotalPriceTextBox.Text =totalPrice.ToString();
            }
        }
// rent truck button pressed
        private void rentTruckBtn_Click_1(object sender, RoutedEventArgs e)
        {
            string registration = registrationComboBox.Text;
            string license = licenseComboBox.Text;

            int truckId = DAO.findTruckByRego(registration).TruckId;
            int CustomerID = DAO.findCustomerByLicenseNumber(license).CustomerId;
            DateTime rentDate = DateTime.Parse(rentDayDatePicker.SelectedDate.ToString());
            DateTime rentDue = DateTime.Parse(dueBackDatePicker.SelectedDate.ToString());
            decimal totalPrice = decimal.Parse(TotalPriceTextBox.Text);

// create object of truck rental
            TruckRental tr = new TruckRental();
            tr.TruckId = truckId;
            tr.CustomerId=CustomerID;
            tr.RentDate=rentDate;
            tr.ReturnDueDate=rentDue;
            tr.TotalPrice=totalPrice;
            

            try
            {
                DAO.rentTruck(tr, truckId);               
                MessageBox.Show("Truck rented succesfully");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
    }
}
