using System;
using ManualDebug;
using NaughtyAttributes;
using UnityEngine;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private ManualDebugPanel _panel;
        
        private TestReceiver _testReceiver;
        private TestReceiver2 _testReceiver2;
        private ManualDebug.ManualDebug _manualDebug;

        private void Awake()
        {
            _testReceiver = new TestReceiver();
            _testReceiver2 = new TestReceiver2();
            
            _manualDebug = new ManualDebug.ManualDebug();
            _panel.SetManualDebug(_manualDebug);
            
            _manualDebug.AddReceivers(new object[]{_testReceiver, _testReceiver2}, true);
        }
    }
}