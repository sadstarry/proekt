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
    /// Логика взаимодействия для RedUserAdmin.xaml
    /// </summary>
    public partial class RedUserAdmin : Page
    {
        public RedUserAdmin()
        {
            InitializeComponent();

            var RedUser = UserAuth.UserAuth.RedUser;

            Articul.Text = Convert.ToString(RedUser.ID);
            Login.Text = RedUser.Login;
            NameUser.Text = RedUser.Name;
            Surname.Text = RedUser.Surname;
            Otch.Text = RedUser.Patronymic;
            Phone.Text = RedUser.Phone;
            Email.Text = RedUser.Email;
            RoleList.SelectedIndex = Convert.ToInt32(RedUser.Roleid) - 1;
        }

        private void SaveProd_click(object sender, RoutedEventArgs e)
        {
            User userr = Dbconnect.db.User.Where(x => x.ID == UserAuth.UserAuth.RedUser.ID).FirstOrDefault();
                userr.Login = Login.Text.Trim();
                userr.Name = NameUser.Text.Trim();
                userr.Surname = Surname.Text.Trim();
                userr.Patronymic = Otch.Text.Trim();
                userr.Phone = Phone.Text.Trim();
                userr.Email = Email.Text.Trim();
                userr.Roleid = RoleList.SelectedIndex + 1;

                Dbconnect.db.SaveChanges();
                MessageBox.Show("Изменения успешно сохранены!");

                NavigationService.Navigate(new UserEditAdminPage());
        }

        private void NextAddProd_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserEditAdminPage());
        }
    }
}
