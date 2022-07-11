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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeDatabase();
            InitializeComponent();
        }

        public void InitializeDatabase()
        {
            using var dbContext = new SQLiteContext();
            dbContext.Database.EnsureCreated();
            InitializeTablesValue(dbContext);
        }

        private void InitializeTablesValue(SQLiteContext db)
        {
            if(db.Pizza.Count() == 0)
            {
                // Pizzas
                db.Pizza.Add(new() { Name = "Venezia", Price = 24 });
                db.Pizza.Add(new() { Name = "Roma", Price = 22 });
                db.Pizza.Add(new() { Name = "Capriciosa", Price = 24 });
                db.Pizza.Add(new() { Name = "Salami", Price = 23 });
                db.Pizza.Add(new() { Name = "Funghi", Price = 23 });
                db.Pizza.Add(new() { Name = "Margherita", Price = 20 });
            }

            if (db.Extra.Count() == 0)
            {
                // Extras
                db.Extra.Add(new() { Name = "Ananas", Price = 5 });
                db.Extra.Add(new() { Name = "Pesto", Price = 3 });
                db.Extra.Add(new() { Name = "Rukola", Price = 2 });
                db.Extra.Add(new() { Name = "Jalapeno", Price = 3 });
                db.Extra.Add(new() { Name = "Czosnek", Price = 3 });
                db.Extra.Add(new() { Name = "Oliwki", Price = 2 });
            }

            if (db.Drink.Count() == 0)
            {
                //Drinks
                db.Drink.Add(new() { Name = "Woda niegazowana", Price = 5 });
                db.Drink.Add(new() { Name = "Woda gazowana", Price = 5 });
                db.Drink.Add(new() { Name = "Coca-Cola ZERO", Price = 6 });
                db.Drink.Add(new() { Name = "Fanta", Price = 6 });
                db.Drink.Add(new() { Name = "Sprite", Price = 7 });
                db.Drink.Add(new() { Name = "Coca-Cola", Price = 6 });
            }

            db.SaveChanges();
        }


        //Movement of Window
        private void Grid_MouseDown(object sender , MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Login1_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btRegistration_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }
}
