using System;
using System.Collections.Generic;
using System.Text;

#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#else
using System.Windows;
using System.Windows.Data;
#endif

namespace Tomato.Mvvm
{
    public static class BindingHelper
    {
        private static readonly FrameworkElement dummyElement =
#if WINDOWS_UWP
            new DummyFrameworkElement();
#else
            new FrameworkElement();
#endif

        public static object GetBindingValue(this BindingBase binding)
        {
            dummyElement.SetBinding(FrameworkElement.DataContextProperty, binding);
            var value = dummyElement.DataContext;
            dummyElement.ClearValue(FrameworkElement.DataContextProperty);
            return value;
        }

        public static object GetBindingValue(this BindingBase binding, object dataContext)
        {
            dummyElement.DataContext = dataContext;
            dummyElement.SetBinding(FrameworkElement.TagProperty, binding);
            var value = dummyElement.Tag;
            dummyElement.ClearValue(FrameworkElement.TagProperty);
            dummyElement.DataContext = null;
            return value;
        }
#if !WINDOWS_UWP
        public static void Rebind(this DependencyObject obj, DependencyProperty property)
        {
            var binding = BindingOperations.GetBinding(obj, property);
            BindingOperations.ClearBinding(obj, property);
            BindingOperations.SetBinding(obj, property, binding);
        }
#endif

#if WINDOWS_UWP
        class DummyFrameworkElement : FrameworkElement
        {
            public DummyFrameworkElement()
            {

            }
        }
#endif
    }
}
