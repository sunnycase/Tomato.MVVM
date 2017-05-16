using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
#else
using System.Windows;
using System.Windows.Media;
#endif

namespace Tomato.Mvvm
{
    public static class DependencyObjectExtensions
    {
#if !WINDOWS_UWP
        public static IEnumerable<T> GetLogicalChildren<T>(this DependencyObject me) where T : DependencyObject
        {
            foreach (object current in LogicalTreeHelper.GetChildren(me))
            {
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
#endif

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

        public static T FindFirstVisualParentOfType<T>(this DependencyObject child) where T : class
        {
            while (child != null)
            {
                child = VisualTreeHelper.GetParent(child);
                T parent = child as T;
                if (parent != null)
                    return parent;
                else
                    return FindFirstVisualParentOfType<T>(child);
            }
            return null;
        }

        public static T FindFirstVisualParentOfType<T>(this DependencyObject child, Predicate<T> predicate) where T : class
        {
            while (child != null)
            {
                child = VisualTreeHelper.GetParent(child);
                T parent = child as T;
                if (parent != null && predicate(parent))
                    return parent;
                else
                    return FindFirstVisualParentOfType<T>(child, predicate);
            }
            return null;
        }

        public static T FindFirstVisualParentOrSelfOfType<T>(this DependencyObject child) where T : class
        {
            while (child != null)
            {
                T parent = child as T;
                if (parent != null)
                    return parent;
                else
                {
                    child = VisualTreeHelper.GetParent(child);
                    return FindFirstVisualParentOfType<T>(child);
                }
            }
            return null;
        }
    }
}
