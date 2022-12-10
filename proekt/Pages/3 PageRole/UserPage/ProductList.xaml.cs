using proekt.Components;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace proekt.Pages._3_PageRole.UserPage
{
    /// <summary>
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Page
    {
        public ProductList()
        {
            InitializeComponent();
            ListProduct.ItemsSource = Dbconnect.db.Product.ToList();
            //var produkt = Dbconnect.db.Product.ToList().FindLast(x => x.ID ==);
            //MessageBox.Show(Convert.ToString(produkt.ID));
            //TxtRealCount.Text = "1";
            //TxtMaxCount.Text = ;
        }

        private void CbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CbCountVisible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChecedMonth_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOrderAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReadSupplier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
