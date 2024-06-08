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
            if (value == null)
            {
                return Activator.CreateInstance(conversionType);
            }
            
            return System.Convert.ChangeType(value, conversionType, CultureInfo.InvariantCulture);
        }
    }
}