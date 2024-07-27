using System;

namespace Pragma.ManualDebug
{
    public class EnumOverride : IOverrideParameter
    {
        public bool TryOverride(Type type, Parameter parameter)
        {
            if (type.IsEnum)
            {
                parameter.converter = new EnumConverter(type, true);
                parameter.styleType = ManualParamStyleType.Dropdown;

                return true;
            }

            return false;
        }
    }
}