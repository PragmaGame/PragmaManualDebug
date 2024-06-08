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

        private ManualMethod _selectedManualMethod;
        private object[] _selectedParams;
        
        public void SetManualDebug(ManualDebug manualDebug)
        {
            _manualDebug = manualDebug;
        
            _manualDebug.DirtyContextsEvent += OnDirtyContexts;
            
            OnDirtyContexts();
        }

        private void OnDirtyContexts()
        {
            _searchPanel.Refresh(_manualDebug.GetKeys());
        }

        private void OnEnable()
        {
            _searchPanel.SubmitEvent += OnSubmitSearch;
            _searchPanel.StartSearchEvent += OnStartSearch;
            _invokeButton.onClick.AddListener(OnInvoke);
        }

        private void OnDisable()
        {
            _searchPanel.SubmitEvent -= OnSubmitSearch;
            _searchPanel.StartSearchEvent -= OnStartSearch;
            _invokeButton.onClick.RemoveListener(OnInvoke);
        }

        private void OnSubmitSearch(string value)
        {
            _selectedManualMethod = _manualDebug.GetBind(value);
            _inputBuilder.Build(_selectedManualMethod);
        }

        private void OnStartSearch()
        {
            _inputBuilder.ClearInputs();
        }

        private void OnInvoke()
        {
            _selectedParams = _inputBuilder.GetParam();

            _selectedManualMethod.Invoke(_selectedParams);
        }
    }
}