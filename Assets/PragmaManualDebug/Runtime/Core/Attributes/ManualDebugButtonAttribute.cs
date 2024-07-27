using System;

namespace Pragma.ManualDebug
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ManualDebugButtonAttribute : Attribute
    {
        public string alias;
        
        public ManualDebugButtonAttribute(string alias = null)
        {
            this.alias = alias;
        }
    }
}