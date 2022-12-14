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
using proekt.Pages._3_PageRole.AdminPage;
using static System.Net.Mime.MediaTypeNames;
using System.Data.Common;

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

                string[] da14 = Regex.Matches(korz, @"\d+:").OfType<Match>().Select(x => x.Value).ToArray();

                for (int i = 0; i < da14.Length; i++)
                {
                    for (int f = 0; f < da15.Count; f++)
                    {
                        if (Convert.ToInt32(da14[i].Trim(new char[] { ':' })) == da15[f].ID)
                        {
                            if (da15[f].IsDelete == true || da15[f].Count <= 0)
                            {
                                Match da7 = Regex.Match(Userid.basket, @"(.*)," + da15[f].ID + @":\d+(,.*)");
                                Userid.basket = Convert.ToString((Group)da7.Groups[1]) + Convert.ToString((Group)da7.Groups[2]);
                                UserAuth.UserAuth.nameuser = Userid;
                                Dbconnect.db.SaveChanges();
                            }
                            else {
                                da16.Add(da15[f]);
                            }
                            break;
                        }
                    }
                }
                bask = Regex.Matches(Userid.basket, @"\d+:").OfType<Match>().Select(x => x.Value).ToArray();
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
                    var tovPrice = products.Where(x => x.ID == Convert.ToInt32(bask[i].Trim(new char[] { ':' }))).FirstOrDefault().Cast;
                    string tovCount = Regex.Match(UserAuth.UserAuth.nameuser.basket, @"," + bask[i].Trim(new char[] { ':' }) + @":(\d+),").Groups[1].ToString();
                    AllPrice.Text = Convert.ToString(Convert.ToInt32(AllPrice.Text) + Convert.ToInt32(tovPrice) * Convert.ToInt32(tovCount));
                }
                UserAuth.UserAuth.AllPrice = Convert.ToInt32(AllPrice.Text);
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

            if (ListKozinak != null)
            {
                ListKozinak.ItemsSource = products;
                RealCount = products.Count;

                TxtMaxCount.Text = MaxCount.ToString();

                if (RealCount == OneCount)
                {
                    TxtRealCount.Text = (RealCount * ActualPages + OneCount).ToString();
                    UserAuth.UserAuth.CountProd.CountTovar = (RealCount * ActualPages + OneCount).ToString();

                }
                else
                {
                    TxtRealCount.Text = TxtMaxCount.Text;
                }

            }

        }

        private void BntBuy_Click(object sender, RoutedEventArgs e)
        {       
            Dbconnect.db.Order.Add(new Order
            {
                UserId = UserAuth.UserAuth.nameuser.ID,
                DataApp = DateTime.Now,
                AllPrice = UserAuth.UserAuth.AllPrice,
                StatusOrderID = 1,
                Product = Convert.ToString(UserAuth.UserAuth.nameuser.basket),
                //CountTovar = UserAuth.UserAuth.CountProd.CountTovar
            });

            User Userid = Dbconnect.db.User.Where(x => x.ID == UserAuth.UserAuth.nameuser.ID).FirstOrDefault();

            /* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! ВАЖНО !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var colpoxyyyje = Dbconnect.db.Product.ToList();
            string[] number = Regex.Matches(Userid.basket, @"\d+:\d+").OfType<Match>().Select(x => x.Value).ToArray();

            for (int i = 0; i < number.Length; i++)
            {
                Match temp = Regex.Match(number[i], @"(\d+):(\d+)");
                for (int f = 0; f < colpoxyyyje.Count; f++)
                {
                    if (colpoxyyyje[f].ID == Convert.ToInt32(temp.Groups[1].ToString())) {
                        Product colpoxyyyje2 = Dbconnect.db.Product.ToList().Find(x => x.ID == colpoxyyyje[f].ID);
                        colpoxyyyje2.Count = colpoxyyyje2.Count - Convert.ToInt32(temp.Groups[2].ToString());
                        Dbconnect.db.SaveChanges();
                        break;
                    }
                }
            }
            */

            UserAuth.UserAuth.nameuser.basket = ",";
            Userid.basket = ",";

            Dbconnect.db.SaveChanges();
            MessageBox.Show("Заказ успешно добавлен!");
                


            NavigationService.Navigate(new MyOrder());
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
            Match da6 = Regex.Match(Userid.basket, @"(.*)," + (int)da1[0].ID + @":\d+(,.*)");

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
