using ManualDebug;
using UnityEngine;

namespace Example
{
    public class TestContext
    {
        [ManualDebugButton]
        public void SetInt(int intValueName)
        {
            Debug.Log($"SetInt {intValueName}");
        }
        
        [ManualDebugButton]
        public void SetString(string stringValueName)
        {
            Debug.Log($"SetString {stringValueName}");
        }
    
        [ManualDebugButton]
        public void SetFloat(float floatValueName)
        {
            Debug.Log($"SetFloat {floatValueName}");
        }
    
        [ManualDebugButton]
        public void SetBool(bool boolValueName)
        {
            Debug.Log($"SetBool {boolValueName}");
        }
    
        [ManualDebugButton]
        public void SetEnum(TestEnum enumValueName)
        {
            Debug.Log($"SetEnum {enumValueName}");
        }

        [ManualDebugButton]
        [ManualParameterStyle(0, ManualParamStyleType.Dropdown, "GetStrings")]
        public void SetDropdownString(string stringValueName)
        {
            Debug.Log($"SetDropdownString {stringValueName}");
        }
    
        [ManualDebugButton("alias SetDropdownStringAndInt")]
        [ManualParameterStyle(0, ManualParamStyleType.Dropdown, new object [] {"str1", "str2"})]
        public void SetDropdownStringAndInt(string stringValueName, int intValueName)
        {
            Debug.Log($"SetDropdownStringAndInt string : {stringValueName} int : {intValueName}");
        }

        [ManualDebugButton]
        [ManualParameterStyle(1, ManualParamStyleType.Dropdown, new object [] {4, 8})]
        public void SetFloatAndDropdownInt(float floatValueName, int intValueName)
        {
            Debug.Log($"SetFloatAndDropdownInt float : {floatValueName} int : {intValueName}");
        }
    
        // Soon
        [ManualDebugButton]
        public void SetTestClass(TestClass testClass)
        {
            Debug.Log($"SetTestClass : {testClass}");
        }

        [ManualDebugButton]
        public void SetGameObject(GameObject gameObject)
        {
            Debug.Log($"SetGameObject : {gameObject}");
        }
    
        [ManualDebugButton]
        public void SetScriptableObject(TestScriptable scriptableObject)
        {
            Debug.Log($"SetScriptableObject : {scriptableObject}");
        }
    
        [ManualDebugButton]
        public void SetComponent(AbstractManualDebugInput input)
        {
            Debug.Log($"SetComponent input component : {input}");
        }

        public string[] GetStrings() => new[] { "DropdownString1", "DropdownString2" };
    
        public enum TestEnum
        {
            Element1 = 1,
            Element2 = 2,
        }
    
        public class TestClass
        {
            public int testClassIntA;
            public string testClassStringB;
        }
    }
}