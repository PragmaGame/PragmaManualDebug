using System;

namespace Pragma.ManualDebug
{
    public class PrimitiveOverride : IOverrideParameter
    {
        public bool TryOverride(Type type, Parameter parameter)
        {
            if (type.IsPrimitive)
            {
                parameter.converter = new PrimitiveConverter(type, true);
                parameter.styleType = ManualParamStyleType.Primitive;

                return true;
            }

            return false;
        }
    }
}