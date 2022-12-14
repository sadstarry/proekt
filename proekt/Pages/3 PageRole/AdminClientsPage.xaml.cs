using proekt.Pages._3_PageRole.AdminPage;
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
    /// Логика взаимодействия для AdminClientsPage.xaml
    /// </summary>
    /// 
    // ListAdminProduct
    public partial class AdminClientsPage : Page
    {
        public AdminClientsPage()
        {
            InitializeComponent();
            ListAdminProduct.Navigate(new ListAdminProduct());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
            
        }


        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            ListAdminProduct.Navigate(new ListAdminProduct());
        }

        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {
            ListAdminProduct.Navigate(new OrderAdminList());
        }

        private void BtnRole_Click(object sender, RoutedEventArgs e)
        {
            ListAdminProduct.Navigate(new UserEditAdminPage());
        }

        private void BtnCountry_Click(object sender, RoutedEventArgs e)
        {
            ListAdminProduct.Navigate(new AddSuppliers()); 
        }
    }
}
