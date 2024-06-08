using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ManualDebug
{
    public class ManualDebugSearchPanel : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private ScrollRect _scroll;
        
        [SerializeField] private ManualDebugDropdownItem _prefab;

        private List<ManualDebugDropdownItem> _dropdownItems;
        private ManualDebugDropdownItem _selectedItem;

        public event Action<string> SubmitEvent;
        public event Action StartSearchEvent;

        private void Awake()
        {
            _dropdownItems = new List<ManualDebugDropdownItem>();
        }

        private void OnEnable()
        {
            _inputField.onValueChanged.AddListener(OnInputValueChanged);
            _inputField.onSelect.AddListener(OnInputSelect);
            _inputField.onSubmit.AddListener(OnSubmit);
        }

        private void OnDisable()
        {
            _inputField.onValueChanged.RemoveListener(OnInputValueChanged);
            _inputField.onSelect.RemoveListener(OnInputSelect);
            _inputField.onSubmit.RemoveListener(OnSubmit);
        }

        public void Refresh(List<string> keys)
        {
            foreach (var item in _dropdownItems)
            {
                item.ClickEvent -= OnClickDropdownItem;
                Destroy(item);
            }
            
            _dropdownItems.Clear();

            foreach (var key in keys)
            {
                var item = Instantiate(_prefab, _scroll.content);
                _dropdownItems.Add(item);
                item.Setup(key);
                item.ClickEvent += OnClickDropdownItem;
            }
        }

        private void OnClickDropdownItem(ManualDebugDropdownItem item)
        {
            _inputField.text = item.MethodName;
            SubmitEvent?.Invoke(item.MethodName);
            _scroll.gameObject.SetActive(false);
        }

        private void OnInputSelect(string value)
        {
            _scroll.gameObject.SetActive(true);
            
            StartSearchEvent?.Invoke();
        }

        private void OnSubmit(string value)
        {
            _scroll.gameObject.SetActive(false);
        }

        private void OnInputValueChanged(string value)
        {
            var sorted = _dropdownItems.OrderByDescending(x => value.FuzzyMatch(x.MethodName)).ToArray();

            for (var i = 0; i < sorted.Length; i++)
            {
                sorted[i].transform.SetSiblingIndex(i);
            }
        }
    }
}