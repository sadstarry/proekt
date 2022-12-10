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
    /// Логика взаимодействия для SupplierClientsPage.xaml
    /// </summary>
    public partial class SupplierClientsPage : Page
    {
        public SupplierClientsPage()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAllAdmiss_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNewProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
