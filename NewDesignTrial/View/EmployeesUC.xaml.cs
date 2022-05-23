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
    /// Interaction logic for EmployeesUC.xaml
    /// </summary>
    public partial class EmployeesUC : UserControl
    {
        public EmployeesUC()
        {
            InitializeComponent();
        }

        private void allEmployees_Loaded(object sender, RoutedEventArgs e)
        {
            gridEmployees.ItemsSource = DAO.getEmployees();
            gridEmployees.Columns[0].Header = " ID";
            gridEmployees.Columns[1].Header = "Name";
            gridEmployees.Columns[2].Header = "Address";
            gridEmployees.Columns[3].Header = "Phone";
            gridEmployees.Columns[4].Header = "Office";
            gridEmployees.Columns[5].Header = "Ph.extension ";
            gridEmployees.Columns[6].Header = " Username";
            gridEmployees.Columns[7].Header = "Password";
            gridEmployees.Columns[8].Header = "Role";
            

        }
    }
}
