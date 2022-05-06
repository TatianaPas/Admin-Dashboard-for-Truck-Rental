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
    /// Interaction logic for addCustomer.xaml
    /// </summary>
    public partial class addCustomer : UserControl
    {
        public addCustomer()
        {
            InitializeComponent();
        }
        private string fullName = "";
        private string address = "";
        private string telephone = "";
        string licenseNumber = "";
        string age = "";
        string licenseExpiryDate = "";
        int CustomerAge = 0;

        private void addCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            if(nameTextBox.Text.Length<=3)
            {
                MessageBox.Show("Please enter Customer Full Name ");
                return;
            }
            else
            {
                fullName = nameTextBox.Text;
            }
            if (addressTextBox.Text.Length <= 3)
            {
                MessageBox.Show("Please enter Customer's Address ");
                return;
            }
            else
            {
                address = addressTextBox.Text;
            }

            if(telephoneTextBox.Text.Length<=6)
            {
                MessageBox.Show("Please enter Customer's Telephone Number ");
                return;
            }
            else
            {
                telephone = telephoneTextBox.Text;
            }
            if (licenseNumberTextBox.Text.Length <= 3)
            {
                MessageBox.Show("Please enter Customer's License Number ");
                return;
            }
            else
            {
                licenseNumber = licenseNumberTextBox.Text;
            }
            if (ageTextBox.Text.Length <=1 )
            {
                MessageBox.Show("Please enter Customer's Age ");
                return;
            }
            else
            {
                int ageCheck = int.Parse(ageTextBox.Text);
                if (ageCheck < 18)
                {
                    MessageBox.Show("Only Customers over 18 years old can rent a truck");
                    return;
                }
                else
                {
                    int CustomerAge = int.Parse(ageTextBox.Text);
                }
            }

            if (licenseExpiryDatePicker.Text.Length <= 0)
            {
                MessageBox.Show("Please enter License Expiry Date ");
                return;
            }
            else
            {
                licenseExpiryDate = licenseExpiryDatePicker.Text;
            }


          

            TruckPerson tp= new TruckPerson();
            tp.Name = fullName;
            tp.Address = address;
            tp.Telephone = telephone;

            TruckCustomer tc = new TruckCustomer();
            tc.LicenseNumber = licenseNumber;
            tc.LicenseExpiryDate =DateTime.Parse(licenseExpiryDate);
            tc.Age = CustomerAge;
            tc.Customer = tp;

            try
            {
                DAO.addCustomer(tc);
                MessageBox.Show("Customer added succesfully");
                nameTextBox.Clear();
                addressTextBox.Clear();
                telephoneTextBox.Clear();
                licenseNumberTextBox.Clear();
                ageTextBox.Clear();
                licenseExpiryDatePicker.SelectedDate=DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }







        }
    }
}
