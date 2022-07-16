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
            tbSuccess.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Przycisk powrotu do głównego okna aplikacji
        /// </summary>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        /// <summary>
        /// Przycisk umożliwiowający stworzenie nowego konta
        /// </summary>
        private void btCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            using var dbContext = new SQLiteContext();
            dbContext.Database.EnsureCreated();

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
            bool checkIdLength = userIdString.Length == 4 ? true : false; 

            //Check if ID is free
            var checkFreeID = dbContext.Employee.Where(e => e.EmployeerID == userIdInt).FirstOrDefault();

            if (checkIfNumberId != true)
            {
                tbError.Visibility = Visibility.Visible;
                tbError.Text = "Wpisz poprawne ID!";
                return;
            }

            if (checkFreeID != null)
            {
                tbError.Visibility = Visibility.Visible;
                tbError.Text = "Podane ID jest zajęte!";
                return;
            }

            if (checkIdLength != true)
            {
                tbError.Visibility = Visibility.Visible;
                tbError.Text = "Podane ID jest niezgodnej długości!";
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
            dbContext.Employee.Add(new() { EmployeerID = userIdInt, Name = userFirstNameString, Surname = userSecondNameString, Age = userAgeInt, EmployeerRole = userPosition });
            dbContext.SaveChanges();
            tbSuccess.Visibility = Visibility.Visible;
        }
    }
}
