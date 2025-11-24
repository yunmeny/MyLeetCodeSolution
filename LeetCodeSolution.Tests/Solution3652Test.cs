using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution3652))]
public class Solution3652Test
{
    private readonly Solution3652 _solution = new Solution3652();

    [TestMethod]
    public void Test1()
    {
        int[] prices = [4,2,8];
        int[] strategy = [-1,0,1];
        int k = 2;
        int expected = 10;
        long actual = _solution.MaxProfit(prices, strategy, k);

        Assert.AreEqual(expected, actual, "计算错误");
    }
}