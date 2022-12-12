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
    /// Логика взаимодействия для UserEditAdminPage.xaml
    /// </summary>
    public partial class UserEditAdminPage : Page
    {
        int MaxCount = 0;
        int RealCount = 0;
        int ActualPages = 0;
        int OneCount = 0;
        public UserEditAdminPage()
        {
            InitializeComponent();
            ListProduct.ItemsSource = Dbconnect.db.User.ToList();
            sort();
        }

        private void BtnReadSupplier_Click(object sender, RoutedEventArgs e)
        {
            var BtnProd = (sender as Button).DataContext as User;
            UserAuth.UserAuth.RedUser = Dbconnect.db.User.Where(x => x.ID == BtnProd.ID).FirstOrDefault();

            NavigationService.Navigate(new RedUserAdmin());
        }

        private void sort()
        {

            List<User> users = Dbconnect.db.User.ToList();


            if (ListProduct != null)
            {
                MaxCount = users.Count;
            }


            if (CbSort != null && CbSort.SelectedIndex == 1)
            {
                users = users.OrderBy(x => x.Name).ToList();

            }


            if (TbSearch != null && TbSearch.Text.Length > 0)
            {
                users = users.Where(x => (x.Name != null && x.Name.ToLower().StartsWith(TbSearch.Text.ToLower())) || (x.Login != null && x.Login.ToLower().StartsWith(TbSearch.Text.ToLower()))).ToList();
            }

            MaxCount = users.Count;

            if (CbCountVisible != null && CbCountVisible.SelectedIndex == 1)
            {
                users = users.Skip(ActualPages * 10).Take(10).ToList();
                OneCount = 10;

            }
            else if (CbCountVisible != null && CbCountVisible.SelectedIndex == 2)
            {
                users = users.Skip(ActualPages * 50).Take(50).ToList();
                OneCount = 50;


            }
            else if (CbCountVisible != null && CbCountVisible.SelectedIndex == 3)
            {
                users = users.Skip(ActualPages * 200).Take(200).ToList();
                OneCount = 200;


            }

            if (ListProduct != null)
            {
                ListProduct.ItemsSource = users;
                RealCount = users.Count;

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
    }
}
