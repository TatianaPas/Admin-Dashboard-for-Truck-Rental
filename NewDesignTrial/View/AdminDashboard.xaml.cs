﻿using System;
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
using System.Windows.Shapes;
using NewDesignTrial.View;

namespace NewDesignTrial.View
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();           
        }


       
        private void buttonMinimise_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void WindowStateBtnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
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

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            this.Hide();
            form.Show();
        }

        private void rentals_menu_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void records_by_date_menu_Click(object sender, RoutedEventArgs e)
        {
            
           
        }

        private void records_by_customer_menu_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void add_truck_menu_Click(object sender, RoutedEventArgs e)
        {
            main_window_panel.Children.Clear();
            main_window_panel.Children.Add(new AddTruckUC());
        }   

        private void add_customer_menu_Click(object sender, RoutedEventArgs e)
        {
            main_window_panel.Children.Clear();
            main_window_panel.Children.Add(new addCustomer());
        }
     

        private void addEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            main_window_panel.Children.Clear();
            main_window_panel.Children.Add(new addEmployee());

        }
        private void searchCustomer_menu_Click(object sender, RoutedEventArgs e)
        {
            main_window_panel.Children.Clear();
            main_window_panel.Children.Add(new SearchCustomerUC());
        }

        private void contactsBtn_Click(object sender, RoutedEventArgs e)
        {
            main_window_panel.Children.Clear();
            main_window_panel.Children.Add(new ContactDetailsUC());
        }

        private void updateDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            main_window_panel.Children.Clear();
            main_window_panel.Children.Add(new UpdatePersonalDetailsUC());
        }

        private void showAllCustomers_menu_Click(object sender, RoutedEventArgs e)
        {
            main_window_panel.Children.Clear();
            main_window_panel.Children.Add(new showCustomersUC());
        }
    }
}

   