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
    /// Logika interakcji dla klasy Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        private void btCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            //Download data from text boxes

            string userIdString = tbIdPracownik.Text;
            string userFirstNameString = tbFirstName.Text;
            string userSecondNameString = tbSecondName.Text;
            string userAgeString = tbAge.Text;
            string userPosition = cbPosition.Text;

            int userAgeInt = default(int);
            int userIdInt = default(int);

            //Remove data from text boxes

            tbIdPracownik.Text = "";
            tbFirstName.Text = "";
            tbSecondName.Text = "";
            tbAge.Text = "";

            //Validate Users inputs


            bool checkIfNumberId = int.TryParse(userIdString, out userIdInt);
            bool checkIfNumberAge = int.TryParse(userAgeString, out userAgeInt);

            if (checkIfNumberId != true)
            {
                tbError.Visibility = Visibility.Visible;
                tbError.Text = "Wpisz poprawne ID!";
                return;
            }

            if (userFirstNameString.Length == 0)
            {
                tbError.Visibility = Visibility.Visible;
                tbError.Text = "Pole Imie nie może być puste!";
                return;
            }

            if (userSecondNameString.Length == 0)
            {
                tbError.Visibility = Visibility.Visible;
                tbError.Text = "Pole Nazwisko nie może być puste!";
                return;
            }

            if (checkIfNumberAge != true || userAgeInt < 0)
            {
                tbError.Visibility = Visibility.Visible;
                tbError.Text = "Wpisz poprawny wiek!";
                return;
            }

            //Parse data to database
            using var dbContext = new SQLiteContext();
            dbContext.Database.EnsureCreated();
            dbContext.Employee.Add(new() { EmployeerID = userIdInt, Name = userFirstNameString, Surname = userSecondNameString, Age = userAgeInt, EmployeerRole = userPosition });
            dbContext.SaveChanges();
        }
    }
}
