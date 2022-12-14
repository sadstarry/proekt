using proekt.Components;
using proekt.Pages._3_PageRole.UserPage;
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

namespace proekt.Pages._3_PageRole.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для Colichestvo.xaml
    /// </summary>
    public partial class Colichestvo : Page
    {
        Product ttt;
        public Colichestvo(Product BtnProd)
        {
            InitializeComponent();
            ttt = BtnProd;
            TbLoginReg.Text = Regex.Match(UserAuth.UserAuth.Koz.Product, @"," + BtnProd.ID + @":(\d+),").Groups[1].ToString();
        }

        private void Reg_click(object sender, RoutedEventArgs e)
        {
            int colSize;
            try
            {
                colSize = Convert.ToInt32(TbLoginReg.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("Неккоректные данные\nВведите число");
                return;
            }

            if (colSize == 0)
            {
                MessageBox.Show("Данное количество товара не доступно!");
                return;
            }

            Order Userid = Dbconnect.db.Order.Where(x => x.ID == UserAuth.UserAuth.Koz.ID).FirstOrDefault();
            Match da6 = Regex.Match(Userid.Product, @"(.*," + ttt.ID + @":)\d+(,.*)");

            Userid.Product = Convert.ToString((Group)da6.Groups[1]) + Convert.ToString(colSize) + Convert.ToString((Group)da6.Groups[2]);

            Dbconnect.db.SaveChanges();

            NavigationService.Navigate(new RedOrder());

        }

        private void NextReg_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RedOrder());
        }
    }
}
