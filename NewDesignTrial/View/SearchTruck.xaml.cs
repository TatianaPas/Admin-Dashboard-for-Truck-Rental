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
    /// Interaction logic for SearchTruck.xaml
    /// </summary>
    public partial class SearchTruck : UserControl
    {
        public SearchTruck()
        {
            InitializeComponent();
            registrationComboBox.ItemsSource = DAO.getAllTrucks();
            registrationComboBox.DisplayMemberPath = "RegistrationNumber";
            //linked value to the combobox
            registrationComboBox.SelectedValuePath = "RegistrationNumber";
        }

        private void showTruckBtn_Click(object sender, RoutedEventArgs e)
        {
            string truckRego = registrationComboBox.Text;
            if (truckRego.Length == 0)
            {
                MessageBox.Show("Please choose truck registration number");
                return;
            }
            else
            {
                IndividualTruck truck = DAO.findTruckByRego(truckRego);

                if (truck != null)
                {
                    autoGrid.Visibility = Visibility.Visible;
                    
                    modelTextBox.Text = truck.TruckModel.Model;
                    manufacturerTextBox.Text = truck.TruckModel.Manufacturer;
                    sizeComboBox.Text = truck.TruckModel.Size;
                    numberOfSeatsTextBox.Text = truck.TruckModel.Seats.ToString();
                    numberOfDoorsTextBox.Text = truck.TruckModel.Doors.ToString();
                    colorTextBox.Text = truck.Colour;
                    WOFExpiryDatePicker.Text = truck.WofexpiryDate.ToString();
                    REGOExpiryDatePicker.Text=truck.RegistrationExpiryDate.ToString();
                    yearOfManufactureTextBox.Text = truck.ManufactureYear.ToString();
                    dateImportedDatePicker.Text = truck.DateImported.ToString();
                    statusComboBox.Text = truck.Status; 
                    fuelTypeComboBox.Text = truck.FuelType;
                    transmissionComboBox.Text = truck.Transmission;
                    depositPriceTextBox.Text = string.Format("{0:F2}", truck.AdvanceDepositRequired);
                    rentalPriceTextBox.Text = string.Format("{0:F2}", truck.DailyRentalPrice);
                    int truckId = truck.TruckId;
                    List<TruckFeature> features = DAO.getTruckFeaturesById(truckId);
                    if (features.Count != 0)
                    {
                        featureList.ItemsSource = features;
                        featureList.Visibility=Visibility.Visible;
                        extraFeaturesLabel.Visibility=Visibility.Visible;   
                    }
                }
                else
                {
                    MessageBox.Show("No data found");
                    return;
                }
            }
        }

        private void registrationComboBox_DropDownClosed(object sender, EventArgs e)
        {
            autoGrid.Visibility = Visibility.Collapsed;
        }

        private void updateTruckBtn_Click(object sender, RoutedEventArgs e)
        {
            string truckRego = registrationComboBox.Text;
            IndividualTruck truck = DAO.findTruckByRego(truckRego);
            truck.Status = statusComboBox.Text;
            truck.WofexpiryDate = DateTime.Parse(WOFExpiryDatePicker.Text);
            truck.RegistrationExpiryDate = DateTime.Parse(REGOExpiryDatePicker.Text);
            truck.DailyRentalPrice = decimal.Parse(rentalPriceTextBox.Text);
            truck.AdvanceDepositRequired = decimal.Parse(depositPriceTextBox.Text);
            TruckModel model = truck.TruckModel;

            try
            {
                DAO.updateTruck(truck, model);
                MessageBox.Show("Truck details updated sucessfully");
                autoGrid.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
