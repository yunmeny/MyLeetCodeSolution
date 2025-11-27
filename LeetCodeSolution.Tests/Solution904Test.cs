using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution904))]
public class Solution904Test
{
    Solution904 _solution = new();

    [TestMethod]
    public void Test1()
    {
        var arr = new[] { 1,2,1 };
        var res = _solution.TotalFruit(arr);
        Assert.AreEqual(3, res);
    }

    [TestMethod]
    public void Test2()
    {
        var arr = new[] { 1,2,3,2,2 };
        var res = _solution.TotalFruit(arr);
        Assert.AreEqual(4, res);
    }

    [TestMethod]
    public void Test3()
    {
        var arr = new[] { 0,1,2,2 };
        var res = _solution.TotalFruit(arr);
        Assert.AreEqual(3, res);
    }

    [TestMethod]
    public void Test4()
    {
        var arr = new[] { 3,3,3,1,2,1,1,2,3,3,4 };
        var res = _solution.TotalFruit(arr);
        Assert.AreEqual(5, res);
    }
}