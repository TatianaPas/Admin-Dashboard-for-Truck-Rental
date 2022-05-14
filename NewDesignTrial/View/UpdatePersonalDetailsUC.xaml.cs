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
    }
}
