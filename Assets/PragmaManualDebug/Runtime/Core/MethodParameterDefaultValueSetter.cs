using System.Collections.Generic;
using System.Reflection;

namespace Pragma.ManualDebug
{
    public class MethodParameterDefaultValueSetter : ParameterDefaultValueSetter
    {
        public MethodInfo setterMethod;
        public object setterContext;

        public MethodParameterDefaultValueSetter(bool isСachedDefaultValues) : base(isСachedDefaultValues)
        {
            
        }
        
        protected override IEnumerable<string> InternalGetStringDefaultValues()
        {
            return setterMethod.Invoke(setterContext, null) as IEnumerable<string>;
        }
    }
}