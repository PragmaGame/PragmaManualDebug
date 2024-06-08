using System.Collections.Generic;
using System.Reflection;

namespace ManualDebug
{
    public class ParameterDefaultValueSetter
    {
        public bool isСachedValues;
        public IEnumerable<string> setterValues;
        public MethodInfo setterMethod;
        public object setterContext;

        public IEnumerable<string> GetDefaultValues()
        {
            if (isСachedValues && setterValues != null)
            {
                return setterValues;
            }
            
            setterValues = setterMethod.Invoke(setterContext, null) as IEnumerable<string>;

            return setterValues;
        }
    }
}