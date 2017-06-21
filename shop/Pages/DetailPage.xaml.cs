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
    /// Interakční logika pro DetailPage.xaml
    /// </summary>
    public partial class DetailPage : Page
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        public DetailPage(Item givenItem)
        {
            
            InitializeComponent();
            LoginVerify();
            item = givenItem;
            ItemToPage();
            
            //Image.Source = new BitmapImage(new Uri(base.BaseUri,item.ImageSource));
            /*BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(item.ImageSource, UriKind.RelativeOrAbsolute);
            bi3.EndInit();*/
            /*Uri uri = new Uri(item.ImageSource);
            BitmapImage imgSource = new BitmapImage(uri);
            this.Image.Source = imgSource;*/
            //Image.Source = new BitmapImage(new Uri(item.ImageSource));
            //Image.Source = item.ImageSource as ImageSource;
            /*BitmapImage image = new BitmapImage(new Uri(item.ImageSource));
            //Image acbody = new Image();
            Image.Source = image;*/
            //Image finalImage = new Image();
            
            
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

        Item item = new Item();

        private void ItemToPage()
        {
            Name.Content = item.Name;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("pack://application:,,," + item.ImageSource);
            logo.EndInit();
            Image.Source = logo;
            Price.Content = item.Price;
        }

            private void LoginVerify()
        {
            if (Logged.logged)
            {
                LoginPanel.Visibility = Visibility.Hidden;
                UserPanel.Visibility = Visibility.Visible;
                USER.Content = Logged.logged_user.Mail;
            }
            else
            {
                LoginPanel.Visibility = Visibility.Visible;
                UserPanel.Visibility = Visibility.Hidden;
                BuyButton.Visibility = Visibility.Hidden;
                USER.Content = "";
            }
        }

        private void BuyItem(object sender, RoutedEventArgs e)
        {
            CartItem cartitem = new CartItem();
            cartitem.ID_Item = item.Id;
            cartitem.ID_Cart = Logged.logged_user.ID_Cart;
            Database.SaveItemAsync(cartitem);
        }
        private void User_Clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CartPage());
        }

        private void Register_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterPage());
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Logged.logged = false;
            Logged.logged_user = null;
            this.NavigationService.Navigate(new MainPage());
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
    }
}
