namespace LeetCodeSolution;

public static class Solution2461
{
    public static long MaximumSubarraySum(int[] nums, int k) {
        var res = 0L;
        var sum = 0L;
        var dic = new Dictionary<int,int>();
        for (var r = 0; r < nums.Length; r++)
        {
            sum += nums[r];
            dic[nums[r]] = dic.GetValueOrDefault(nums[r], 0) + 1;
            var l = r - k + 1;
            if (l < 0) continue;
            if (dic.Count == k)
            {
                if (sum > res)
                {
                    res = sum;
                }
            }
            sum -= nums[l];
            if (--dic[nums[l]] == 0)
            {
                dic.Remove(nums[l]);
            }
        }
        return res;
    }
}