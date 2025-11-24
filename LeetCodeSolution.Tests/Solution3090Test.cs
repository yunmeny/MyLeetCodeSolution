using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution3090))]
public class Solution3090Test
{
    private readonly Solution3090 _solution = new();
    
    [TestMethod]
    public void Test1()
    {
        var s = "bcbbbbcba";
        int expected = 4;
        int actual = _solution.MaximumLengthSubstring(s);

        Assert.AreEqual(expected, actual, "计算错误");
    }

    [TestMethod]
    public void Test2()
    {
        var s = "aaaa";
        int expected = 2;
        int actual = _solution.MaximumLengthSubstring(s);
        Assert.AreEqual(expected, actual, "计算错误");
    }
    
    [TestMethod]
    public void Test3()
    {
        var s = "cbddcdcacc";
        int expected = 5;
        int actual = _solution.MaximumLengthSubstring(s);
        Assert.AreEqual(expected, actual, "计算错误");
    }
    
    [TestMethod]
    public void Test4()
    {
        var s = "yphmywmpyqtkxannjvxwnwvuqgvwjwlyxcigdihu";
        int expected = 19;
        int actual = _solution.MaximumLengthSubstring(s);
        Assert.AreEqual(expected, actual, "计算错误");
    }
}