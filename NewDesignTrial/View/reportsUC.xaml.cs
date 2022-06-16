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
using NewDesignTrial.Models;
using NewDesignTrial.Models.DB;

namespace NewDesignTrial.View
{
    /// <summary>
    /// Interaction logic for reportsUC.xaml
    /// </summary>
    public partial class reportsUC : UserControl
    {
        public reportsUC()
        {
            InitializeComponent();

     // add selection of truck models into combobox to search rentals between specific dates
            modelComboBox.ItemsSource = DAO.getTruckModelsPB();
            modelComboBox.DisplayMemberPath = "Model";
            modelComboBox.SelectedValuePath = "Model";
        }

        private void topFiveTrucksBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gridTrucks.ItemsSource = DAO.getTopFiveTrucks();
                gridTrucks.Columns[0].Header = " Truck ID ";
                gridTrucks.Columns[1].Header = " Registration";
                gridTrucks.Columns[2].Header = " Total rent";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void leastFiveModelsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gridTrucks.ItemsSource = DAO.getLeastFiveRentedTruckModels();
                gridTrucks.Columns[0].Header = " Model ID ";
                gridTrucks.Columns[1].Header = " Model";
                gridTrucks.Columns[2].Header = " Total rent";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saleBetweenDates_Click(object sender, RoutedEventArgs e)
        {
            string model = modelComboBox.Text;
            DateTime startDate = startDatePicker.SelectedDate.Value;
            DateTime endDate = endDatePicker.SelectedDate.Value;
            try
            {
                gridTotal.ItemsSource= DAO.getTotalPriceForSelectedTruckModel(model, startDate, endDate);               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
