using System;
using System.Collections.Generic;
using System.Reflection;

namespace ManualDebug
{
    public class Parameter
    {
        public string displayName;
        public ManualParamStyleType styleType;
        public bool isAllowedOverrideStyle = true;
        public AbstractParameterConverter converter;
        public ParameterDefaultValueSetter extraSetter;

        public IEnumerable<string> GetDefaultValues()
        {
            return extraSetter == null ? converter.GetStringDefaultValues() : extraSetter.GetStringDefaultValues();
        }
    }
}