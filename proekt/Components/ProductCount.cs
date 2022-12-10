using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace proekt.Components
{
    
   public partial class Product
    {
        string username = "233";
        public void temp(string Name)
        {
            username = Name;
            MessageBox.Show(username);
        }

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

        

    }

    
}
