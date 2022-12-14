using proekt.Components;
using proekt.Pages._3_PageRole.UserPage;
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
using System.Text.RegularExpressions;

namespace proekt.Pages._3_PageRole.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для RedOrder.xaml
    /// </summary>
    public partial class RedOrder : Page
    {
        int MaxCount = 0;
        int RealCount = 0;
        int ActualPages = 0;
        int OneCount = 0;
        string[] bask = { };
        List<Product> da16 = new List<Product>();
        public RedOrder()
        {
            InitializeComponent();
            if (UserAuth.UserAuth.nameuser.Roleid == 2 || UserAuth.UserAuth.nameuser.Roleid == 3)
            {
                BANnah.Visibility = Visibility.Visible;
            }
            else
            {
                BANnah.Visibility = Visibility.Collapsed;
            }

            Order Userid = Dbconnect.db.Order.Where(x => x.ID == UserAuth.UserAuth.Koz.ID).FirstOrDefault();
            string korz = Userid.Product;
            var da15 = Dbconnect.db.Product.ToList();

            if (korz != null && korz != "" && korz != ",")
            {

                string[] da14 = Regex.Matches(korz, @"\d+:").OfType<Match>().Select(x => x.Value).ToArray();

                for (int i = 0; i < da14.Length; i++)
                {
                    for (int f = 0; f < da15.Count; f++)
                    {
                        if (Convert.ToInt32(da14[i].Trim(new char[] { ':' })) == da15[f].ID)
                        {
                            if (da15[f].IsDelete == true)
                            {
                                Match da7 = Regex.Match(Userid.Product, @"(.*)," + da15[f].ID + @":\d+(,.*)");
                                Userid.Product = Convert.ToString((Group)da7.Groups[1]) + Convert.ToString((Group)da7.Groups[2]);
                                UserAuth.UserAuth.Koz = Userid;
                                Dbconnect.db.SaveChanges();
                            }
                            else
                            {
                                da16.Add(da15[f]);
                            }
                            break;

                        }
                    }
                }
            }
            ListProduct.ItemsSource = da16;
            sort();

        }

        private void sort()
        {

            List<Product> products = da16;


            if (ListProduct != null)
            {
                MaxCount = products.Count;
            }


            switch (CbUnit.SelectedIndex)
            {
                case 1:
                    products = products.Where(x => x.UnitId == 1).ToList();
                    break;

                case 2:
                    products = products.Where(x => x.UnitId == 4).ToList();
                    break;

                case 3:
                    products = products.Where(x => x.UnitId == 2).ToList();
                    break;

                case 4:
                    products = products.Where(x => x.UnitId == 3).ToList();
                    break;

                case 5:
                    products = products.Where(x => x.UnitId == 5).ToList();
                    break;

                default:
                    break;
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

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            if (RealCount >= OneCount && TxtRealCount.Text != TxtMaxCount.Text)
            {
                ActualPages++;
                sort();
            }
        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            if (ActualPages > 0)
            {
                ActualPages--;
                sort();
            }
        }

        private void BtnOrderAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReadSupplier_Click(object sender, RoutedEventArgs e)
        {
            var BtnProd = (sender as Button).DataContext as Product;
            List<Product> da1 = new List<Product>();

            da1 = Dbconnect.db.Product.Where(x => x.ID == BtnProd.ID).ToList();

            Order Userid = Dbconnect.db.Order.Where(x => x.ID == UserAuth.UserAuth.Koz.ID).FirstOrDefault();
            Match da6 = Regex.Match(Userid.Product, @"(.*)," + (int)da1[0].ID + @":\d+(,.*)");

            Userid.Product = Convert.ToString((Group)da6.Groups[1]) + Convert.ToString((Group)da6.Groups[2]);

            UserAuth.UserAuth.Koz = Userid;
            Dbconnect.db.SaveChanges();

            if (Userid.Product == ",")
            {
                Order statred = Dbconnect.db.Order.Where(x => x.ID == UserAuth.UserAuth.Koz.ID).FirstOrDefault();
            
                statred.StatusOrderID = 3;
                Dbconnect.db.SaveChanges();
                MessageBox.Show("Заказ отменен");
                NavigationService.Navigate(new UserPage.MyOrder());

            }
            else
            {
                NavigationService.Navigate(new RedOrder());
            }
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualPages = 0;
            sort();
        }

        private void CbCountVisible_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualPages = 0;
            sort();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ActualPages = 0;
            sort();
        }

        private void CbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualPages = 0;
            sort();
        }

        private void CountKoz_Click(object sender, RoutedEventArgs e)
        {
            var BtnProd = (sender as Button).DataContext as Product;
            

            NavigationService.Navigate(new Colichestvo(BtnProd));
        }
    }
}
