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
using NewDesignTrial.View;
using NewDesignTrial.Models.DB;
using NewDesignTrial.Models;

namespace NewDesignTrial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void buttonMinimise_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void WindowStateBtnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void CloseBtnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }



        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
  
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Password.ToString();
            if (username == null || password == null)
            {
                MessageBox.Show("Please enter login details");
            }
            else
            {

                try
                {
                    TruckEmployee emp = DAO.loginValidation(username, password);
                   

                    if (emp == null)
                    {
                        MessageBox.Show("Please enter correct login details");
                    }
                    else if (emp.Role == "admin")
                    {
                        AdminDashboard form = new AdminDashboard(emp);
                        form.helloTextBox.Text = "Welcome " + emp.Employee.Name;
                        form.Show();
                        this.Hide();

                      
                        

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
       
    }

}
