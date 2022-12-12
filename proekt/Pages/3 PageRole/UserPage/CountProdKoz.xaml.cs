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
        }

        private void Reg_click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new UserBacket());
        }

        private void NextReg_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserBacket());
        }
    }
}
