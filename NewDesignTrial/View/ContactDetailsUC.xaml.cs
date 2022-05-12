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
            //Check if ID is type of Int

            string CheckId = inputTextBox.Text;
            int value;
            if (int.TryParse(CheckId, out value))
            {
                int id = int.Parse(inputTextBox.Text);
                try
                {
                    //find Contact Details in the TruckPerson database
                    TruckPerson tp = DAO.searchContact(id);
                    if (tp != null)
                    {
                        nameTextBox.Text = tp.Name;
                        telephoneTextBox.Text = tp.Telephone;
                        addressTextBox.Text = tp.Address;
                        contactDetailsGrid.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        //if information not found
                        MessageBox.Show("Sorry, no information found");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //if entered not integer
                MessageBox.Show("Please enter correct ID");
                return;
            }
        }


        //clear fields button function, remove data from fiends, set contact details invisible
            private void clearBtn_Click(object sender, RoutedEventArgs e)
            {
                nameTextBox.Text = "";
                telephoneTextBox.Text = "";
                addressTextBox.Text = "";
                inputTextBox.Text = "";
                contactDetailsGrid.Visibility = Visibility.Hidden;
            }
        }
}
