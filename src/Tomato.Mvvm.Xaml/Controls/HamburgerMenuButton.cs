using System;
using System.Collections.Generic;
using System.Linq;
#if WINDOWS_UWP
using Windows.UI.Xaml.Controls;
#else
using System.Windows.Controls;
#endif

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace Tomato.Mvvm.Controls
{
    public sealed class HamburgerMenuButton : Button
    {
        public HamburgerMenuButton()
        {
            this.DefaultStyleKey = typeof(HamburgerMenuButton);
        }
    }
}
