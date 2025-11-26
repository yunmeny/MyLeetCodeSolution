using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution1208))]
public class Solution1208Test
{
    Solution1208 _solution = new Solution1208();
    
    [TestMethod]
    public void Test1()
    {
        var s = "abcd";
        var t = "bcdf";
        var maxCost = 3;
        var expected = 3;
        var actual = _solution.EqualSubstring(s, t, maxCost);
        Assert.AreEqual(expected, actual, "计算错误");
    }
    
    [TestMethod]
    public void Test2()
    {
        var s = "abcd";
        var t = "cdef";
        var maxCost = 3;
        var expected = 1;
        var actual = _solution.EqualSubstring(s, t, maxCost);
        Assert.AreEqual(expected, actual, "计算错误");
    }

    [TestMethod]
    public void Test3()
    {
        var s = "abcd";
        var t = "acde";
        var maxCost = 0;
        var expected = 1;
        var actual = _solution.EqualSubstring(s, t, maxCost);
        Assert.AreEqual(expected, actual, "计算错误");
    }
    
    [TestMethod]
    public void Test4()
    {
        var s = "krrgw";
        var t = "zjxss";
        var maxCost = 19;
        var expected = 2;
        var actual = _solution.EqualSubstring(s, t, maxCost);
        Assert.AreEqual(expected, actual, "计算错误");
    }
}