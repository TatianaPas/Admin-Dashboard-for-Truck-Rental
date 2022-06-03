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
    /// Interaction logic for addEmployee.xaml
    /// </summary>
    public partial class addEmployee : UserControl
    {
        public addEmployee()
        {
            InitializeComponent();
        }
// initialise text fields
        private string fullName = "";
        private string address = "";
        private string telephone = "";
        private string officeAddress = "";
        private string phoneExtension = "";
        private string username = "";
        private string password = "";
        private string role = "";

// Add Employee button clicked
        private void addEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {


            if (nameTextBox.Text.Length <= 3)
            {
                MessageBox.Show("Please enter Employees Full Name ");
                return;
            }
            else
            {
                fullName = nameTextBox.Text;
            }
            if (addressTextBox.Text.Length <= 3)
            {
                MessageBox.Show("Please enter Employee's Address ");
                return;
            }
            else
            {
                address = addressTextBox.Text;
            }

            if (telephoneTextBox.Text.Length <= 6)
            {
                MessageBox.Show("Please enter Employee's Telephone Number ");
                return;
            }
            else
            {
                telephone = telephoneTextBox.Text;
            }

            if (officeAddressTextBox.Text.Length <= 4)
            {
                MessageBox.Show("Please enter Office Address ");
                return;
            }
            else
            {
                officeAddress = officeAddressTextBox.Text;
            }

            if (phoneExtensionTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Please enter phone extension");
                return;
            }
            else
            {
                phoneExtension = phoneExtensionTextBox.Text;
            }

// data validated inside the class TruckEmployee

                username = usernameTextBox.Text;
                password = passwordTextBox.Text;
           
            role = roleComboBox.Text;
// create object of Truck Person
            TruckPerson tp = new TruckPerson();
            tp.Name = fullName;
            tp.Address = address;
            tp.Telephone = telephone;
// create object of truck employee
            TruckEmployee te= new TruckEmployee();
            te.OfficeAddress = officeAddress;
            te.PhoneExtensionNumber= phoneExtension;
            te.Username= username;
            te.Password= password;
            te.Role = role;
            te.Employee = tp;



                DAO.addEmployee(te);
                MessageBox.Show("Employee added succesfully");
// clear text fields after employee added
                nameTextBox.Clear();
                addressTextBox.Clear();
                telephoneTextBox.Clear();
                officeAddressTextBox.Clear();
                phoneExtensionTextBox.Clear();
                usernameTextBox.Clear();
                passwordTextBox.Clear();
                roleComboBox.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
