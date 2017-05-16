using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Mvvm.Converters
{
    public sealed class StringFormatConverter : ValueConverterBase
    {
        public string Format { get; set; }

        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            return string.Format(Format, value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
