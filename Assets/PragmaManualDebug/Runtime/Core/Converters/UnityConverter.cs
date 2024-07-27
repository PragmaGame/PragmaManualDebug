using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Pragma.ManualDebug
{
    public class UnityConverter : AbstractParameterConverter
    {
        public UnityConverter(Type conversionType, bool isСachedDefaultValues) : base(conversionType, isСachedDefaultValues)
        {
        }

        public override object Convert(object value)
        {
            return Resources.FindObjectsOfTypeAll(conversionType).First(x => x.name == value.ToString());
        }

        protected override IEnumerable<string> InternalGetStringDefaultValues()
        {
            return Resources.FindObjectsOfTypeAll(conversionType).Select(x => x.name);
        }
    }
}