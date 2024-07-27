using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pragma.ManualDebug
{
    public class ManualDebugDropdownItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _methodName;
        [SerializeField] private Button _button;
        [SerializeField] private Vector2 _offset = new(25, 25);

        private RectTransform _rect;
        
        public event Action<ManualDebugDropdownItem> ClickEvent;

        public string MethodName { get; private set; }

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
        }

        public void Setup(string methodName)
        {
            MethodName = methodName;
            _methodName.text = methodName;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
            
            var width = LayoutUtility.GetPreferredSize(_methodName.rectTransform, 0);
            var height = LayoutUtility.GetPreferredSize(_methodName.rectTransform, 1);
            
            _rect.sizeDelta = new Vector2(width + _offset.x, height + _offset.y);
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