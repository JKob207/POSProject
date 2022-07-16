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
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
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
        /// Przycisk logowania użytkownika do panelu
        /// </summary>
        private void Run_Button_Click(object sender, RoutedEventArgs e)
        {
            // Downloaded data from user input
            string userIdString = tbUserIdLogin.Text;
            int userId = default(int);
                
            bool checkIfNumber = int.TryParse(userIdString, out userId);
            if(checkIfNumber != true)
            {
                tbUserIdLogin.Text = "Wprowadź poprawne ID!";
                return;
            }

            // Search for ID in database
            using var dbContext = new SQLiteContext();
            dbContext.Database.EnsureCreated();
            var result = dbContext.Employee.Where(e => e.EmployeerID == userId).FirstOrDefault();

            if(result == null)
            {
                tbUserIdLogin.Text = "Błędne ID!";
            }else
            {
                UserLogin tUser = new UserLogin();

                bool testID = tUser.Login(userId, result.EmployeerID);

                if(testID)
                {
                    App_Window main = new App_Window(result.EmployeerID, result.Name, result.Surname, result.EmployeerRole);
                    main.Show();
                    this.Close();
                }
            }
        }
    }
}
