using System;
using System.Collections.Generic;

namespace ManualDebug
{
    public abstract class AbstractParameterConverter : ParameterDefaultValueSetter
    {
        protected readonly Type conversionType;
        
        protected AbstractParameterConverter(Type conversionType, bool isСachedDefaultValues = false) : base(isСachedDefaultValues)
        {
            this.conversionType = conversionType;
        }
        
        public abstract object Convert(object value);
    }
}