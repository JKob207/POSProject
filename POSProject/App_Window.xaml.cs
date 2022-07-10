using POSProject.Pages;
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

namespace POSProject
{
    /// <summary>
    /// Logika interakcji dla klasy App_Window.xaml
    /// </summary>
    public partial class App_Window : Window
    {
        public App_Window(int ID, string Name, string Surname, string Role)
        {
            // Parse employeer data
            EmployeerID = ID;
            EmployeerName = Name;
            EmployeerSurname = Surname;
            EmployeerRole = Role;

            InitializeComponent();

            // Initialize default values
            Multiply = 1;
            addExtras = false;

            // Add employeer data to components
            tbName.Text = EmployeerName + " " + EmployeerSurname;
            tbWorkerInfo.Text = EmployeerRole + " " + EmployeerID;
        }

        public int Multiply { get; set; }
        public bool addExtras { get; set; }
        public int EmployeerID { get; set; }
        public string EmployeerName { get; set; }
        public string EmployeerSurname { get; set; }
        public string EmployeerRole { get; set; }
        public string Order { get; set; }


        //Buttons whose open pages
        private void btPizza_Click(object sender, RoutedEventArgs e)
        {
            Pages_Screen.Content = new Pizza_Page();
            btExtras.IsEnabled = true;

        }
        private void btExtras_Click(object sender, RoutedEventArgs e)
        {
            Pages_Screen.Content = new Trimmings_Page();
        }

        private void btDrinks_Click(object sender, RoutedEventArgs e)
        {
            Pages_Screen.Content = new Drinks_Page();
            btExtras.IsEnabled = false;
        }

        private void ResetMultipleButtonsBc()
        {
            btMultiply1.Background = (Brush)new BrushConverter().ConvertFrom("#FF564F4F");
            btMultiply2.Background = (Brush)new BrushConverter().ConvertFrom("#FF564F4F");
            btMultiply3.Background = (Brush)new BrushConverter().ConvertFrom("#FF564F4F");
            btMultiply4.Background = (Brush)new BrushConverter().ConvertFrom("#FF564F4F");
            btMultiply5.Background = (Brush)new BrushConverter().ConvertFrom("#FF564F4F");
            btMultiply6.Background = (Brush)new BrushConverter().ConvertFrom("#FF564F4F");
        }

        // Multiply buttons
        private void btMultiply1_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 1;
            ResetMultipleButtonsBc();
            btMultiply1.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }

        private void btMultiply2_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 2;
            ResetMultipleButtonsBc();
            btMultiply2.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }

        private void btMultiply3_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 3;
            ResetMultipleButtonsBc();
            btMultiply3.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }

        private void btMultiply4_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 4;
            ResetMultipleButtonsBc();
            btMultiply4.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }

        private void btMultiply5_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 5;
            ResetMultipleButtonsBc();
            btMultiply5.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }

        private void btMultiply6_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 6;
            ResetMultipleButtonsBc();
            btMultiply6.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }

        private void btNewOrder_Click(object sender, RoutedEventArgs e)
        {
            lbBill.Items.Clear();
        }
    }


    






}
