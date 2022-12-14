using proekt.Components;
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
    /// Логика взаимодействия для SupplierAdd.xaml
    /// </summary>
    public partial class SupplierAdd : Page
    {
        public SupplierAdd()
        {
            InitializeComponent();

            ListProduct.ItemsSource = Dbconnect.db.SupProdCountry.ToList();
        }

        private void BtnReadSupplier_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSuppliers());
        }
    }
}
