using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Mvvm.Converters
{
    public sealed class TimeSpanToStringConverter : ValueConverterBase
    {
        public string Format { get; set; } = string.Empty;

        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;
            return ((TimeSpan)value).ToString(Format);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
