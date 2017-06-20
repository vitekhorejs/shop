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
    /// Interakční logika pro CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        public CategoryPage()
        {
            InitializeComponent();
            LoginVerify();
            ItemsToIc();
        }

        public CategoryPage(Category item)
        {
            InitializeComponent();
            LoginVerify();
            kategorie = item;
            ItemsToIc();
            CategoryName.Content = kategorie.Name;
            
        }

        Category kategorie = new Category();
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

        private void ItemsToIc()
        {
            var itemsFromDb = Database.GetItemsByCategoryId(kategorie.Id).Result;
            ic.ItemsSource = itemsFromDb;
        }

        private void LoginVerify()
        {
            if (Logged.logged)
            {
                LoginPanel.Visibility = Visibility.Hidden;
                UserPanel.Visibility = Visibility.Visible;
                Info.Visibility = Visibility.Hidden;
                USER.Content = Logged.logged_user.Mail;
            }
            else
            {
                LoginPanel.Visibility = Visibility.Visible;
                UserPanel.Visibility = Visibility.Hidden;
                USER.Content = "";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Logged.logged = false;
            Logged.logged_user = null;
            this.NavigationService.Navigate(new MainPage());
        }

        private void Item_Clicked(object sender, RoutedEventArgs e)
        {

            var grid = sender as Grid;
            ic.SelectedItem = grid.DataContext;
            Item selectedItem = ic.SelectedItem as Item;
            //MessageBox.Show(selectedItem.Name, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            this.NavigationService.Navigate(new DetailPage(selectedItem));



        }
    }
}
