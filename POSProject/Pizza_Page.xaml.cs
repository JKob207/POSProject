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

namespace POSProject.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Pizza_Page.xaml
    /// </summary>
    
    public enum PizzaEnum
    {
        Margherita = 1,
        Funghi,
        Salami,
        Capriciosa,
        Roma,
        Venezia
    }

    public partial class Pizza_Page : Page
    {
        public Pizza_Page()
        {
            InitializeComponent();
        }

        private void addPizza(string pizza, int price)
        {
            // Add pizza to list box
            int pizzaPrice = price * ((App_Window)Window.GetWindow(this)).Multiply;
            string pizzaOrder = pizza + " x" + ((App_Window)Window.GetWindow(this)).Multiply.ToString() + "\t " + pizzaPrice+"zł";
            ((App_Window)Window.GetWindow(this)).TotalPrice = ((App_Window)Window.GetWindow(this)).TotalPrice + pizzaPrice;
            ((App_Window)Window.GetWindow(this)).tbTotalPrice.Text = "Całkowita cena: " + ((App_Window)Window.GetWindow(this)).TotalPrice+"zł";
            ((App_Window)Window.GetWindow(this)).addExtras = true;
            ((App_Window)Window.GetWindow(this)).lbBill.Items.Add(pizzaOrder);

            // Add pizza to list
            int customerOrder = ((App_Window)Window.GetWindow(this)).CustomerOrderNumber;
            PizzaEnum Pizzaid = (PizzaEnum)System.Enum.Parse(typeof(PizzaEnum), pizza);
            ((App_Window)Window.GetWindow(this)).customer_Pizzas_List.Add(new() { Quantity = ((App_Window)Window.GetWindow(this)).Multiply, PizzaID = (int)Pizzaid, customerOrderID = customerOrder });
        }

        private void Margherita_Click(object sender, RoutedEventArgs e)
        {
            addPizza("Margherita", 20);
        }

        private void Funghi_Click(object sender, RoutedEventArgs e)
        {
            addPizza("Funghi", 23);
        }

        private void Salami_Click(object sender, RoutedEventArgs e)
        {
            addPizza("Salami", 23);
        }

        private void Capriciosa_Click(object sender, RoutedEventArgs e)
        {
            addPizza("Capriciosa", 24);
        }

        private void Roma_Click(object sender, RoutedEventArgs e)
        {
            addPizza("Roma", 22);
        }

        private void Venezia_Click(object sender, RoutedEventArgs e)
        {
            addPizza("Venezia", 24);
        }
    }
}
