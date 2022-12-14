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

namespace proekt.Pages._3_PageRole.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для AddSuppliers.xaml
    /// </summary>
    public partial class AddSuppliers : Page
    {
        public AddSuppliers()
        {
            InitializeComponent();
        }

        private void AddProd_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SupplierAdd());
        }

        private void ClearAddProd_click(object sender, RoutedEventArgs e)
        {

        }

        private void NextAddProd_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SupplierAdd());
        }
    }
}
