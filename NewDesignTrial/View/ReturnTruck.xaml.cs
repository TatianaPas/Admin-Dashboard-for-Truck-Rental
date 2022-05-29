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
    /// Interaction logic for ReturnTruck.xaml
    /// </summary>
    public partial class ReturnTruck : UserControl
    {
        public ReturnTruck()
        {
            InitializeComponent();
            registrationComboBox.ItemsSource = DAO.getRentedTrucks();
            registrationComboBox.DisplayMemberPath = "RegistrationNumber";
            registrationComboBox.SelectedValuePath = "RegistrationNumber";
        }

        private void retunrTruckWindow_Loaded(object sender, RoutedEventArgs e)
        {
            returnedDatePicker.SelectedDate = DateTime.Today;
        }

        private void returnedDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (returnedDatePicker.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please select correct day");
                return;
            }
            //else if {returnedDatePicker.SelectedDate == )}
        }

        private void registrationComboBox_DropDownClosed(object sender, EventArgs e)
        {
            
        }
    }
}
