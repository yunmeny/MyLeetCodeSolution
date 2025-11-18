using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution3679))]
public class Solution3679Test
{
    // 每个测试方法独立创建实例，避免状态污染
    private readonly Solution3679 _solution = new Solution3679();

    #region 示例场景测试
    /// <summary>
    /// 测试示例1：所有物品均可保留
    /// </summary>
    [TestMethod]
    public void MinimumDiscards_Example1_Returns0()
    {
        // Arrange
        int[] arrivals = { 1, 2, 1, 3, 1 };
        int w = 4;
        int m = 2;
        int expected = 0;

        // Act
        int result = _solution.MinArrivalsToDiscard(arrivals, w, m);

        // Assert
        Assert.AreEqual(expected, result, "示例1应返回0，所有物品均可保留");
    }

    /// <summary>
    /// 测试示例2：需丢弃1个重复物品
    /// </summary>
    [TestMethod]
    public void MinimumDiscards_Example2_Returns1()
    {
        // Arrange
        int[] arrivals = { 1, 2, 3, 3, 3, 4 };
        int w = 3;
        int m = 2;
        int expected = 1;

        // Act
        int result = _solution.MinArrivalsToDiscard(arrivals, w, m);

        // Assert
        Assert.AreEqual(expected, result, "示例2应丢弃第5天的物品3，返回1");
    }
    #endregion

    #region 边界情况测试
    /// <summary>
    /// 测试单个物品：必然保留
    /// </summary>
    [TestMethod]
    public void MinimumDiscards_SingleElement_Returns0()
    {
        // Arrange
        int[] arrivals = { 5 };
        int w = 1;
        int m = 1;
        int expected = 0;

        // Act
        int result = _solution.MinArrivalsToDiscard(arrivals, w, m);

        // Assert
        Assert.AreEqual(expected, result, "单个物品应直接保留");
    }

    /// <summary>
    /// 测试窗口大小=1：同一类型连续出现需多次丢弃
    /// </summary>
    [TestMethod]
    public void MinimumDiscards_WindowSize1_ContinuousSameType_ReturnsCorrectCount()
    {
        // Arrange
        int[] arrivals = { 2, 2, 2, 2 };
        int w = 1;
        int m = 1;
        int expected = 0; // 仅第1天保留，后3天均丢弃

        // Act
        int result = _solution.MinArrivalsToDiscard(arrivals, w, m);

        // Assert
        Assert.AreEqual(expected, result, "窗口大小1时，同一类型仅能保留1次");
    }

    /// <summary>
    /// 测试窗口大小=数组长度：全局限制同一类型次数
    /// </summary>
    [TestMethod]
    public void MinimumDiscards_WindowSizeEqualsLength_ReturnsCorrectCount()
    {
        // Arrange
        int[] arrivals = { 3, 3, 3, 3 };
        int w = 4;
        int m = 2;
        int expected = 2; // 全局最多2次，需丢弃2次

        // Act
        int result = _solution.MinArrivalsToDiscard(arrivals, w, m);

        // Assert
        Assert.AreEqual(expected, result, "窗口覆盖全数组时，需满足全局次数限制");
    }

    /// <summary>
    /// 测试m=w：同一类型可全部保留
    /// </summary>
    [TestMethod]
    public void MinimumDiscards_MEqualsW_AllSameType_Returns0()
    {
        // Arrange
        int[] arrivals = { 7, 7, 7 };
        int w = 3;
        int m = 3;
        int expected = 0; // 窗口内最多3次，刚好满足

        // Act
        int result = _solution.MinArrivalsToDiscard(arrivals, w, m);

        // Assert
        Assert.AreEqual(expected, result, "m等于w时，同一类型可全部保留");
    }
    #endregion

    #region 核心逻辑测试（滑动窗口特性）
    /// <summary>
    /// 测试滑动窗口：旧元素移出后可重新保留同类型新元素
    /// </summary>
    [TestMethod]
    public void MinimumDiscards_SlidingWindow_ExpireOldElement_Returns0()
    {
        // Arrange
        int[] arrivals = [1, 1, 2, 1, 1];
        int w = 3;
        int m = 2;
        int expected = 0; // 窗口滑动后，旧1移出，新1可保留

        // Act
        int result = _solution.MinArrivalsToDiscard(arrivals, w, m);

        // Assert
        Assert.AreEqual(expected, result, "滑动窗口应释放过期元素的配额");
    }

    /// <summary>
    /// 测试滑动窗口：同类型在窗口内刚好达限，新元素需丢弃
    /// </summary>
    [TestMethod]
    public void MinimumDiscards_SlidingWindow_SameTypeLimit_Returns1()
    {
        // Arrange
        int[] arrivals = { 4, 4, 4, 4 };
        int w = 3;
        int m = 2;
        // 第3天窗口[1-3]：4出现3次→丢弃；第4天窗口[2-4]：4出现2次→保留
        int expected = 1;

        // Act
        int result = _solution.MinArrivalsToDiscard(arrivals, w, m);

        // Assert
        Assert.AreEqual(expected, result, "窗口内同类型达限时需丢弃新元素");
    }

    /// <summary>
    /// 测试多类型混合：各类型均满足窗口限制
    /// </summary>
    [TestMethod]
    public void MinimumDiscards_MixedTypes_AllValid_Returns0()
    {
        // Arrange
        int[] arrivals = { 1, 1, 2, 2, 3, 3 };
        int w = 3;
        int m = 2;
        int expected = 0; // 所有窗口内各类型次数均≤2

        // Act
        int result = _solution.MinArrivalsToDiscard(arrivals, w, m);

        // Assert
        Assert.AreEqual(expected, result, "多类型混合且均满足限制时无需丢弃");
    }
    
    [TestMethod]
    public void MinimumDiscards2()
    {
        // Arrange
        int[] arrivals = [7,3,9,9,7,3,5,9,7,2,6,10,9,7,9,1,3,6,2,4,6,2,6,8,4,8,2,7,5,6];
        int w = 10;
        int m = 1;
        int expected = 13;

        // Act
        int result = _solution.MinArrivalsToDiscard(arrivals, w, m);

        // Assert
        Assert.AreEqual(expected, result, "计算错误");
    }
    #endregion
}