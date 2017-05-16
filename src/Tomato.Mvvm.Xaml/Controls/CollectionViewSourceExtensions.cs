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

namespace Tomato.Mvvm.Controls
{
    public class CollectionViewSourceProxy
    {
        public CollectionViewSource CollectionViewSource { get; set; }
        /// <summary>
        /// 绑定对象的目标属性
        /// </summary>
        public DependencyProperty TargetProperty { get; set; }
        /// <summary>
        /// CollectionViewSource 的 Source 绑定路径（默认为 DataContext）
        /// </summary>
        public string SourceBindingPath { get; set; }

        public CollectionViewSourceProxy()
        {
            SourceBindingPath = "DataContext";
        }
    }

    public static class CollectionViewSourceExtensions
    {
        public static readonly DependencyProperty ProxyProperty = DependencyProperty.RegisterAttached("Proxy", typeof(CollectionViewSourceProxy),
            typeof(CollectionViewSourceExtensions), new PropertyMetadata(null, OnProxyChanged));

        public static CollectionViewSourceProxy GetProxy(DependencyObject d)
        {
            return (CollectionViewSourceProxy)d.GetValue(ProxyProperty);
        }

        public static void SetProxy(DependencyObject d, CollectionViewSourceProxy value)
        {
            d.SetValue(ProxyProperty, value);
        }

        private static void OnProxyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var proxy = GetProxy(d);
            if (proxy != null && proxy.CollectionViewSource != null)
            {
                var targetBinding = new Binding { Source = proxy.CollectionViewSource };
                var sourceBinding = new Binding { Path = new PropertyPath(proxy.SourceBindingPath), Source = d };

                BindingOperations.SetBinding(proxy.CollectionViewSource, CollectionViewSource.SourceProperty, sourceBinding);
                BindingOperations.SetBinding(d, proxy.TargetProperty, targetBinding);
            }
        }
    }
}
