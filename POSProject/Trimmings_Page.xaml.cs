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
    /// Logika interakcji dla klasy Trimmings_Page.xaml
    /// </summary>
    public enum ExtraEnum
    {
        Oliwki = 1,
        Czosnek,
        Jalapeno,
        Rukola,
        Pesto,
        Ananas
    }
    public partial class Trimmings_Page : Page
    {
        public Trimmings_Page()
        {
            InitializeComponent();
        }

        private void addExtras(string extra, int price)
        {
            if(((App_Window)Window.GetWindow(this)).addExtras == true)
            {
                // Add extra to list box
                int extraPrice = price * ((App_Window)Window.GetWindow(this)).Multiply;
                string extrasOrder = "\t" + extra + " x" + ((App_Window)Window.GetWindow(this)).Multiply.ToString() + " " + extraPrice + "zł";
                ((App_Window)Window.GetWindow(this)).TotalPrice = ((App_Window)Window.GetWindow(this)).TotalPrice + extraPrice;
                ((App_Window)Window.GetWindow(this)).tbTotalPrice.Text = "Całkowita cena: " + ((App_Window)Window.GetWindow(this)).TotalPrice + "zł";
                ((App_Window)Window.GetWindow(this)).addExtras = true;
                ((App_Window)Window.GetWindow(this)).lbBill.Items.Add(extrasOrder);

                // Add extra to list
                int pizzaID = ((App_Window)Window.GetWindow(this)).customer_Pizzas_List.Count();
                ExtraEnum Extraid = (ExtraEnum)System.Enum.Parse(typeof(ExtraEnum), extra);
                ((App_Window)Window.GetWindow(this)).customer_Extras_List.Add(new() { Quantity = ((App_Window)Window.GetWindow(this)).Multiply, ExtraID = (int)Extraid, customerPizzaID = pizzaID });

            }
        }

        private void Olives_Click(object sender, RoutedEventArgs e)
        {
            addExtras("Oliwki", 2);
        }

        private void Garlic_Click(object sender, RoutedEventArgs e)
        {
            addExtras("Czosnek", 3);
        }

        private void Jalapeno_Click(object sender, RoutedEventArgs e)
        {
            addExtras("Jalapeno", 3);
        }

        private void Rocket_Click(object sender, RoutedEventArgs e)
        {
            addExtras("Rukola", 2);
        }

        private void Pesto_Click(object sender, RoutedEventArgs e)
        {
            addExtras("Pesto", 3);
        }

        private void Pineapple_Click(object sender, RoutedEventArgs e)
        {
            addExtras("Ananas", 5);
        }
    }
}