using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using proekt.Components;
using proekt.UserAuth;

namespace proekt.Pages._3_PageRole.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для RedAdminList.xaml
    /// </summary>
    public partial class RedAdminList : Page
    {
        public RedAdminList()
        {
            InitializeComponent();

            var tovar = UserAuth.UserAuth.tovar;

            TbIdAddProd.Text = Convert.ToString(tovar.ID);
            TbNameAddProd.Text = tovar.Name;
            DiscriptionsAddProd.Text = tovar.Discription;
            PriceAddProd.Text = Convert.ToString(tovar.Cast);
            CountAddProd.Text = Convert.ToString(tovar.Count);
            CbCountVisible.SelectedIndex = Convert.ToInt32(tovar.UnitId) - 1;
            DataAddProd.Text = Convert.ToString(tovar.DateAdd);

        }

        private void SaveProd_click(object sender, RoutedEventArgs e)
        {
            Product prodid = Dbconnect.db.Product.Where(x => x.ID == UserAuth.UserAuth.tovar.ID).FirstOrDefault();
            try
            {
                prodid.Name = TbNameAddProd.Text.Trim();
                prodid.Discription = DiscriptionsAddProd.Text.Trim();
                prodid.Cast = Convert.ToDecimal(PriceAddProd.Text.Trim());
                prodid.Count = Convert.ToInt32(CountAddProd.Text.Trim());
                prodid.UnitId = CbCountVisible.SelectedIndex + 1;
                prodid.DateAdd = Convert.ToDateTime(DataAddProd.Text.Trim());

                Dbconnect.db.SaveChanges();
                MessageBox.Show("Изменения успешно сохранены!");

                NavigationService.Navigate(new ListAdminProduct());
            }
            catch (Exception)
            {
                MessageBox.Show("Дата введена неверно!");
            }
        }

        private void DeleteAddProd_click(object sender, RoutedEventArgs e)
        {
            Product prodid = Dbconnect.db.Product.Where(x => x.ID == UserAuth.UserAuth.tovar.ID).FirstOrDefault();

            prodid.IsDelete = true;

            Dbconnect.db.SaveChanges();

            MessageBox.Show("Товар был успешно удалён!");
            NavigationService.Navigate(new ListAdminProduct());
        }

        private void NextAddProd_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListAdminProduct());
        }

    }
}
