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
using proekt.Components;
using proekt.Pages._3_PageRole.UserPage;

namespace proekt.Pages._3_PageRole.UserPage
{
    /// <summary>
    /// Логика взаимодействия для ProdListOrder.xaml
    /// </summary>
    public partial class ProdListOrder : Page
    {
        public ProdListOrder()
        {
            List<Product> da16 = new List<Product>();
            InitializeComponent();

            /* List<ZvOrder> da55 = new List<ZvOrder>();

            var ZvOr = Dbconnect.db.ZvOrder.ToList();
            var orde = Dbconnect.db.Order.ToList();
            var prod = Dbconnect.db.Product.ToList();

            for (int i = 0; i < prod.Count; i++)
            {
                for (int f = 0; f < ZvOr.Count; f++)
                {
                    if (prod[i].ID == ZvOr[f].IdProduct) {

                        da55.Add(ZvOr[f]);
                    }
                }
               
            }

            ListProductOrder.ItemsSource = da55; */

            Order Userid = Dbconnect.db.Order.Where(x => x.ID == UserAuth.UserAuth.Koz.ID).FirstOrDefault();
            string korz = Userid.Product;
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
                                Match da7 = Regex.Match(Userid.Product, @"(.*)," + da15[f].ID + @":\d+(,.*)");
                                Userid.Product = Convert.ToString((Group)da7.Groups[1]) + Convert.ToString((Group)da7.Groups[2]);
                                UserAuth.UserAuth.Koz = Userid;
                                Dbconnect.db.SaveChanges();
                            }
                            else
                            {
                                da16.Add(da15[f]);


                            }
                            break;

                        }
                    }
                }
            }
            ListProductOrder.ItemsSource = da16;
        }
    }
}
