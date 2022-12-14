using proekt.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace proekt.Pages._3_PageRole.UserPage
{
    /// <summary>
    /// Логика взаимодействия для CountProdKoz.xaml
    /// </summary>
    public partial class CountProdKoz : Page
    {
        public CountProdKoz()
        {
            InitializeComponent();
            TbLoginReg.Text = Regex.Match(UserAuth.UserAuth.nameuser.basket, @"," + UserAuth.UserAuth.Count.ID + @":(\d+),").Groups[1].ToString();
        }

        private void Reg_click(object sender, RoutedEventArgs e)
        {

            int colSize;
            try
            {
                colSize = Convert.ToInt32(TbLoginReg.Text.Trim());
            }
            catch(Exception)
            {
                MessageBox.Show("Неккоректные данные\nВведите число");
                return;
            }

            if (colSize == 0 || colSize > UserAuth.UserAuth.Count.Count) {
                MessageBox.Show("Данное количество товара не доступно!");
                return;
            }

            User Userid = Dbconnect.db.User.Where(x => x.ID == UserAuth.UserAuth.nameuser.ID).FirstOrDefault();
            Match da6 = Regex.Match(Userid.basket, @"(.*," + UserAuth.UserAuth.Count.ID + @":)\d+(,.*)");

            Userid.basket = Convert.ToString((Group)da6.Groups[1]) + Convert.ToString(colSize) + Convert.ToString((Group)da6.Groups[2]);

            UserAuth.UserAuth.nameuser = Userid;
            Dbconnect.db.SaveChanges();

            NavigationService.Navigate(new UserBacket());

        }

        private void NextReg_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserBacket());
        }
    }
}
