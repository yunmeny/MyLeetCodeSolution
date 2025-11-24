using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution3))]
public class Solution3Test
{
    Solution3 _solution = new();
    
    [TestMethod]
    public void Test1()
    {
        var s = "abcabcbb";
        int expected = 3;
        int actual = _solution.LengthOfLongestSubstring(s);

        Assert.AreEqual(expected, actual, "计算错误");
    }

    [TestMethod]
    public void Test2()
    {
        var s = "tmmzuxt";
        int expected = 5;
        int actual = _solution.LengthOfLongestSubstring(s);
        Assert.AreEqual(expected, actual, "计算错误");
    }
    
    
}