using System.Collections.Generic;
using Sample;
using UnityEngine;

public enum MyEnum
{
    DummyEnum,
    NotDummyEnum
}
public class EnumComp : TesterBase
{
    public Dictionary<MyEnum, int> DummyDict { get; set; }

    public override void DoTest()
    {
        TestDefaultComp();
        TestGivenComp();
        Debug.LogFormat("EnumComp completed!");    
    }

    private void TestDefaultComp()
    {
        DummyDict = new();
        DictOperation();

    }

    private void TestGivenComp()
    {
        DummyDict = new(new Dictionary<MyEnum, int>(new MyEnumComparer()));
        DictOperation();
    }

    /// <summary>
    /// Do some hashcode-required method
    /// </summary>
    private void DictOperation()
    {
        if (!DummyDict.ContainsKey(MyEnum.DummyEnum))
        {
            DummyDict.Add(MyEnum.DummyEnum, 0);
        }
        if (!DummyDict.ContainsKey(MyEnum.NotDummyEnum))
        {
            DummyDict.Add(MyEnum.NotDummyEnum, 1);
        }
        DummyDict[MyEnum.DummyEnum] = DummyDict[MyEnum.NotDummyEnum];
    }
}


/// <summary>
/// Specify a comparer to avoid default comparer in Dict
/// </summary>
public class MyEnumComparer : IEqualityComparer<MyEnum>
{
    public bool Equals(MyEnum x, MyEnum y)
    {
        return (int)x == (int)y;
    }

    public int GetHashCode(MyEnum obj)
    {
        return (int)obj;
    }
}
