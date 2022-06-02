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
    /// Interaction logic for RentalsByDateUC.xaml
    /// </summary>
    public partial class RentalsByDateUC : UserControl
    {
        public RentalsByDateUC()
        {
            InitializeComponent();
        }

        private void showRentalsBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = startDatePicker.SelectedDate.Value;
            DateTime endDate= endDatePicker.SelectedDate.Value;
            try
            {
                List<TruckRentalsWithCustomerName> rentals=DAO.getRentalsBetweenDates(startDate, endDate);
                if (rentals.Count() > 0)
                {
                    truckRentalsDataGrid.ItemsSource = rentals;
                    truckRentalsDataGrid.Columns[0].Header = " Rent ID ";
                    truckRentalsDataGrid.Columns[1].Header = " Truck";
                    truckRentalsDataGrid.Columns[2].Header = "Customer";
                    truckRentalsDataGrid.Columns[3].Header = "Rent Date";
                    truckRentalsDataGrid.Columns[4].Header = "Return Due";
                    truckRentalsDataGrid.Columns[5].Header = "Returned";
                    truckRentalsDataGrid.Columns[6].Header = "Total Price";
 
                }
                else
                {
                    MessageBox.Show("No records found");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
