using System;

namespace Pragma.ManualDebug
{
    public interface IOverrideParameter
    {
        public bool TryOverride(Type type, Parameter parameter);
    }
}