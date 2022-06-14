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
    /// Interaction logic for reportsUC.xaml
    /// </summary>
    public partial class reportsUC : UserControl
    {
        public reportsUC()
        {
            InitializeComponent();
        }

        private void showPeopleBtn_Click(object sender, RoutedEventArgs e)
        {
            gridPeople.ItemsSource = DAO.getPeople();
        }

        private void showRentals_Click(object sender, RoutedEventArgs e)
        {
            string rego = regoTextBox.Text;

        }
    }
}
