using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tomato.MVVM.Wpf
{
    public class MetroWindow : MahApps.Metro.Controls.MetroWindow
    {
        public dynamic ViewBag
        {
            get { return GetValue(Window.ViewBagProperty.DependencyProperty); }
        }

        static MetroWindow()
        {
        }
    }
}
