using ManualDebug;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestReceiver2
    {
        [ManualDebugButton]
        public void SetHealth()
        {
            Debug.Log("SetHealth");
        }
        
        [ManualDebugButton]
        public void SetArmor()
        {
            Debug.Log("SetArmor");
        }
    }
}