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
    public partial class Pizza_Page : Page
    {
        public Pizza_Page()
        {
            InitializeComponent();
        }

        private void addPizza(string pizza, int price)
        {
            int pizzaPrice = price * ((App_Window)Window.GetWindow(this)).Multiply;
            string pizzaOrder = pizza + " x" + ((App_Window)Window.GetWindow(this)).Multiply.ToString() + "\t " + pizzaPrice+"zł";
            ((App_Window)Window.GetWindow(this)).TotalPrice = ((App_Window)Window.GetWindow(this)).TotalPrice + pizzaPrice;
            ((App_Window)Window.GetWindow(this)).tbTotalPrice.Text = "Całkowita cena: " + ((App_Window)Window.GetWindow(this)).TotalPrice+"zł";
            ((App_Window)Window.GetWindow(this)).addExtras = true;
            ((App_Window)Window.GetWindow(this)).lbBill.Items.Add(pizzaOrder);
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
