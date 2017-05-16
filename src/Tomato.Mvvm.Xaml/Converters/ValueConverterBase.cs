using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
#if WINDOWS_UWP
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;
#endif

namespace Tomato.Mvvm.Converters
{
    public abstract class ValueConverterBase : IValueConverter
    {
        public abstract object Convert(object value, Type targetType, object parameter, string language);

        public abstract object ConvertBack(object value, Type targetType, object parameter, string language);

#if !WINDOWS_UWP
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture.IetfLanguageTag);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBack(value, targetType, parameter, culture.IetfLanguageTag);
        }
#endif
    }
}
