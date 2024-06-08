using UnityEngine;
using UnityEngine.UI;

namespace ManualDebug
{
    public class ManualDebugToggleInput : AbstractManualDebugInput
    {
        [SerializeField] protected Toggle _toggle;

        public override ManualParamStyleType Style => ManualParamStyleType.Toggle;

        public override object GetParam()
        {
            return _toggle.isOn;
        }
    }
}