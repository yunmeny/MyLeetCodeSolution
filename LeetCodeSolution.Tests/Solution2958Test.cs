using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution2958))]
public class Solution2958Test
{
    Solution2958 _solution = new Solution2958();

    [TestMethod]
    public void Test1()
    {
        var nums = new int[] { 1,2,3,1,2,3,1,2 };
        var k = 2;
        var res = _solution.MaxSubarrayLength(nums, k);
        Assert.AreEqual(6, res);
    }
    
    [TestMethod]
    public void Test2()
    {
        var nums = new int[] { 1,4,4,3 };
        var k = 1;
        var res = _solution.MaxSubarrayLength(nums, k);
        Assert.AreEqual(2, res);
    }
}