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
    /// Interakční logika pro MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        { 
            InitializeComponent();
            InitDB();
            LoginVerify();
            
            CategoriesToIc();

           /* List<Category> neco = new List<Category>();

            Category kategorie = new Category();
            kategorie.ImageSource = "/shop;component/Images/snapcode.png";
            kategorie.Name = "kategorie";
            neco.Add(kategorie);

            Category kategorie1 = new Category();
            kategorie1.ImageSource = "/shop;component/Images/snapcode.png";
            kategorie1.Name = "kategorie";
            neco.Add(kategorie1);

            Category kategorie11 = new Category();
            kategorie11.ImageSource = "/shop;component/Images/snapcode.png";
            kategorie11.Name = "kategorie";
            neco.Add(kategorie11);
            neco.Add(kategorie11);
            neco.Add(kategorie11);
            neco.Add(kategorie11);
            neco.Add(kategorie11);

            ic.ItemsSource = neco;*/
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

        private void CategoriesToIc()
        {
            var itemsFromDb = Database.GetCategoriesAsync().Result;
            ic.ItemsSource = itemsFromDb;
        }

        public void InitDB()
        {
            var itemsFromDb = Database.GetCategoriesAsync().Result;
            if (itemsFromDb.Count() == 0)
            {
                Category category = new Category();
                category.Name = "CPU";
                category.ImageSource = "/shop;component/Images/procesor.png";
                Database.SaveItemAsync(category);

                Category category1 = new Category();
                category1.Name = "RAM";
                category1.ImageSource = "/shop;component/Images/ram.png";
                Database.SaveItemAsync(category1);

                Category category2 = new Category();
                category2.Name = "DVD-ROM";
                category2.ImageSource = "/shop;component/Images/dvd.png";
                Database.SaveItemAsync(category2);

                Category category3 = new Category();
                category3.Name = "HDD";
                category3.ImageSource = "/shop;component/Images/disk.png";
                Database.SaveItemAsync(category3);

                Category category4 = new Category();
                category4.Name = "SSD";
                category4.ImageSource = "/shop;component/Images/ssd.png";
                Database.SaveItemAsync(category4);

                Category category5 = new Category();
                category5.Name = "Skříň";
                category5.ImageSource = "/shop;component/Images/skrin.png";
                Database.SaveItemAsync(category5);

                Category category6 = new Category();
                category6.Name = "PSU";
                category6.ImageSource = "/shop;component/Images/zdroj.png";
                Database.SaveItemAsync(category6);

                Category category7 = new Category();
                category7.Name = "GPU";
                category7.ImageSource = "/shop;component/Images/grafika.png";
                Database.SaveItemAsync(category7);

                Category category8 = new Category();
                category8.Name = "Zákl. deska";
                category8.ImageSource = "/shop;component/Images/deska.png";
                Database.SaveItemAsync(category8);
            }
            var itemsFromDb2 = Database.GetIdbyName("CPU").Result;
            var itemsFromDb3 = Database.GetItemsByCategoryId(itemsFromDb2.Id).Result;
            if (itemsFromDb3.Count() == 0)
            {
                Item item = new Item();
                item.Name = "Core i7";
                item.ImageSource = "/shop;component/Images/i7.png";
                item.Price = 50000;
                item.Category_Id = itemsFromDb2.Id;
                Database.SaveItemAsync(item);

                Item item1 = new Item();
                item1.Name = "Ryzen";
                item1.ImageSource = "/shop;component/Images/ryzen.png";
                item1.Price = 60000;
                item1.Category_Id = itemsFromDb2.Id;
                Database.SaveItemAsync(item1);


            }
            var itemsFromDb4 = Database.GetIdbyName("GPU").Result;
            var itemsFromDb5 = Database.GetItemsByCategoryId(itemsFromDb4.Id).Result;
            if (itemsFromDb5.Count() == 0)
            {
                Item item = new Item();
                item.Name = "Nvidia Titan Xp";
                item.ImageSource = "/shop;component/Images/titan_xp.png";
                item.Price = 50000;
                item.Category_Id = itemsFromDb4.Id;
                Database.SaveItemAsync(item);

                Item item1 = new Item();
                item1.Name = "Amd R9 270x";
                item1.ImageSource = "/shop;component/Images/r9.png";
                item1.Price = 60000;
                item1.Category_Id = itemsFromDb4.Id;
                Database.SaveItemAsync(item1);


            }
        }

        /*public MainPage(User uziv)
        {
            InitializeComponent();
            LoginVerify();
            user = uziv;
        }
        User user;*/
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

        private void User_Clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CartPage());
        }

        private void Item_Clicked(object sender, RoutedEventArgs e)
        {
            
            var grid = sender as Grid;
            ic.SelectedItem = grid.DataContext;
            Category selectedItem = ic.SelectedItem as Category;
            //MessageBox.Show(selectedItem.Id.ToString(), "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            this.NavigationService.Navigate(new CategoryPage(selectedItem));



        }
    }
}
