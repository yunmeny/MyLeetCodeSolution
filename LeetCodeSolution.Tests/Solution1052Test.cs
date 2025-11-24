using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution1052))]
public class Solution1052Test
{
    private readonly Solution1052 _solution = new();

    [TestMethod]
    public void Test1()
    {
        int[] customers = [10,1,7];
        int[] grumpy = [0,0,0];
        int minutes = 2;
        int expected = 18;
        int actual = _solution.MaxSatisfied(customers, grumpy, minutes);

        Assert.AreEqual(expected, actual, "计算错误");
    }
}