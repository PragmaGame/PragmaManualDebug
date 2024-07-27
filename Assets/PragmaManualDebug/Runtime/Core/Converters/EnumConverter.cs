using System;
using System.Collections.Generic;

namespace Pragma.ManualDebug
{
    public class EnumConverter : AbstractParameterConverter
    {
        public EnumConverter(Type conversionType, bool isСachedDefaultValues) : base(conversionType, isСachedDefaultValues)
        {
        }

        public override object Convert(object value)
        {
            if (value == null)
            {
                return Activator.CreateInstance(conversionType);
            }
            
            return Enum.Parse(conversionType, (string)value);
        }

        protected override IEnumerable<string> InternalGetStringDefaultValues()
        {
            return Enum.GetNames(conversionType);
        }
    }
}