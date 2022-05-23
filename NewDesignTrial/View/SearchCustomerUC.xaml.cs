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
using System.Globalization;

namespace NewDesignTrial.View
{
    /// <summary>
    /// Interaction logic for SearchCustomerUC.xaml
    /// </summary>
    public partial class SearchCustomerUC : UserControl
    {
        public SearchCustomerUC()
        {
            InitializeComponent();
        }

        private void showCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            string input = inputTextBox.Text;
            string choice = searchComboBox.Text;
            if (input.Length == 0)
            {
                MessageBox.Show("Please enter search criteria");
                return;
            }
            else
            {
                if (choice == "ID")
                {
                    string checkId = inputTextBox.Text;
                    int value;
                    if (int.TryParse(checkId, out value))
                    {
                        int id = int.Parse(checkId);
                        TruckCustomer cust = DAO.findCustomerById(id);
                        if (cust != null)
                        {
                            idTextBox.Text = cust.CustomerId.ToString();
                            nameTextBox.Text = cust.Customer.Name;
                            addressTextBox.Text = cust.Customer.Address;
                            telephoneTextBox.Text = cust.Customer.Telephone;
                            ageTextBox.Text = cust.Age.ToString();
                            licenseNumberTextBox.Text = cust.LicenseNumber;
                            licenseExpiryDateDP.SelectedDate = cust.LicenseExpiryDate;
                            customerGridInfo.Visibility = Visibility.Visible;

                        }
                        else
                        {
                            MessageBox.Show("Sorry, no data found");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter ID in correct format");
                    }
                }
                if(choice == "License Number")
                {
                    string licenseNumber = inputTextBox.Text;
                    TruckCustomer cust = DAO.findCustomerByLicenseNumber(licenseNumber);
                    if (cust != null)
                    {
                        idTextBox.Text = cust.CustomerId.ToString();
                        nameTextBox.Text = cust.Customer.Name;
                        addressTextBox.Text = cust.Customer.Address;
                        telephoneTextBox.Text = cust.Customer.Telephone;
                        ageTextBox.Text = cust.Age.ToString();
                        licenseNumberTextBox.Text = cust.LicenseNumber;
                        licenseExpiryDateDP.Text = cust.LicenseExpiryDate.ToString("dd-MM-yyyy");
                        customerGridInfo.Visibility = Visibility.Visible;

                    }
                    else
                    {
                        MessageBox.Show("Sorry, no data found");
                        return;
                    }

                }

            }
        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            customerGridInfo.Visibility = Visibility.Hidden;
        }

        private void updateCustomerDetails_Click(object sender, RoutedEventArgs e)
        {
            int id= int.Parse(idTextBox.Text);
            string name = nameTextBox.Text;
            string address = "";
            string telephone = "";
            string licenseNumber = "";
            string licenseExpiryDate = "";
            int age = 0;


            if (addressTextBox.Text.Length <= 3)
            {
                MessageBox.Show("Please enter Customer's Address ");
                return;
            }
            else
            {
                address = addressTextBox.Text;
            }

            if (telephoneTextBox.Text.Length <= 6)
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
            if (int.TryParse(checkAge, out value))
            {
                 age = int.Parse(checkAge);
                if (age < 18)
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


            if (licenseExpiryDateDP.Text.Length <= 0)
            {
                MessageBox.Show("Please enter License Expiry Date ");
                return;
            }
            else
            {

                licenseExpiryDate = licenseExpiryDateDP.Text;

                //check if license is not expired

                DateTime date1 = DateTime.Parse(licenseExpiryDate);
                DateTime date2 = DateTime.Today;
                    int result = DateTime.Compare(date1, date2);
                    if (result < 0)
                    {
                        MessageBox.Show("License is not valid. Please provide another license ");
                        return;
                    }
            }

                TruckCustomer cust = DAO.findCustomerById(id);
                 

                cust.LicenseNumber = licenseNumber;
                cust.LicenseExpiryDate = DateTime.Parse(licenseExpiryDate);
            cust.Age = age;

                TruckPerson tp = cust.Customer;
                tp.Address = address;
                tp.Telephone = telephone;
                tp.Name = name;

            try
            {
                DAO.updateCustomer(cust, tp);
                MessageBox.Show("Customer updated succesfully");             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void searchComboBox_DropDownOpened(object sender, EventArgs e)
        {
            customerGridInfo.Visibility = Visibility.Hidden;
            inputTextBox.Text = "";
        }
    }
}
