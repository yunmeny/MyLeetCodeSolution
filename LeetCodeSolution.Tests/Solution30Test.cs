using System.Linq;
using JetBrains.Annotations;
using LeetCodeSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolution.Tests;

[TestClass]
[TestSubject(typeof(Solution30))]
public class Solution30Test
{
    Solution30 _solution = new Solution30();

    [TestMethod]
    public void Test1()
    {
        var s = "barfoothefoobarman";
        var words = new[] { "foo", "bar" };
        var expected = new[] { 0, 9 };
        var actual = _solution.FindSubstring(s, words).ToArray();
        CollectionAssert.AreEquivalent(expected, actual, "计算错误");
    }

    [TestMethod]
    public void Test2()
    {
        var s = "lingmindraboofooowingdingbarrwingmonkeypoundcake";
        var words = new[] { "fooo", "barr", "wing", "ding", "wing" };
        var expected = new[] { 13 };
        var actual = _solution.FindSubstring(s, words).ToArray();
        CollectionAssert.AreEquivalent(expected, actual, "计算错误");
    }

    [TestMethod]
    public void Test3()
    {
        var s = "a";
        var words = new[] { "a" };
        var expected = new[] { 0 };
        var actual = _solution.FindSubstring(s, words).ToArray();
        CollectionAssert.AreEquivalent(expected, actual, "计算错误");
    }

    [TestMethod]
    public void Test4()
    {
        var s = "ababababab";
        var words = new[] { "ababa", "babab" };
        var expected = new[] { 0 };
        var actual = _solution.FindSubstring(s, words).ToArray();
        CollectionAssert.AreEquivalent(expected, actual, "计算错误");
    }

    [TestMethod]
    public void Test5()
    {
        var s = "aaaaaaaaaaaaaa";
        var words = new[] { "aa", "aa" };
        var expected = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var actual = _solution.FindSubstring(s, words).ToArray();
        CollectionAssert.AreEquivalent(expected, actual, "计算错误");
    }
}