using System.Collections.Generic;

namespace ManualDebug
{
    public class ParameterDefaultValueSetter
    {
        protected IEnumerable<string> setterValues;
        protected bool isСachedDefaultValues;

        public ParameterDefaultValueSetter(bool isСachedDefaultValues = false, IEnumerable<string> setterValues = null)
        {
            this.isСachedDefaultValues = isСachedDefaultValues;
            this.setterValues = setterValues;
        }

        public IEnumerable<string> GetStringDefaultValues()
        {
            if (isСachedDefaultValues && setterValues != null)
            {
                return setterValues;
            }
            
            setterValues = InternalGetStringDefaultValues();

            return setterValues;
        }

        protected virtual IEnumerable<string> InternalGetStringDefaultValues() => setterValues;
    }
}