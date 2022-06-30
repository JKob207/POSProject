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
            //Pizzas
            db.Pizza.Add(new() { Name = "Margherita", Price = 29 });
            db.Pizza.Add(new() { Name = "Funghi", Price = 30 });
            db.Pizza.Add(new() { Name = "Salami", Price = 32 });
            db.Pizza.Add(new() { Name = "Capricciosa", Price = 32 });
            db.Pizza.Add(new() { Name = "Hawajska", Price = 32 });
            db.Pizza.Add(new() { Name = "Quarttro", Price = 34 });

            //Extras
            db.Extra.Add(new() { Name = "Chicken", Price = 5 });
            db.Extra.Add(new() { Name = "Cheesee", Price = 2 });
            db.Extra.Add(new() { Name = "Mushrooms", Price = 2 });
            db.Extra.Add(new() { Name = "Spinaci", Price = 3 });
            db.Extra.Add(new() { Name = "Salami", Price = 4 });

            //Drinks
            db.Drink.Add(new() { Name = "CocaCola", Price = 7 });
            db.Drink.Add(new() { Name = "Fanta", Price = 7 });
            db.Drink.Add(new() { Name = "Sprite", Price = 7 });
            db.Drink.Add(new() { Name = "Water", Price = 5 });

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
