using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.TextFormatting;
using System.Xml.Linq;
using proekt.UserAuth;

namespace proekt.Components
{

    public partial class Product
    {
        public Visibility visibilityCount
        {
            get
            {
                if (Count == 0)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }

        public Visibility visibleBtn
        {
            get
            {
                if (Count == 0)
                {
                  
                    return Visibility.Hidden;
                }
                else 
                { 
                    return Visibility.Visible;
                }
            }
        }

        public int SymCol {
            get {
                return Convert.ToInt32(Cast) * Convert.ToInt32(Regex.Match(UserAuth.UserAuth.nameuser.basket, @"," + ID + @":(\d+),").Groups[1].ToString());
            }
        }

        public string size 
        {
            get 
            {
                return Regex.Match(UserAuth.UserAuth.nameuser.basket, @"," + ID + @":(\d+),").Groups[1].ToString();
            }
        }
        public string size2
        {
            get
            {
                return Regex.Match(UserAuth.UserAuth.Koz.Product, @"," + ID + @":(\d+),").Groups[1].ToString();
            }
        }

        public int borderTich
        {
            get
            {
                if (Count == 0)
                {
                    return 3;
                }
                else
                {
                    return 0;
                }
            }
        }

        public string BANstatus
        {
            get
            {
                if (UserAuth.UserAuth.nameuser.Roleid == 2 || UserAuth.UserAuth.nameuser.Roleid == 3)
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }

    }

    public partial class Order {
        public Visibility menegder
        {
            get
            {
                if (Menedjet == null)
                {

                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public string statusord {
            get {
                if (StatusOrderID == 1)
                {
                    return "true";
                }
                else {
                    return "false";
                }   
            }
        } 

    }
}
