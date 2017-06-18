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
            //DataContext = this;
            //string user = "jmeno";
            bool logged = false;
            User user = new User();
            user.Name = "Vítek";
            
            if (logged)
            {
                LoginPanel.Visibility = Visibility.Hidden;
                UserPanel.Visibility = Visibility.Visible;
                USER.Content = user.Name;
            } else
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
    }
}
