using System;
using System.Collections.Generic;
using System.Linq;
using DuoVia.FuzzyStrings;
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

        public event Action<string> SelectedEvent; 

        private void Awake()
        {
            _dropdownItems = new List<ManualDebugDropdownItem>();
        }

        private void OnEnable()
        {
            _inputField.onValueChanged.AddListener(OnInputValueChanged);
        }

        private void OnDisable()
        {
            _inputField.onValueChanged.RemoveListener(OnInputValueChanged);
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
            SelectedEvent?.Invoke(item.MethodName);
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