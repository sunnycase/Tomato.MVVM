using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Tomato.MVVM.Wpf
{
    public static class DependencyObjectExtensions
    {
        public static IEnumerable<T> GetLogicalChildren<T>(this DependencyObject me) where T : DependencyObject
        {
            foreach (object current in LogicalTreeHelper.GetChildren(me))
            {
                ;
                DependencyObject dependencyObject = current as DependencyObject;
                if (dependencyObject != null)
                {
                    if (dependencyObject != null && dependencyObject is T)
                    {
                        yield return (T)((object)dependencyObject);
                    }
                    foreach (T current2 in dependencyObject.GetLogicalChildren<T>())
                    {
                        yield return current2;
                    }
                }
            }
            yield break;
        }

        public static T FindFirstVisualChildOfType<T>(this DependencyObject parent) where T : class
        {
            if (parent != null)
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                    T childT = child as T;
                    if (childT != null)
                        return childT;
                    else
                    {
                        T grandChild = FindFirstVisualChildOfType<T>(child);
                        if (grandChild != null)
                            return grandChild;
                    }
                }
            return null;
        }

        public static T FindFirstVisualChildOfType<T>(this DependencyObject parent, Predicate<T> predicate)
            where T : class
        {
            if (parent != null)
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                    T childT = child as T;
                    if (childT != null && predicate(childT))
                        return childT;
                    else
                    {
                        T grandChild = FindFirstVisualChildOfType<T>(child, predicate);
                        if (grandChild != null)
                            return grandChild;
                    }
                }
            return null;
        }
    }
}
