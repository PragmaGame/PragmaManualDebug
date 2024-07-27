using Pragma.ManualDebug;
using UnityEngine;

namespace Example
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private TestScriptable _testScriptable;
        
        [SerializeField] private ManualDebugPanel _panel;
        
        private TestContext _testContext;
        private Pragma.ManualDebug.ManualDebug _manualDebug;

        private void Awake()
        {
            _testContext = new TestContext();

            _manualDebug = new Pragma.ManualDebug.ManualDebug();
            _panel.SetManualDebug(_manualDebug);
            
            _manualDebug.RegisterContexts(new object[]{_testContext}, true);
        }
    }
}