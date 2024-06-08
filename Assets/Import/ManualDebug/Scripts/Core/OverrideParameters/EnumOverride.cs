using System;

namespace ManualDebug
{
    public class EnumOverride : IOverrideParameter
    {
        public bool TryOverride(Type type, Parameter parameter)
        {
            if (type.IsEnum)
            {
                parameter.converter = new EnumConverter(type);
                parameter.styleType = ManualParamStyleType.Dropdown;

                parameter.setter = new ParameterDefaultValueSetter
                {
                    isСachedValues = true,
                    setterValues = Enum.GetNames(type),
                };

                return true;
            }

            return false;
        }
    }
}