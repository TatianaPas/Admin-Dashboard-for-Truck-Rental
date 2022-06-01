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
            InitializeComponent();
            nameComboBox.ItemsSource = DAO.getCustomers();
            nameComboBox.DisplayMemberPath = "Name";
            registrationComboBox.ItemsSource = DAO.getAvailableTrucks();
            registrationComboBox.DisplayMemberPath = "RegistrationNumber";


            //linked value to the combobox
            nameComboBox.SelectedValuePath = "Name";
            registrationComboBox.SelectedValuePath = "RegistrationNumber";
        }

        private void nameComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string customerName = nameComboBox.Text;
            licenseComboBox.ItemsSource = DAO.findCustomersByName(customerName);
            licenseComboBox.DisplayMemberPath = "LicenseNumber";
            licenseComboBox.SelectedValuePath = "LicenseNumber";
        }

        private void rentTruckWindow_Loaded(object sender, RoutedEventArgs e)
        {
            rentDayDatePicker.SelectedDate = DateTime.Today;
            
        }

        private void registrationComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string registration = registrationComboBox.Text;
            string deposit = string.Format("{0:F2}", DAO.findTruckByRego(registration).AdvanceDepositRequired);
            DepositTextBox.Text = deposit;
        }

        private void rentDayDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(rentDayDatePicker.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please select correct day");
                return;
            }
        }

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

        private void rentTruckBtn_Click_1(object sender, RoutedEventArgs e)
        {
            string registration = registrationComboBox.Text;
            string license = licenseComboBox.Text;

            int truckId = DAO.findTruckByRego(registration).TruckId;
            int CustomerID = DAO.findCustomerByLicenseNumber(license).CustomerId;
            DateTime rentDate = DateTime.Parse(rentDayDatePicker.SelectedDate.ToString());
            DateTime rentDue = DateTime.Parse(dueBackDatePicker.SelectedDate.ToString());
            decimal totalPrice = decimal.Parse(TotalPriceTextBox.Text);

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
