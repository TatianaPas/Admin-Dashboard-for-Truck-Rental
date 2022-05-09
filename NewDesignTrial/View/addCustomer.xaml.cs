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
        string licenseExpiryDate = "";
        int age = 0;


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

            //check if age entered as number

            string checkAge = ageTextBox.Text;
            int value;
            if(int.TryParse(checkAge, out value))
            {     
                int age=int.Parse(checkAge);
                if (age <18)
                {
                    MessageBox.Show("Only Customers over 18 years old can rent a truck");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please enter correct Age ");
                return;
            }


            if (licenseExpiryDatePicker.Text.Length <= 0)
            {
                MessageBox.Show("Please enter License Expiry Date ");
                return;
            }else
            {
                licenseExpiryDate = licenseExpiryDatePicker.Text;

                //check if license is not expired

                DateTime date1= DateTime.Parse(licenseExpiryDate);
                DateTime date2 = DateTime.Today;
                int result = DateTime.Compare(date1, date2);
                if(result<0)
                {
                    MessageBox.Show ("License is not valid. Please provide another license ");
                    return;
                }

            }

            TruckPerson tp= new TruckPerson();
            tp.Name = fullName;
            tp.Address = address;
            tp.Telephone = telephone;

            TruckCustomer tc = new TruckCustomer();
            tc.LicenseNumber = licenseNumber;
            tc.LicenseExpiryDate =DateTime.Parse(licenseExpiryDate);
            tc.Age = age;
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
