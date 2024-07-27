using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Pragma.ManualDebug
{
    public class ManualDebugDropdownInput : AbstractManualDebugInput
    {
        [SerializeField] protected TMP_Dropdown dropdown;

        protected List<string> values;

        public override ManualParamStyleType Style => ManualParamStyleType.Dropdown;

        public override void Setup(string nameParam, IEnumerable<string> defaultValues)
        {
            base.Setup(nameParam, defaultValues);
            
            values = defaultValues.ToList();
            
            dropdown.AddOptions(values);
            dropdown.RefreshShownValue();
        }

        public override object GetParam()
        {
            return values[dropdown.value];
        }
    }
}