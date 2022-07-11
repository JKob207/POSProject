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

namespace POSProject
{
    /// <summary>
    /// Logika interakcji dla klasy Drinks_Page.xaml
    /// </summary>
    
    public enum DrinkEnum
    {
        Coca_Cola = 1,
        Sprite,
        Fanta,
        Coca_Cola_ZERO,
        Woda_gazowana,
        Woda_niegazowana
    }

    public partial class Drinks_Page : Page
    {
        public Drinks_Page()
        {
            InitializeComponent();
        }

        private void addDrink(string drink, int price)
        {
            // Add drink to list box
            int drinkPrice = price * ((App_Window)Window.GetWindow(this)).Multiply;
            string drinkOrder = drink + "  x" + ((App_Window)Window.GetWindow(this)).Multiply.ToString() + " " + drinkPrice + "zł";
            ((App_Window)Window.GetWindow(this)).TotalPrice = ((App_Window)Window.GetWindow(this)).TotalPrice + drinkPrice;
            ((App_Window)Window.GetWindow(this)).tbTotalPrice.Text = "Całkowita cena: " + ((App_Window)Window.GetWindow(this)).TotalPrice + "zł";
            ((App_Window)Window.GetWindow(this)).addExtras = false;
            ((App_Window)Window.GetWindow(this)).lbBill.Items.Add(drinkOrder);

            // Add drink to list
            int customerOrder = ((App_Window)Window.GetWindow(this)).CustomerOrderNumber;
            DrinkEnum Drinkid = (DrinkEnum)System.Enum.Parse(typeof(DrinkEnum), drink);
            ((App_Window)Window.GetWindow(this)).customer_Drinks_List.Add(new() { Quantity = ((App_Window)Window.GetWindow(this)).Multiply, DrinkID = (int)Drinkid, customerOrderID = customerOrder });
        }

        private void Coke_Click(object sender, RoutedEventArgs e)
        {
            addDrink("Coca_Cola", 6);
        }

        private void Sprite_Click(object sender, RoutedEventArgs e)
        {
            addDrink("Sprite", 7);
        }

        private void Fanta_Click(object sender, RoutedEventArgs e)
        {
            addDrink("Fanta", 6);
        }

        private void Coke_ZERO_Click(object sender, RoutedEventArgs e)
        {
            addDrink("Coca_Cola_ZERO", 6);
        }

        private void Sparkling_Water_Click(object sender, RoutedEventArgs e)
        {
            addDrink("Woda gazowana", 5);
        }

        private void Flat_water_Click(object sender, RoutedEventArgs e)
        {
            addDrink("Woda niegazowana", 5);
        }
    }
}
