using DebugPanel;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestReceiver2
    {
        [ManualDebugButton]
        public void MethodC()
        {
            Debug.Log("C");
        }
        
        [ManualDebugButton]
        public void MethodD()
        {
            Debug.Log("D");
        }
    }
}