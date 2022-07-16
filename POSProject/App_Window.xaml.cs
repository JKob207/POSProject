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
            TotalPrice = 0;
            addExtras = false;
            customer_Pizzas_List = new List<Customer_pizza>();
            customer_Extras_List = new List<Customer_extra>();
            customer_Drinks_List = new List<Customer_drink>();

            // Load customer order form db
            loadCustomerNumber();

            // Add employeer data to components
            tbName.Text = EmployeerName + " " + EmployeerSurname;
            tbWorkerInfo.Text = EmployeerRole + " " + EmployeerID;
        }

        public int Multiply { get; set; }
        public int TotalPrice { get; set; }
        public bool addExtras { get; set; }
        public int CustomerOrderNumber { get; set; }

        public int EmployeerID { get; set; }
        public string EmployeerName { get; set; }
        public string EmployeerSurname { get; set; }
        public string EmployeerRole { get; set; }
        public string Order { get; set; }

        public List<Customer_pizza> customer_Pizzas_List { get; set; }
        public List<Customer_extra> customer_Extras_List { get; set; }
        public List<Customer_drink> customer_Drinks_List { get; set; }


        //Buttons whose open pages
        /// <summary>
        /// Przycisk wyzwalający stronę z pizzami
        /// </summary>
        private void btPizza_Click(object sender, RoutedEventArgs e)
        {
            Pages_Screen.Content = new Pizza_Page();
            btExtras.IsEnabled = true;

        }
        /// <summary>
        /// Przycisk wyzwalający stronę z dodatkami
        /// </summary>
        private void btExtras_Click(object sender, RoutedEventArgs e)
        {
            Pages_Screen.Content = new Trimmings_Page();
        }
        /// <summary>
        /// Przycisk wyzwalający strony z napojami
        /// </summary>
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
        /// <summary>
        /// Przycisk mnożnika razy 1
        /// </summary>
        private void btMultiply1_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 1;
            ResetMultipleButtonsBc();
            btMultiply1.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }
        /// <summary>
        /// Przycisk mnożnika razy 2
        /// </summary>
        private void btMultiply2_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 2;
            ResetMultipleButtonsBc();
            btMultiply2.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }
        /// <summary>
        /// Przycisk mnożnika razy 3
        /// </summary>
        private void btMultiply3_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 3;
            ResetMultipleButtonsBc();
            btMultiply3.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }
        /// <summary>
        /// Przycisk mnożnika razy 4
        /// </summary>
        private void btMultiply4_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 4;
            ResetMultipleButtonsBc();
            btMultiply4.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }
        /// <summary>
        /// Przycisk mnożnika razy 5
        /// </summary>
        private void btMultiply5_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 5;
            ResetMultipleButtonsBc();
            btMultiply5.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }
        /// <summary>
        /// Przycisk mnożnika razy 6
        /// </summary>
        private void btMultiply6_Click(object sender, RoutedEventArgs e)
        {
            Multiply = 6;
            ResetMultipleButtonsBc();
            btMultiply6.Background = (Brush)new BrushConverter().ConvertFrom("#BEE6FD");
        }
        /// <summary>
        /// Przycisk usunięcia bieżącego zamówienia i stworzenia nowego
        /// </summary>
        private void btNewOrder_Click(object sender, RoutedEventArgs e)
        {
            lbBill.Items.Clear();
            TotalPrice = 0;
            tbTotalPrice.Text = "Całkowita cena: 0zł";
        }

        private void loadCustomerNumber()
        {
            using var dbContext = new SQLiteContext();
            dbContext.Database.EnsureCreated();
            var lastNumber = dbContext.Customer_Orders.Count();
            if(lastNumber == 0)
            {
                CustomerOrderNumber = 1;
            }else
            {
                CustomerOrderNumber = lastNumber + 1;
            }
            dbContext.Customer_Orders.Add(new() { Total_price = 0 });
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Przycisk potwierdzenie zamówienia, który tworzey nowe zamówienie i umieszcza je w bazie dancyh
        /// </summary>
        private void btConfirm_Click(object sender, RoutedEventArgs e)
        {
            using var dbContext = new SQLiteContext();
            dbContext.Database.EnsureCreated();

            // Add pizzas to database
            foreach (Customer_pizza pizza in customer_Pizzas_List)
            {
                dbContext.Customer_Pizza.Add(pizza);
            }


            // Add drinks to database
            foreach (Customer_drink drink in customer_Drinks_List)
            {
                dbContext.Customer_Drinks.Add(drink);
            }

            dbContext.SaveChanges();

            // Add extras to database
            foreach (Customer_extra extra in customer_Extras_List)
            {
                dbContext.Customer_Extras.Add(extra);
            }

            dbContext.SaveChanges();

            // Clear list box
            lbBill.Items.Clear();
            tbTotalPrice.Text = "Całkowita cena: 0zł";

            // Flush lists
            customer_Pizzas_List.Clear();
            customer_Extras_List.Clear();
            customer_Drinks_List.Clear();

            //Update customer order total price
            var order = dbContext.Customer_Orders.SingleOrDefault(c => c.ID == CustomerOrderNumber);
            if (order != null)
            {
                order.Total_price = TotalPrice;
                TotalPrice = 0;
                CustomerOrderNumber++;
                dbContext.SaveChanges();
            }
        }
    }


}
