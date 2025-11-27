using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution1695))]
public class Solution1695Test
{
    Solution1695 _solution1695 = new Solution1695();
    
    [TestMethod]
    public void Test1()
    {
        var nums = new[] {4,2,4,5,6};
        var res = _solution1695.MaximumUniqueSubarray(nums);
        Assert.AreEqual(17, res);
    }
    
    [TestMethod]
    public void Test2()
    {
        var nums = new[] {5,2,1,2,5,2,1,2,5};
        var res = _solution1695.MaximumUniqueSubarray(nums);
        Assert.AreEqual(8, res);
    }
}