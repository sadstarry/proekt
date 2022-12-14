using Microsoft.Win32;
using proekt.Components;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
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
using System.Data.Entity;


namespace proekt.Pages._3_PageRole.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для AddProductAdminPage.xaml
    /// </summary>
    /// 
    public partial class AddProductAdminPage : Page
    {
        
        public AddProductAdminPage()
        {
            InitializeComponent();

        }


        private void AddProd_click(object sender, RoutedEventArgs e)
        {
            string Name = TbNameAddProd.Text.Trim();
            string Descriptions = DiscriptionsAddProd.Text.Trim();
            string Prise = PriceAddProd.Text.Trim();
            string Counts = CountAddProd.Text.Trim();
            int Unit = CbCountVisible.SelectedIndex;
            try
            {
            if (Name.Length > 0 && Descriptions.Length > 0 && Prise.Length > 0 && Counts.Length > 0)
            {

                Dbconnect.db.Product.Add(new Product
                {
                    Name = Name,
                    Discription = Descriptions,
                    DateAdd = DateTime.Now,
                    Cast = Convert.ToInt32(Prise),
                    UnitId = Unit + 1,
                    Count = Convert.ToInt32(Counts),
                    IsDelete = false
                });

                Dbconnect.db.SaveChanges();
                MessageBox.Show("Товар успешно добавлен!");

                NavigationService.Navigate(new ListAdminProduct());
            }
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения!");
            }
            }
            catch
            {
                MessageBox.Show("Вы что-то ввели не правильно!");
            }
        }


        private void NextAddProd_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListAdminProduct());
        }

        private void ClearAddProd_click(object sender, RoutedEventArgs e)
        {
            TbNameAddProd.Text = "";
            DiscriptionsAddProd.Text = "";
            PriceAddProd.Text = "";
            CountAddProd.Text = "";
            CbCountVisible.SelectedIndex = 0;
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg" /*сначала наименование в проводнике потом сам формат*/
            };
            //string name;

            if (openFile.ShowDialog().GetValueOrDefault())
            {
                //Product.Image1 = File.ReadAllBytes(openFile.FileName);
                //Images.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }
    }
}
