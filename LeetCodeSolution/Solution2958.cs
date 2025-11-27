namespace LeetCodeSolution;

public class Solution2958
{
    // 动态滑窗，平平无常
    // 有一定的优化空间，但不是特别大
    public int MaxSubarrayLength(int[] nums, int k) {
        var ans = 0;
        var left = 0;
        var length = nums.Length;
        var exitNum = new Dictionary<int,int>();
        for (var right = 0; right < length; right++)
        {
            exitNum[nums[right]] = exitNum.GetValueOrDefault(nums[right], 0) + 1;
            if (exitNum[nums[right]] <= k)
            {
                ans = Math.Max(ans, right - left + 1);
            }
            else
            {
                while (exitNum[nums[right]] > k)
                {
                    exitNum[nums[left]]--;
                    left++;
                }
            }
        }
        return ans;
    }
}