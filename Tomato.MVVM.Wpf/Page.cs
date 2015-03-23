using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tomato.MVVM.Wpf
{
    public class Page : System.Windows.Controls.Page
    {
        public dynamic ViewBag
        {
            get { return GetValue(Window.ViewBagProperty.DependencyProperty); }
        }

        static Page()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Page), new FrameworkPropertyMetadata(typeof(Page)));
        }
    }
}
