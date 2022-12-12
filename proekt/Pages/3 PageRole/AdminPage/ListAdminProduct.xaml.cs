using proekt.Components;
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
using proekt.UserAuth;

namespace proekt.Pages._3_PageRole.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для ListAdminProduct.xaml
    /// </summary>
    public partial class ListAdminProduct : Page
    {
        int MaxCount = 0;
        int RealCount = 0;
        int ActualPages = 0;
        int OneCount = 0;
        public ListAdminProduct()
        {
            InitializeComponent();
            ListProduct.ItemsSource = Dbconnect.db.Product.ToList();
            sort();
            //BtnLeft.IsEnabled = false;
            //BtnRight.IsEnabled = false;
        }

        private void CbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualPages = 0;
            sort();
        }

        private void sort()
        {

            List<Product> products = Dbconnect.db.Product.Where(x => x.IsDelete == false).ToList();


            if (ListProduct != null)
            {
                MaxCount = products.Count;
            }

            // для себя | переделать через case 
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
            ///////////


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

            MaxCount = products.Count;

            if (CbCountVisible != null && CbCountVisible.SelectedIndex == 1)
            {
                products = products.Skip(ActualPages * 10).Take(10).ToList();
                OneCount = 10;

            }
            else if (CbCountVisible != null && CbCountVisible.SelectedIndex == 2)
            {
                products = products.Skip(ActualPages * 50).Take(50).ToList();
                OneCount = 50;


            }
            else if (CbCountVisible != null && CbCountVisible.SelectedIndex == 3)
            {
                products = products.Skip(ActualPages * 200).Take(200).ToList();
                OneCount = 200;


            }

            if (ListProduct != null)
            {
                ListProduct.ItemsSource = products;
                RealCount = products.Count;

                TxtMaxCount.Text = MaxCount.ToString();

                if (RealCount == OneCount)
                {
                    TxtRealCount.Text = (RealCount * ActualPages + OneCount).ToString();

                }
                else
                {
                    TxtRealCount.Text = TxtMaxCount.Text;
                }

            }

        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualPages = 0;
            sort();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ActualPages = 0;
            sort();
        }

        private void CbCountVisible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualPages = 0;
            sort();
        }

        private void ChecedMonth_Checked(object sender, RoutedEventArgs e)
        {

        }


        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            if (ActualPages > 0)
            {
                ActualPages--;
                sort();
            }
        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            if (RealCount >= OneCount && TxtRealCount.Text != TxtMaxCount.Text)
            {
                ActualPages++;
                sort();
            }
        }

        private void BtnReadSupplier_Click(object sender, RoutedEventArgs e)
        {

            var BtnProd = (sender as Button).DataContext as Product;
            UserAuth.UserAuth.tovar = Dbconnect.db.Product.Where(x => x.ID == BtnProd.ID).FirstOrDefault();

            NavigationService.Navigate(new RedAdminList());
        }

        private void BntBuy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage.AddProductAdminPage());
        }
    }
}
