using System;
using System.Globalization;

namespace ManualDebug
{
    public class PrimitiveConverter : AbstractParameterConverter
    {
        public PrimitiveConverter(Type conversionType) : base(conversionType)
        {
        }

        public override object Convert(object value)
        {
            return System.Convert.ChangeType(value, conversionType, CultureInfo.InvariantCulture);
        }
    }
}