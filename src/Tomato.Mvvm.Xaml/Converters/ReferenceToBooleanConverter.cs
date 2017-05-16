using System;
using System.Collections.Generic;
using System.Text;

namespace Tomato.Mvvm.Converters
{
    public sealed class ReferenceToBooleanConverter : ValueConverterBase
    {
        public bool Opposite { get; set; }

        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            return value == null ? Opposite : !Opposite;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
