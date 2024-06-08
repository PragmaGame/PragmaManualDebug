using System;
using ManualDebug;
using UnityEngine;
using Object = System.Object;

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