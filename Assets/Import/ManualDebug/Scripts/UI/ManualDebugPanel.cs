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

        private MethodBind _selectedMethodBind;
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
            _selectedMethodBind = _manualDebug.GetBind(value);
            _inputBuilder.Build(_selectedMethodBind);
        }

        private void OnStartSearch()
        {
            _inputBuilder.ClearInputs();
        }

        private void OnInvoke()
        {
            _selectedParams = _inputBuilder.GetParam();

            _selectedMethodBind.Invoke(_selectedParams);
        }
    }
}