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

namespace shop
{
    /// <summary>
    /// Interakční logika pro LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private static Shop_Database _database;
        public static Shop_Database Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new FileHelper();
                    _database = new Shop_Database(fileHelper.GetLocalFilePath("database.db3"));
                }
                return _database;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        public void Login_Click(object sender, RoutedEventArgs e)
        {
            var itemFromDatabase = Database.GetUserAsync(Mail.Text).Result;
            if (itemFromDatabase == null)
            {
                MessageBox.Show("Uživatel s tímto mailem neexistuje", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                User uziv = itemFromDatabase as User;
                var iterations = 1024;
                var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(Password.Password, uziv.salt, iterations);
                var hash = pbkdf2.GetBytes(16);
                //MessageBox.Show(Convert.ToBase64String(hash) + Convert.ToBase64String(itemFromDatabase.salt) + Password.Password, "Upozornění", MessageBoxButton.OK, MessageBoxImage.Warning);

                if (hash.SequenceEqual(itemFromDatabase.Password))
                {
                    MessageBox.Show("Uživatel "+uziv.Name+" "+uziv.Surname+" je nyní přihlášný", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    Logged.logged = true;
                    Logged.logged_user = uziv;
                    if (this.NavigationService.CanGoBack)
                    {
                        this.NavigationService.GoBack();
                    }
                }
                else
                {
                    MessageBox.Show("Nesprávné heslo", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
