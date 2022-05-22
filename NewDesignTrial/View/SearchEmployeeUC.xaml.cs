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
    /// Interaction logic for SearchEmployeeUC.xaml
    /// </summary>
    public partial class SearchEmployeeUC : UserControl
    {
        public SearchEmployeeUC()
        {
            InitializeComponent();
        }

        private void showEmployeeBtn_Click(object sender, RoutedEventArgs e)
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
                        TruckEmployee te = DAO.findEmployeeById(id);
                        if (te != null)
                        {
                            idTextBox.Text = te.EmployeeId.ToString();
                            nameTextBox.Text = te.Employee.Name;
                            addressTextBox.Text = te.Employee.Address;
                            officeAddressTextBox.Text = te.OfficeAddress;
                            phoneExtensionTextBox.Text = te.PhoneExtensionNumber;
                            roleTextBox.Text = te.Role;
                            passwordTextBox.Text = te.Password;
                            telephoneTextBox.Text = te.Employee.Telephone;
                            usernametextBox.Text = te.Username;
                            employeeGridInfo.Visibility = Visibility.Visible;
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
                else if(choice =="Full Name")
                {
                    string name=inputTextBox.Text;
                    TruckEmployee te = DAO.findEmployeeByName(name);
                    if (te != null)
                    {
                        idTextBox.Text = te.EmployeeId.ToString();
                        nameTextBox.Text = te.Employee.Name;
                        addressTextBox.Text = te.Employee.Address;
                        officeAddressTextBox.Text = te.OfficeAddress;
                        phoneExtensionTextBox.Text = te.PhoneExtensionNumber;
                        roleTextBox.Text = te.Role;
                        passwordTextBox.Text = te.Password;
                        telephoneTextBox.Text = te.Employee.Telephone;
                        usernametextBox.Text = te.Username;
                        employeeGridInfo.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Sorry, no data found");
                        return;
                    }
                }
            }
        }

        private void searchComboBox_DropDownOpened(object sender, EventArgs e)
        {
            employeeGridInfo.Visibility = Visibility.Hidden;
            inputTextBox.Text = "";
        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            employeeGridInfo.Visibility = Visibility.Hidden;
        }
    }
}
