using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Mvvm.Converters
{
    public sealed class TimeSpanToDoubleConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            var time = ((TimeSpan?)value) ?? TimeSpan.Zero;
            return time.TotalSeconds;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var secs = ((double?)value) ?? 0.0;
            return TimeSpan.FromSeconds(secs);
        }
    }
}
