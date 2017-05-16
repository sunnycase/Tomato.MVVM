using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace Tomato.Mvvm.Controls
{
    public class AutoSizedGridView : GridView
    {
        protected override void PrepareItem(ListViewItem item)
        {
            foreach (GridViewColumn column in Columns)
            {
                //setting NaN for the column width automatically determines the required width enough to hold the content completely.
                //if column width was set to NaN already, set it ActualWidth temporarily and set to NaN. This raises the property change event and re computes the width.
                var oldBinding = BindingOperations.GetBinding(column, GridViewColumn.WidthProperty);
                if (double.IsNaN(column.Width)) column.Width = column.ActualWidth;
                if (oldBinding != null)
                    BindingOperations.SetBinding(column, GridViewColumn.WidthProperty, oldBinding);
                else
                    column.Width = double.NaN;
            }
            base.PrepareItem(item);
        }
    }
}
