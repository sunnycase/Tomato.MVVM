using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Tomato.Mvvm.Controls
{
    public static class RichTextBoxExtensions
    {
        public static readonly DependencyProperty DocumentProperty = DependencyProperty.RegisterAttached("Document", typeof(FlowDocument),
            typeof(RichTextBoxExtensions), new PropertyMetadata(null, OnDocumentChanged));

        public static FlowDocument GetDocument(DependencyObject d)
        {
            return (FlowDocument)d.GetValue(DocumentProperty);
        }

        public static void SetDocument(DependencyObject d, FlowDocument value)
        {
            d.SetValue(DocumentProperty, value);
        }

        private static void OnDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var richTextBox = (RichTextBox)d;
            var newDocument = (FlowDocument)e.NewValue;
            if (newDocument != null)
                richTextBox.Document = newDocument;
        }
    }
}
