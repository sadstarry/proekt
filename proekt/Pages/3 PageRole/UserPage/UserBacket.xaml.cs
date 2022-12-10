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

namespace proekt.Pages._3_PageRole.UserPage
{
    /// <summary>
    /// Логика взаимодействия для UserBacket.xaml
    /// </summary>
    public partial class UserBacket : Page
    {
        int MaxCount = 0;
        int RealCount = 0;
        int ActualPages = 0;
        int OneCount = 0;
        public UserBacket()
        {
            InitializeComponent();
            ListProduct.ItemsSource = Dbconnect.db.Product.ToList();
            Up();
            BtnLeft.IsEnabled = false;
            BtnRight.IsEnabled = false;

        }

        private void kozinak()
        {

        }

        private void Up()
        {

            List<Product> products = Dbconnect.db.Product.Where(x => x.IsDelete == false).ToList();


            if (ListProduct != null)
            {
                ListProduct.ItemsSource = products;
                RealCount = products.Count;
                TxtMaxCount.Text = RealCount.ToString();

            }


            if (CbUnit.SelectedIndex == 1)
            {
                products = products.Where(x => x.UnitId == 1).ToList();

            }
            else if (CbUnit.SelectedIndex == 2)
            {
                products = products.Where(x => x.UnitId == 4).ToList();
            }
            else if (CbUnit.SelectedIndex == 3)
            {
                products = products.Where(x => x.UnitId == 2).ToList();
            }
            else if (CbUnit.SelectedIndex == 4)
            {
                products = products.Where(x => x.UnitId == 3).ToList();
            }
            else if (CbUnit.SelectedIndex == 5)
            {
                products = products.Where(x => x.UnitId == 5).ToList();
            }



            if (CbSort != null && CbSort.SelectedIndex == 1)
            {
                products = products.OrderBy(x => x.Name).ToList();

            }
            else if (CbSort != null && CbSort.SelectedIndex == 2)
            {
                products = products.OrderByDescending(x => x.DateAdd).ToList();

            }



            if (TbSearch != null && TbSearch.Text.Length > 0)
            {
                products = products.Where(x => (x.Name != null && x.Name.ToLower().StartsWith(TbSearch.Text.ToLower())) || (x.Discription != null && x.Discription.ToLower().StartsWith(TbSearch.Text.ToLower()))).ToList();
            }



            if (CbCountVisible != null && CbCountVisible.SelectedIndex == 1)
            {
                products = products.Skip(ActualPages * 1).Take(1).ToList();
                OneCount = 1;

            }
            else if (CbCountVisible != null && CbCountVisible.SelectedIndex == 2)
            {
                products = products.Skip(ActualPages * 2).Take(2).ToList();
                OneCount = 2;


            }
            else if (CbCountVisible != null && CbCountVisible.SelectedIndex == 3)
            {
                products = products.Skip(ActualPages * 5).Take(5).ToList();
                OneCount = 5;


            }

            if (ListProduct != null)
            {
                ListProduct.ItemsSource = products;
                RealCount = products.Count;
                TxtRealCount.Text = RealCount.ToString();

            }

        }

        private void BntBuy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Up();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Up();
        }

        private void CbCountVisible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Up();
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Up();
        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
