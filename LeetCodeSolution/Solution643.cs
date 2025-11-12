namespace LeetCodeSolution;

public static class Solution643
{
    
    // 精度出现问题float 换成 double
    public static double FindMaxAverage(int[] nums, int k) {
        var res = nums[..k].Average();
        var sum = 0d;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (i < k - 1) continue;
            var avg = sum / k;
            sum -= nums[i - k + 1];
            if (avg > res)
            {
                res = avg;
            }
        }
        return res;
    }
}