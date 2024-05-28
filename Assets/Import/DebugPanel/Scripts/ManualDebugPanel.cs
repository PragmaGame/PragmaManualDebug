using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DebugPanel
{
    public class ManualDebugPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;
        
        private ManualDebug _manualDebug;
        
        public void SetManualDebug(ManualDebug manualDebug)
        {
            _manualDebug = manualDebug;
        
            _manualDebug.RefreshEvent += OnRefresh;
            
            OnRefresh();
        }

        private void OnRefresh()
        {
            _dropdown.options.Clear();

            foreach (var key in _manualDebug.GetKeys)
            {
                _dropdown.options.Add(new TMP_Dropdown.OptionData(key));
            }

            _dropdown.RefreshShownValue();
        }
    }
}