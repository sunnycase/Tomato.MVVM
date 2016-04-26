using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Mvvm.Converters
{
    public sealed class BooleanNotConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            return !(bool)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return !(bool)value;
        }
    }
}
