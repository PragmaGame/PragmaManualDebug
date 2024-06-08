using System;

namespace ManualDebug
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ManualParameterStyleAttribute : Attribute
    {
        public int position;
        public ManualParamStyleType styleType;
        public string defaultValueSetterMethodName;
        public bool isСachedValues;
        public object[] defaultValues;

        public ManualParameterStyleAttribute(int position = 0, ManualParamStyleType styleType = ManualParamStyleType.Primitive)
        {
            this.position = position;
            this.styleType = styleType;
        }
        
        public ManualParameterStyleAttribute(int position, ManualParamStyleType styleType, string defaultValueSetterMethodName, bool isСachedValues = false) : this(position, styleType)
        {
            this.defaultValueSetterMethodName = defaultValueSetterMethodName;
        }
        
        public ManualParameterStyleAttribute(int position, ManualParamStyleType styleType, object[] defaultValues) : this(position, styleType)
        {
            this.position = position;
            this.styleType = styleType;
            this.defaultValues = defaultValues;
        }
    }
}