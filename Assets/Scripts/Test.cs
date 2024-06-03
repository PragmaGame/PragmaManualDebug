using ManualDebug;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private ManualDebugPanel _panel;
        
    private TestReceiver _testReceiver;
    private ManualDebug.ManualDebug _manualDebug;

    private void Awake()
    {
        _testReceiver = new TestReceiver();

        _manualDebug = new ManualDebug.ManualDebug();
        _panel.SetManualDebug(_manualDebug);
            
        _manualDebug.AddContexts(new object[]{_testReceiver}, true);
    }
}