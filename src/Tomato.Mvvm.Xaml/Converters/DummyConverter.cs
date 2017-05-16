using System;
using System.Collections.Generic;
using System.Text;

namespace Tomato.Mvvm.Converters
{
    public sealed class DummyConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
