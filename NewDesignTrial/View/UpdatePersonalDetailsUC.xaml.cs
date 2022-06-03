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
    /// Interaction logic for UpdatePersonalDetailsUC.xaml
    /// </summary>
    public partial class UpdatePersonalDetailsUC : UserControl
    {
        //pass Employee data from Main window

        TruckEmployee emp;
        public UpdatePersonalDetailsUC(TruckEmployee _emp)
        {
            InitializeComponent();
            emp = _emp;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //set data to the text boxes
            nameTextBox.Text = emp.Employee.Name;
            addressTextBox.Text = emp.Employee.Address;
            telephoneTextBox.Text = emp.Employee.Telephone;
            officeAddressTextBox.Text = emp.OfficeAddress;
            phoneExtensionTextBox.Text = emp.PhoneExtensionNumber;
            roleTextBox.Text = emp.Role;
            usernameTextBox.Text = emp.Username;
            passwordTextBox.Text = emp.Password;
        }

        private void updateDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TruckPerson tp = emp.Employee;

            if (addressTextBox.Text.Length <= 3)
            {
                MessageBox.Show("Please enter Employee's Address ");
                return;
            }
            else
            {
                tp.Address = addressTextBox.Text;
            }

            if (telephoneTextBox.Text.Length <= 6)
            {
                MessageBox.Show("Please enter Employee's Telephone Number ");
                return;
            }
            else
            {
                tp.Telephone = telephoneTextBox.Text;
            }
           
                emp.Password = passwordTextBox.Text;
            
            tp.Name = nameTextBox.Text;
            emp.Role = roleTextBox.Text;
            emp.Username= usernameTextBox.Text;
            emp.OfficeAddress = officeAddressTextBox.Text;
            emp.PhoneExtensionNumber = phoneExtensionTextBox.Text;
            
                DAO.updatePersonalDetails(emp, tp);
                MessageBox.Show("Your personal details updated succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            
        }
    }
}
