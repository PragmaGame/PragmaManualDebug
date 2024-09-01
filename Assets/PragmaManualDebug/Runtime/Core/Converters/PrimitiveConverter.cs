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
                try
                {
                    return Activator.CreateInstance(conversionType);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            
            return System.Convert.ChangeType(value, conversionType, CultureInfo.InvariantCulture);
        }

        protected override IEnumerable<string> InternalGetStringDefaultValues() => null;
    }
}