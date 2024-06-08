using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ManualDebug
{
    public abstract class AbstractManualDebugInput : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameParam;

        private string _nameTemplate;

        public abstract ManualParamStyleType Style { get; }
        
        protected virtual void Awake()
        {
            _nameTemplate = _nameParam.text;
        }

        public virtual void Setup(string nameParam, IEnumerable<string> defaultValues)
        {
            _nameParam.text = string.Format(_nameTemplate, nameParam);
        }

        public abstract object GetParam();
    }
}