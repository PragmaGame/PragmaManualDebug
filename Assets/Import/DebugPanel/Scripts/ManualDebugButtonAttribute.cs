using System;

namespace DebugPanel
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ManualDebugButtonAttribute : Attribute
    {
    }
}