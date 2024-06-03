using UnityEngine;
using UnityEngine.UI;

namespace ManualDebug
{
    public class ManualDebugPanel : MonoBehaviour
    {
        [SerializeField] private ManualDebugSearchPanel _searchPanel;
        [SerializeField] private ManualDebugInputBuilder _inputBuilder;

        [SerializeField] private Button _invokeButton;
        
        private ManualDebug _manualDebug;

        private string _selectedMethod;
        private object[] _selectedParams;
        
        public void SetManualDebug(ManualDebug manualDebug)
        {
            _manualDebug = manualDebug;
        
            _manualDebug.RefreshEvent += OnRefresh;
            
            OnRefresh();
        }

        private void OnRefresh()
        {
            _searchPanel.Refresh(_manualDebug.GetKeys);
        }

        private void OnEnable()
        {
            _searchPanel.SubmitEvent += OnSubmitSearch;
            _invokeButton.onClick.AddListener(OnInvoke);
        }

        private void OnDisable()
        {
            _searchPanel.SubmitEvent -= OnSubmitSearch;
            _invokeButton.onClick.RemoveListener(OnInvoke);
        }

        private void OnSubmitSearch(string value)
        {
            _selectedMethod = value;
            _inputBuilder.Build(_manualDebug.GetMethod(value));
        }

        private void OnInvoke()
        {
            _selectedParams = _inputBuilder.GetParam();
            
            _manualDebug.Invoke(_selectedMethod, _selectedParams);
        }
    }
}