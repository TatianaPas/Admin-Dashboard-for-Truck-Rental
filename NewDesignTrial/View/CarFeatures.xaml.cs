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
    /// Interaction logic for Car_Features.xaml
    /// </summary>
    public partial class CarFeatures : UserControl
    {
        //set data in comboboxes: registration numbers and features
        public CarFeatures()
        {
            InitializeComponent();
            registrationComboBox.ItemsSource = DAO.getAllTrucks();
            registrationComboBox.DisplayMemberPath = "RegistrationNumber";
            //linked value to the truck registartion combobox
            registrationComboBox.SelectedValuePath = "RegistrationNumber";

            featureComboBox.ItemsSource = DAO.getAllFeatures();
            featureComboBox.DisplayMemberPath = "Description";
            //linked value to the  feature combobox
            featureComboBox.SelectedValuePath = "Description";


        }
// display all features in the data grid when window loaded
        private void FeaturesWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<TruckFeature> features = DAO.getAllFeatures(); ;
            dataGridFeatures.ItemsSource=features;
            
        }
// add new feature button clicked
        private void addFeatureBtn_Click(object sender, RoutedEventArgs e)
        {
            string newFeature = featureTextBox.Text;
            TruckFeature feature = new TruckFeature();
            feature.Description=newFeature;
            try
            {
                DAO.addFeature(feature);
                MessageBox.Show("New Feature added succesfully");
                List<TruckFeature> features = DAO.getAllFeatures();
                featureTextBox.Text = "";
                dataGridFeatures.ItemsSource = features;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
// add new feature to truck
        private void saveTruckFeatureBtn_Click(object sender, RoutedEventArgs e)
        {
            string rego = registrationComboBox.Text;
            IndividualTruck truck=DAO.findTruckByRego(rego);
            int id = truck.TruckId;
            TruckModel model = truck.TruckModel;
            string feature = featureComboBox.Text;
            List<TruckFeature> Featurelist = truck.Features.ToList();
            TruckFeature truckFeature = DAO.findFeatureByName(feature);
            Featurelist.Append(truckFeature);
            try
            {
                DAO.addFeatureToTruck(id, truckFeature);
                MessageBox.Show("Truck features updated sucessfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
