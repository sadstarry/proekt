using proekt.Components;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO.Packaging;
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

namespace proekt.Pages
{
    /// <summary>
    /// Логика взаимодействия для RagPage.xaml
    /// </summary>
    public partial class RagPage : Page
    {
        public RagPage()
        {
            InitializeComponent();
        }

        private void Reg_click(object sender, RoutedEventArgs e)
        {
            string login = TbLoginReg.Text.Trim().ToLower();
            string password = TbPasswordReg.Text.Trim();
            string Name = TbNameReg.Text.Trim();
            string Surname = TbSurnameReg.Text.Trim();
            string Patronymic = TbPatronymicReg.Text.Trim();
            string Phone = TbPhoneReg.Text.Trim();
            string Email = TbEmailReg.Text.Trim();
            //Проверяем пароль и логин на пустоту

            // 6 - минимум, дальше - бесконечно
            if (Dbconnect.db.User.ToList().Find(x => x.Login == login) != null) {
                MessageBox.Show("Такой логин занят!");
                return;
            }
                if (login.Length > 0 && password.Length > 0 && (!Regex.IsMatch(password, @"\s")))
                {

                    if (Regex.IsMatch(password, @"\S{6,}") && Regex.IsMatch(password, @"\d") && Regex.IsMatch(password, @"[A-ZА-Я]") && Regex.IsMatch(password, @"[!@#$%^]"))
                    {

                        Dbconnect.db.User.Add(new User
                        {
                            Login = login,
                            Password = password,
                            Name = Name,
                            Surname = Surname,
                            Patronymic = Patronymic,
                            Phone = Phone,
                            Email = Email,
                            Roleid = 1
                        });
                        Dbconnect.db.SaveChanges();
                        MessageBox.Show("Регистрация прошла успешно");
                        NavigationService.Navigate(new Auth());
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен соответствовать условиям \r\nМинимум 6 символов.\r\nМинимум 1 прописная буква.\r\nМинимум 1 цифра.\r\nМинимум один символ из набора: ! @ # $ % ^.\r\n");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля");
                }
        }

        private void ClearReg_click(object sender, RoutedEventArgs e)
        {
            TbLoginReg.Text = "";
            TbPasswordReg.Text = "";
            TbNameReg.Text = "";
            TbSurnameReg.Text = "";
            TbPatronymicReg.Text = "";
            TbPhoneReg.Text = "";
            TbEmailReg.Text = "";
        }

        private void NextReg_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void TbNameReg_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbSurnameReg_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbEmailReg_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbPhoneReg_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
