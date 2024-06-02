using TMPro;
using UnityEngine;

namespace ManualDebug
{
    public class ManualDebugPanel : MonoBehaviour
    {
        [SerializeField] private ManualDebugSearchPanel _searchPanel;
        
        private ManualDebug _manualDebug;
        
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
    }
}