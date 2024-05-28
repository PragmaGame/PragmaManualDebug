using System;
using DebugPanel;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestReceiver
    {
        [ManualDebugButton]
        public void MethodA()
        {
            Debug.Log("A");
        }
        
        [ManualDebugButton]
        public void MethodB()
        {
            Debug.Log("B");
        }
    }
}