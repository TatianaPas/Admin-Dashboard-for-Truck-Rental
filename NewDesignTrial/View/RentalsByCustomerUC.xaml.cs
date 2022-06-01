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
    /// Interaction logic for RentalsByCustomerUC.xaml
    /// </summary>
    public partial class RentalsByCustomerUC : UserControl
    {
        public RentalsByCustomerUC()
        {
            InitializeComponent();
        }

        private void showTruckBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(idTextBox.Text);
            IndividualTruck truck = DAO.findTruckById(id);
            features.ItemsSource=DAO.getTruckFeaturesById(id);


        }
    }
}
