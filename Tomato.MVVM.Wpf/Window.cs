using System;
using System.Collections.Generic;
using System.Dynamic;
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

namespace Tomato.MVVM.Wpf
{
    public class Window : System.Windows.Window
    {
        public static readonly DependencyPropertyKey ViewBagProperty = DependencyProperty.RegisterReadOnly("ViewBag", typeof(ExpandoObject), typeof(Window), new PropertyMetadata(new ExpandoObject()));

        public dynamic ViewBag
        {
            get { return GetValue(ViewBagProperty.DependencyProperty); }
        }

        static Window()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata(typeof(Window)));
        }
    }
}
