using System;
using TMPro;
using UnityEngine;

namespace ManualDebug
{
    public class ManualDebugValueTypeBuilderInput : AbstractBuilderInput
    {
        [SerializeField] protected TMP_InputField input;

        private Type _conversionType;
        
        public void SetConversionType(Type type)
        {
            _conversionType = type;
        }

        public override object GetParam()
        {
            return Convert.ChangeType(input.text, _conversionType);
        }
    }
}