using System;

namespace ManualDebug
{
    public interface IOverrideParameter
    {
        public bool TryOverride(Type type, Parameter parameter);
    }
}