using System;

namespace ManualDebug
{
    public abstract class AbstractParameterConverter
    {
        protected readonly Type conversionType;
        
        protected AbstractParameterConverter(Type conversionType)
        {
            this.conversionType = conversionType;
        }
        
        public abstract object Convert(object value);
    }
}