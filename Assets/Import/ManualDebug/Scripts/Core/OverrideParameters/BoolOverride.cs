using System;

namespace ManualDebug
{
    public class BoolOverride : IOverrideParameter
    {
        public bool TryOverride(Type type, Parameter parameter)
        {
            if (type == typeof(bool))
            {
                parameter.converter = new PrimitiveConverter(type, true);
                parameter.styleType = ManualParamStyleType.Toggle;

                return true;
            }

            return false;
        }
    }
}