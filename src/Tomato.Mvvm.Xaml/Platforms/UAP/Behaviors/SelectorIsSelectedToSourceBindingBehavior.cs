using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace Tomato.Mvvm.Behaviors
{
    public class SelectorIsSelectedToSourceBindingBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }

        public event Action<object, bool> Setter;

        public void Attach(DependencyObject associatedObject)
        {
            if (Setter == null)
                throw new InvalidOperationException($"{nameof(Setter)} property is invalid.");

            AssociatedObject = associatedObject;
            ((Selector)associatedObject).SelectionChanged += Selector_SelectionChanged;
        }

        private void Selector_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            e.AddedItems.Sink(o => Setter?.Invoke(o, true));
            e.RemovedItems.Sink(o => Setter?.Invoke(o, false));
        }

        public void Detach()
        {
            ((Selector)AssociatedObject).SelectionChanged -= Selector_SelectionChanged;
            AssociatedObject = null;
        }
    }
}
