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
using proekt.UserAuth;
using System.Text.RegularExpressions;
using System.Collections;

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
        string[] bask = { };
        List<Product> da16 = new List<Product>();
        public UserBacket()
        {
            InitializeComponent();

            User Userid = Dbconnect.db.User.Where(x => x.ID == UserAuth.UserAuth.nameuser.ID).FirstOrDefault();
            string korz = Userid.basket;
            var da15 = Dbconnect.db.Product.ToList();

            if (korz != null && korz != "" && korz != ",")
            {
                string[] da14 = Regex.Matches(korz, @"\d+").OfType<Match>().Select(x => x.Value).ToArray();
                bask = Regex.Matches(korz, @"\d+").OfType<Match>().Select(x => x.Value).ToArray();

                for (int i = 0; i < da14.Length; i++)
                {
                    for (int f = 0; f < da15.Count; f++)
                    {
                        if (Convert.ToInt32(da14[i]) == da15[f].ID)
                        {
                            if (da15[f].IsDelete == true)
                            {
                                Match da7 = Regex.Match(Userid.basket, @"(.*)\D" + da15[f].ID + @"(\D.*)");
                                Userid.basket = Convert.ToString((Group)da7.Groups[1]) + Convert.ToString((Group)da7.Groups[2]);
                                UserAuth.UserAuth.nameuser = Userid;
                                Dbconnect.db.SaveChanges();
                                break;
                            }
                            else {
                                da16.Add(da15[f]);
                                break;
                            }
                        }
                    }
                }
            }
            

            ListKozinak.ItemsSource = da16;
            sort();
            //BtnLeft.IsEnabled = false;
            //BtnRight.IsEnabled = false;

        }

        private void sort()
        {

            List<Product> products = da16;


            
            if (ListKozinak != null)
            {
                MaxCount = products.Count;
                for (int i = 0; i < MaxCount; i++)
                {
                    AllPrice.Text = Convert.ToString(Convert.ToInt32(AllPrice.Text) + Convert.ToInt32(products.Where(x => x.ID == Convert.ToInt32(bask[i])).FirstOrDefault().Cast));
                }
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

            if (ListKozinak != null)
            {
                ListKozinak.ItemsSource = products;
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

        private void BntBuy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualPages = 0;
            sort();
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

        private void BtnDeleteKorz_Click(object sender, RoutedEventArgs e)
        {
            var BtnProd = (sender as Button).DataContext as Product;
            List<Product> da1 = new List<Product>();

            da1 = Dbconnect.db.Product.Where(x => x.ID == BtnProd.ID).ToList();

            User Userid = Dbconnect.db.User.Where(x => x.ID == UserAuth.UserAuth.nameuser.ID).FirstOrDefault();
            Match da6 = Regex.Match(Userid.basket, @"(.*)\D" + (int)da1[0].ID + @"(\D.*)");

            Userid.basket = Convert.ToString((Group)da6.Groups[1]) + Convert.ToString((Group)da6.Groups[2]);

            UserAuth.UserAuth.nameuser = Userid;
            Dbconnect.db.SaveChanges();
            NavigationService.Navigate(new UserPage.UserBacket());

        }

        private void CountKoz_Click(object sender, RoutedEventArgs e)
        {
            var BtnProd = (sender as Button).DataContext as Product;
            UserAuth.UserAuth.Count = Dbconnect.db.Product.Where(x => x.ID == BtnProd.ID).FirstOrDefault();


            NavigationService.Navigate(new CountProdKoz());
        }
    }
}
