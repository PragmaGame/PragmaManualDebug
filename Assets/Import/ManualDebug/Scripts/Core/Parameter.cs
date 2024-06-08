using System;
using System.Collections.Generic;
using System.Reflection;

namespace ManualDebug
{
    public class Parameter
    {
        public string displayName;
        public ManualParamStyleType styleType;
        public AbstractParameterConverter converter;
        public ParameterDefaultValueSetter setter;
    }
}