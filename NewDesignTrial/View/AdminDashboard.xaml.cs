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
using System.Windows.Shapes;

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
            main_window_panel.Visibility = Visibility.Hidden;
            rentals_window_panelC.Visibility = Visibility.Hidden;
            rentals_window_panel.Visibility = Visibility.Visible;
        }

        private void records_by_customer_menu_Click(object sender, RoutedEventArgs e)
        {
            main_window_panel.Visibility = Visibility.Hidden;
            rentals_window_panel.Visibility = Visibility.Hidden;
            rentals_window_panelC.Visibility = Visibility.Visible;
        }

        private void add_truck_menu_Click(object sender, RoutedEventArgs e)
        {
            this.window_textBox.Text = "Add a new truck window";
        }

        private void search_truck_menu_Click(object sender, RoutedEventArgs e)
        {
            this.window_textBox.Text = "Search a truck window";
        }

        private void update_truck_menu_Click(object sender, RoutedEventArgs e)
        {
            this.window_textBox.Text = "Update truck window";
        }

        private void add_customer_menu_Click(object sender, RoutedEventArgs e)
        {
            main_window_panel.Visibility = Visibility.Hidden;
            rentals_window_panelC.Visibility = Visibility.Hidden;
            rentals_window_panel.Visibility = Visibility.Hidden;
            add_customer_panel.Visibility=Visibility.Visible;
        }
    }
}

   