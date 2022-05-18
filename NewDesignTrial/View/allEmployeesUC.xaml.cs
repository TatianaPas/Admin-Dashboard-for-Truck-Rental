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

namespace Assignment_Project_RentalManagement.View
{
    /// <summary>
    /// Interaction logic for ShowEmployeesUC.xaml
    /// </summary>
    public partial class ShowEmployeesUC : UserControl
    {
        public ShowEmployeesUC()
        {
            InitializeComponent();
        }

        private void showEmployeesWindow_Loaded(object sender, RoutedEventArgs e)
        {
            gridEmployees.ItemsSource = DAO.getEmployees();
        }
    }
}
