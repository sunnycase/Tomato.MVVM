using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Tomato.Mvvm
{
    public static class VisualService
    {
        public static double GetDpiFactor(this Visual target)
        {
            var source = PresentationSource.FromVisual(target);
            return source == null ? 1.0 : 1 / source.CompositionTarget.TransformToDevice.M11;
        }
    }
}
