using System;
using ManualDebug;
using UnityEngine;

public class TestReceiver
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
    public void SetEnum(TestEnum enumValueName)
    {
        Debug.Log($"SetEnum {enumValueName}");
    }
}

public enum TestEnum
{
    Element1 = 1,
    Element2 = 2,
}