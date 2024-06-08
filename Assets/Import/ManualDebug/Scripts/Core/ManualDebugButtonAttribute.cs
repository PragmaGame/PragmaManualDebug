using System;

namespace ManualDebug
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ManualDebugButtonAttribute : Attribute
    {
    }
}