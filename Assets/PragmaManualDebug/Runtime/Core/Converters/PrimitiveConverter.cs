using System;
using System.Collections.Generic;
using System.Globalization;

namespace Pragma.ManualDebug
{
    public class PrimitiveConverter : AbstractParameterConverter
    {
        public PrimitiveConverter(Type conversionType, bool isСachedDefaultValues) : base(conversionType, isСachedDefaultValues)
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

        protected override IEnumerable<string> InternalGetStringDefaultValues() => null;
    }
}