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
    /// Interakční logika pro RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
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

        private void Register_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterPage());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
        private void Register_Clicked(object sender, RoutedEventArgs e)
        {

            if (Mail.Text == "" || Mail.Text == null)
            {
                MessageBox.Show("Zadejte Email", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!IsValidEmail(Mail.Text))
            {
                MessageBox.Show("Zadejte správný email", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Name.Text == "" || Name.Text == null)
            {
                MessageBox.Show("Zadejte Jméno", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Surname.Text == "" || Surname.Text == null)
            {
                MessageBox.Show("Zadejte Příjmení", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Password.SecurePassword.Length < 5)
            {
                MessageBox.Show("Heslo musí obsahovat alespoň 5 znaků", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Password.Password == "" || Password.Password == null)
            {
                MessageBox.Show("Zadejte heslo", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Password2.Password == "" || Password2.Password == null)
            {
                MessageBox.Show("Zadejte heslo znovu", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Password.Password != Password2.Password)
            {
                MessageBox.Show("Zadaná hesla se neshodují", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {      
                var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
                byte[] salt = new byte[8];
                rng.GetBytes(salt); // Create an 8 byte salt
                var iterations = 1024; // Choose a value that will perform well given your hardware.
                var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(Password.Password, salt, iterations);
                var hash = pbkdf2.GetBytes(16); // Get 16 bytes for the hash
                //MessageBox.Show(Convert.ToBase64String(hash) + Convert.ToBase64String(salt) + Password.Password, "Upozornění", MessageBoxButton.OK, MessageBoxImage.Warning);
                //MessageBox.Show(salt.ToString(), "Upozornění", MessageBoxButton.OK, MessageBoxImage.Warning);
                User uzivatel = new User();
                uzivatel.Mail = Mail.Text;
                uzivatel.Name = Name.Text;
                uzivatel.Surname = Surname.Text;
                uzivatel.Password = hash;
                uzivatel.salt = salt;
                Database.SaveUserAsync(uzivatel);
                MessageBox.Show("Uživatel "+Name.Text+" "+Surname.Text+" je zaregistrovaný, nyní se přihlašte.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new MainPage());
            }
        }
    }
}
