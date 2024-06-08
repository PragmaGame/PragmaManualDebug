using System;
using Object = UnityEngine.Object;

namespace ManualDebug
{
    public class UnityOverride : IOverrideParameter
    {
        public bool TryOverride(Type type, Parameter parameter)
        {
            if(typeof(Object).IsAssignableFrom(type))
            {
                parameter.converter = new UnityConverter(type, false);
                parameter.styleType = ManualParamStyleType.Dropdown;

                return true;
            }

            return false;
        }
    }
}