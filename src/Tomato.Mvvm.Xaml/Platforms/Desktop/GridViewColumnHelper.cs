using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Controls;

namespace Tomato.Mvvm
{
    internal static class GridViewColumnHelper
    {
        private readonly static PropertyInfo DesiredWidthProperty =
            typeof(GridViewColumn).GetProperty("DesiredWidth", BindingFlags.NonPublic | BindingFlags.Instance);

        public static double GetColumnWidth(this GridViewColumn column)
        {
            return (double.IsNaN(column.Width)) ? (double)DesiredWidthProperty.GetValue(column, null) : column.Width;
        }
    }
}
