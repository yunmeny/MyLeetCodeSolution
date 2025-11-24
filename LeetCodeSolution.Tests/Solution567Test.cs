using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution567))]
public class Solution567Test
{
    
    private readonly Solution567 _solution = new();
    
    [TestMethod]
    public void Test1()
    {
        var s1 = "ab";
        var s2 = "eidbaooo";
        var actual = _solution.CheckInclusion(s1, s2);
        Assert.IsTrue(actual, "计算错误");
    }

    [TestMethod]
    public void Test2()
    {
        var s1 = "ab";
        var s2 = "eidboaoo";
        var actual = _solution.CheckInclusion(s1, s2);
        Assert.IsFalse(actual, "计算错误");
    }
}