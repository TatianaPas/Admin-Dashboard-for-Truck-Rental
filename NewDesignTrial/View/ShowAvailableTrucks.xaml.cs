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

namespace NewDesignTrial.View
{
    /// <summary>
    /// Interaction logic for ShowAvailableTrucks.xaml
    /// </summary>
    public partial class ShowAvailableTrucks : UserControl
    {
        public ShowAvailableTrucks()
        {
            InitializeComponent();
        }

        private void AllTrucksWindow_Loaded(object sender, RoutedEventArgs e)
        {
            gridTrucks.ItemsSource = DAO.getAvailableTrucks();
            gridTrucks.Columns[0].Header = " ID";
            gridTrucks.Columns[1].Header = "Reg.no";
            gridTrucks.Columns[2].Header = "Model";
            gridTrucks.Columns[3].Header = "Size";
            gridTrucks.Columns[4].Header = "WOF expiry";
            gridTrucks.Columns[5].Header = "REGO expiry";
            gridTrucks.Columns[6].Header = "Build Year";
            gridTrucks.Columns[7].Header = "  Fuel";
            gridTrucks.Columns[8].Header = "Transmission";
            gridTrucks.Columns[9].Header = "  Rent";
            gridTrucks.Columns[10].Header = "Deposit";
            gridTrucks.Columns[11].Header = "Status";

        }
    }
}
