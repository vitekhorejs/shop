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
    /// Interakční logika pro CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
            LoginVerify();
            ItemsToListView();
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

        private void ItemsToListView()
        {
            var itemsFromDb = Database.GetItemsToCartByMail(Logged.logged_user.Mail).Result;
            /*itemsFromDb.
            List<Item> itemy = new List<Item>(); 
            foreach (int cislo in itemsFromDb)
            {
                Database.GetItemsById()
            }*/
            listview.ItemsSource = itemsFromDb;
        }

            private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Logged.logged = false;
            Logged.logged_user = null;
            this.NavigationService.Navigate(new MainPage());
        }
        private void LoginVerify()
        {
            if (Logged.logged)
            {
                LoginPanel.Visibility = Visibility.Hidden;
                UserPanel.Visibility = Visibility.Visible;
                //Info.Visibility = Visibility.Hidden;
                USER.Content = Logged.logged_user.Mail;
            }
            else
            {
                LoginPanel.Visibility = Visibility.Visible;
                UserPanel.Visibility = Visibility.Hidden;
                USER.Content = "";
            }
        }
    }
}
