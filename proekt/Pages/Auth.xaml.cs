using proekt.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
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
using System.Timers;
using System.Windows.Threading;
using proekt.UserAuth;
using System.Security.Cryptography.X509Certificates;

namespace proekt.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        string path = System.IO.Path.GetTempPath();
        string login = "";
        int CountAuth = 0;
        DispatcherTimer atimer = new DispatcherTimer();

        public Auth()
        {
            if (File.Exists(path + "ddsCountAuth.txt"))
            {
                CountAuth = Convert.ToInt32(check_file("ddsCountAuth.txt")) + 1;
            }

            InitializeComponent();

            if (CountAuth >= 3)
            {
                blockis(false);
                atimer.Tick += new EventHandler(openButton);
            }

            if (File.Exists(path + "dsslogin.txt"))
            {
                TbLogin.Text = check_file("dsslogin.txt");
                SaveDataLogin.IsChecked = true;
            }
        }    
        private void AuthReg_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RagPage());
        }

        private void auth_click(object sender, RoutedEventArgs e)
        {
            login = TbLogin.Text.Trim().ToLower();
            string password = TbPassword.Text.Trim();
            bool SDLogin = SaveDataLogin.IsChecked.Value;


            if (login.Length == 0 && password.Length == 0)
            {
                MessageBox.Show("Заполните поля!");  
            }
            else
            {
                var authUser = Dbconnect.db.User.ToList().Find(x => x.Login == login && x.Password == password);
                if (authUser == null)
                {
                    if (File.Exists(path + "ddsCountAuth.txt"))
                    {
                        CountAuth = Convert.ToInt32(check_file("ddsCountAuth.txt")) + 1;
                        create_file("ddsCountAuth.txt", Convert.ToString(CountAuth));

                        if (CountAuth >= 3)
                        {
                            blockis(false);
                            atimer.Tick += new EventHandler(openButton);
                        }
                    }
                    else
                    {
                        create_file("ddsCountAuth.txt", "1");
                    }
                    MessageBox.Show("Не правильный логин или пароль");
                }
                else
                {
                    if (SDLogin) {
                        create_file("dsslogin.txt", login);
                    }
                    else
                    {
                        File.Delete(path + "dsslogin.txt");
                    }
                    File.Delete(path + "ddsCountAuth.txt");

                    UserAuth.UserAuth.nameuser = authUser;

                    if (Dbconnect.db.User.ToList().Find(x => x.Login == login).Roleid == 2){

                        NavigationService.Navigate(new _3_PageRole.AdminClientsPage());
                    }
                    else if (Dbconnect.db.User.ToList().Find(x => x.Login == login).Roleid == 3)
                    {
                        NavigationService.Navigate(new _3_PageRole.ManagerClientPage());
                    }
                    else if (Dbconnect.db.User.ToList().Find(x => x.Login == login).Roleid == 4)
                    {
                        NavigationService.Navigate(new _3_PageRole.SupplierClientsPage());
                    }
                    else
                    {
                        NavigationService.Navigate(new _3_PageRole.UserClientsPage());
                    }
                }
            }   
        }


        public void blockis(bool condition) {
            AuthClickBtn.IsEnabled = condition;
            RegAuthClickBtn.IsEnabled = condition;
            if (condition)
            {
                TextBlock.Text = "";
                File.Delete(path + "ddsCountAuth.txt");
            } 
            else
            {
                atimer.Interval = new TimeSpan(0, 0, 5);
                atimer.Start();
                TextBlock.Text = "Вы ввели максимальное кол-во попыток\nПодождите 1 минуту";
            }

        }
        public void openButton(object sender, EventArgs e)
        {
            atimer.Stop();
            blockis(true);
        }

        public void create_file(string name, string text) {
            using (FileStream fs = File.Create(path + name))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(text);
                fs.Write(info, 0, info.Length);
            }

        }
        public string check_file(string name) {
            string temptext = "";
            using (StreamReader sr = File.OpenText(path + name))
            {
                while ((temptext = sr.ReadLine()) != null) {
                    return temptext;
                }
            }
            return temptext;
        }

        //Памятник Великому Китайозе Джун Ли деду, храни его небеса, земля ему пухом
        /*public string check_file(int indicator, string NameFile, string textFile)
        {
            string path = System.IO.Path.GetTempPath() + NameFile + ".txt";
            if (indicator == 1) {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(textFile);
                    fs.Write(info, 0, info.Length);
                }
            }
            else if (indicator == 2){ 
                using (StreamReader sr = File.OpenText(path))
                {
                    string temptext = "";
                    while ((temptext = sr.ReadLine()) != null)
                    {
                        return temptext;
                    }
                }
            }
            else{
                File.Delete(path);

            }
            return "true";
        } */
    }
}
