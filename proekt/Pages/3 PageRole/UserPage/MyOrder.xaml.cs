using proekt.Components;
using proekt.Pages._3_PageRole.AdminPage;
using proekt.Pages._3_PageRole.UserPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace proekt.Pages._3_PageRole.UserPage
{
    /// <summary>
    /// Логика взаимодействия для MyOrder.xaml
    /// </summary>
    public partial class MyOrder : Page
    {
        public MyOrder()
        {
            InitializeComponent();
            MyOrderUser.ItemsSource = Dbconnect.db.Order.Where(x => x.UserId == UserAuth.UserAuth.nameuser.ID).ToList();
            
        }

        private void CbCountVisible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnReadSupplier_Click(object sender, RoutedEventArgs e)
        {
            var BtnProd = (sender as Button).DataContext as Order;
            UserAuth.UserAuth.Koz = Dbconnect.db.Order.Where(x => x.ID == BtnProd.ID).FirstOrDefault();

            NavigationService.Navigate(new AdminPage.RedOrder());
        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
