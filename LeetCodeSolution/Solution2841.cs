namespace LeetCodeSolution;

public static class Solution2841
{
    
    // 滑动窗口 自己写出来的 24ms 56.92% 我是最棒的小羊！
    public static long MaxSum(IList<int> nums, int m, int k) {
        var res = 0L;
        var sum = 0L;
        var dic = new Dictionary<int,int>();
        var l = 0;
        for (var r = 0; r < nums.Count; r++)
        {
            sum += nums[r];
            dic[nums[r]] = dic.GetValueOrDefault(nums[r], 0) + 1;
            if (r < k)
            {
                if (dic.Count >= m)
                {
                    res = sum;
                }
                continue;
            }
            sum -= nums[l];
            if (dic.ContainsKey(nums[l]) && --dic[nums[l]] == 0)
            {
                dic.Remove(nums[l]);
            }
            l++;
            if (dic.Count < m) continue;
            if (sum > res)
            {
                res = sum;
            }
        }
        return res;
    }
}