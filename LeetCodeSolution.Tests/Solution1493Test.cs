using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution1493))]
public class Solution1493Test
{
    private readonly Solution1493 _solution = new();

    [TestMethod]
    public void Test1()
    {
        var nums = new[]{1,1,0,1};
        var expected = 3;
        var actual = _solution.LongestSubarray(nums);
        Assert.AreEqual(expected, actual, "计算错误");
    }
    
    [TestMethod]
    public void Test2()
    {
        var nums = new[]{0,1,1,1,0,1,1,0,1};
        var expected = 5;
        var actual = _solution.LongestSubarray(nums);
        Assert.AreEqual(expected, actual, "计算错误");
    }
    
    [TestMethod]
    public void Test3()
    {
        var nums = new[]{1,1,1};
        var expected = 2;
        var actual = _solution.LongestSubarray(nums);
        Assert.AreEqual(expected, actual, "计算错误");
    }
    
    [TestMethod]
    public void Test4()
    {
        var nums = new[]{0,0,1,1};
        var expected = 2;
        var actual = _solution.LongestSubarray(nums);
        Assert.AreEqual(expected, actual, "计算错误");
    }
}