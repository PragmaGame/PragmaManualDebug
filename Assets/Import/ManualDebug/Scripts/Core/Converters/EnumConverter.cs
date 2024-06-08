using System;

namespace ManualDebug
{
    public class EnumConverter : AbstractParameterConverter
    {
        public EnumConverter(Type conversionType) : base(conversionType)
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
    }
}