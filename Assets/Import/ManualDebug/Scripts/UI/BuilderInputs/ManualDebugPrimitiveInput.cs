using System;
using TMPro;
using UnityEngine;

namespace ManualDebug
{
    public class ManualDebugPrimitiveInput : AbstractManualDebugInput
    {
        [SerializeField] protected TMP_InputField input;

        public override ManualParamStyleType Style => ManualParamStyleType.Primitive;

        public override object GetParam()
        {
            return input.text;
        }
    }
}