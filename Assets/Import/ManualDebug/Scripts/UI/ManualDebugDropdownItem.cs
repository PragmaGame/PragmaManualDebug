using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ManualDebug
{
    public class ManualDebugDropdownItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _methodName;
        [SerializeField] private Button _button;

        public event Action<ManualDebugDropdownItem> ClickEvent;

        public string MethodName { get; private set; }
        
        public void Setup(string methodName)
        {
            MethodName = methodName;
            _methodName.text = methodName;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            ClickEvent?.Invoke(this);
        }
    }
}