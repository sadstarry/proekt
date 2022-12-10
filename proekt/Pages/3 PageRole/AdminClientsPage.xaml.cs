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
    public partial class AdminClientsPage : Page
    {
        public AdminClientsPage()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCountry_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
