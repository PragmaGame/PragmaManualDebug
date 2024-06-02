using System;
using ManualDebug;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestReceiver
    {
        [ManualDebugButton]
        public void SetLevel()
        {
            Debug.Log("SetLevel");
        }
        
        [ManualDebugButton]
        public void SetDamage()
        {
            Debug.Log("SetDamage");
        }
    }
}