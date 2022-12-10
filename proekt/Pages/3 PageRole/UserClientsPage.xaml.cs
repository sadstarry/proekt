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

namespace proekt.Pages._3_PageRole
{
    /// <summary>
    /// Логика взаимодействия для UserClientsPage.xaml
    /// </summary>
    public partial class UserClientsPage : Page
    {
        public UserClientsPage()
        {
            InitializeComponent();
            MyFrame.Navigate(new UserPage.ProductList());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBasket_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnStory_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
