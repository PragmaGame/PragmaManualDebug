using System;

namespace ManualDebug
{
    public class StringOverride : IOverrideParameter
    {
        public bool TryOverride(Type type, Parameter parameter)
        {
            if (type == typeof(string))
            {
                parameter.converter = new PrimitiveConverter(type);
                parameter.styleType = ManualParamStyleType.Primitive;

                return true;
            }

            return false;
        }
    }
}