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
    /// Interaction logic for showCustomersUC.xaml
    /// </summary>
    public partial class showCustomersUC : UserControl
    {

        public showCustomersUC()
        {
            InitializeComponent();
        }
       

        private void allCusotmersWindow_Loaded(object sender, RoutedEventArgs e)
        {
            gridCustomers.ItemsSource = DAO.getCustomers();
            gridCustomers.Columns[0].Header = " ID";
            gridCustomers.Columns[1].Header = "Name";
            gridCustomers.Columns[2].Header = "Address";
            gridCustomers.Columns[3].Header = "Phone";
            gridCustomers.Columns[4].Header = "Licence No";
            gridCustomers.Columns[5].Header = "Age";
            gridCustomers.Columns[6].Header = "Licence Expiry";
            
            


        }

       
    }   
}
