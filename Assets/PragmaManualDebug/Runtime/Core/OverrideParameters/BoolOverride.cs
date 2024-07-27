using System;

namespace Pragma.ManualDebug
{
    public class BoolOverride : IOverrideParameter
    {
        public bool TryOverride(Type type, Parameter parameter)
        {
            if (type == typeof(bool))
            {
                parameter.converter = new PrimitiveConverter(type, true);
                parameter.styleType = ManualParamStyleType.Toggle;
                parameter.isAllowedOverrideStyle = false;
                
                return true;
            }

            return false;
        }
    }
}