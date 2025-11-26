namespace LeetCodeSolution;

public class Solution1208
{
    
    // 要理解不定长滑动窗口的含义
    // 着重体会长度的变化
    public int EqualSubstring(string s, string t, int maxCost)
    {
        var res = 0;
        var left = 0;
        var cost = 0;
        var len = s.Length;
        var costList = new int[len];
        for (var i = 0; i < len; i++)
        {
            costList[i] = Math.Abs(s[i] - t[i]);
        }
        for (var right = 0; right < len; right++)
        {
            cost += costList[right];
            if (cost <= maxCost)
            {
                res = Math.Max(right - left + 1, res);
            }
            else
            {
                cost -= costList[left];
                left++;
            }
        }
        return res;
    }
}