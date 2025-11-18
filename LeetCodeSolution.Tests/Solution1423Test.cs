using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution1423))]
public class Solution1423Test
{
    // 1. 实例化被测试类（每个测试方法独立创建，避免状态污染）
    private readonly Solution1423 _solution = new Solution1423();

    // 测试用例1：典型场景（从末尾拿3个）
    [TestMethod]
    public void MaxScore_End3Elements_Returns12()
    {
        // Arrange：准备测试数据（输入+预期结果）
        int[] cardPoints = [1, 2, 3, 4, 5, 6, 1];
        int k = 3;
        int expected = 12; // 5+6+1=12

        // Act：调用被测试方法
        int actual = _solution.MaxScore(cardPoints, k);

        // Assert：验证结果是否符合预期（核心）
        Assert.AreEqual(expected, actual, "从末尾拿3个元素的最大点数计算错误");
    }

    // 测试用例2：边界场景（k等于数组长度，拿所有元素）
    [TestMethod]
    public void MaxScore_KEqualsLength_ReturnsSum()
    {
        int[] cardPoints = [9, 7, 7, 9, 7, 7, 9];
        int k = 7;
        int expected = 55; // 9*3 + 7*4 = 55

        int actual = _solution.MaxScore(cardPoints, k);

        Assert.AreEqual(expected, actual, "k等于数组长度时，总和计算错误");
    }

    // 测试用例3：特殊场景（数组长度=k=2，所有组合）
    [TestMethod]
    public void MaxScore_SmallArray_ReturnsMax()
    {
        int[] cardPoints = [2, 2, 2];
        int k = 2;
        int expected = 4;

        int actual = _solution.MaxScore(cardPoints, k);

        Assert.AreEqual(expected, actual, "小数组场景计算错误");
    }

    [TestMethod]
    public void MaxScore2()
    {
        int[] cardPoints = [1, 1, 80, 4, 5, 6, 9];
        int k = 3;
        int expected = 82;

        int actual = _solution.MaxScore(cardPoints, k);

        Assert.AreEqual(expected, actual, "计算错误");
    }
    
}