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
    /// Interaction logic for ContactDetailsUC.xaml
    /// </summary>
    public partial class ContactDetailsUC : UserControl
    {
        public ContactDetailsUC()
        {
            InitializeComponent();
        }

        private void showPersonBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(inputTextBox.Text);
            try
            {
               TruckPerson tp = DAO.searchContact(id);
                nameTextBox.Text = tp.Name;
                telephoneTextBox.Text = tp.Telephone;
                addressTextBox.Text = tp.Address;

            }
            catch
            {

            }

        }
    }
}
