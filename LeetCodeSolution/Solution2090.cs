namespace LeetCodeSolution;

public static class Solution2090
{
    // 时间复杂度为 O(n)
    // 自己写的笨方法 10ms
    public static int[] GetAverages(int[] nums, int k)
    {
        if (k >= nums.Length || k * 2 + 1 >= nums.Length)
        {
            return Enumerable.Repeat(-1, nums.Length).ToArray();
        }
        var res = new int[nums.Length];
        
        var sum = (Int128)0;
        for (var i = 0; i < k; i++)
        {
            res[i] = -1;
            sum += nums[i];
        }

        for (var i = k; i < 2 * k; i++)
        {
            sum += nums[i];
        }
        for (var i = k; i < nums.Length; i++)
        {
            if (i + k >= nums.Length)
            {
                res[i] = -1;
            }
            else
            {
                sum += nums[i + k];
                res[i] = (int)(sum / (2 * k + 1));
                sum -= nums[i - k];
            }
        }

        return res;
    }
    
    
    // 其他题解 6ms
    // 窗口展开：从左到右，每次将窗口向右扩展一个元素。
    // 展开完全：当窗口大小达到 2k+1 时，展开完全。
    // 结果锚定：通过 right 右边界锚定结果的位置。
    public static int[] GetAverages2(int[] nums, int k)
    {
        var result = new int[nums.Length];

        Array.Fill(result, -1);
        long sum = 0;

        var left = 0;
        for (var right = 0; right < nums.Length; right++)
        {
            sum += nums[right];
            if (right - left != k * 2) continue;
            result[right - k] = (int)(sum / (k * 2 + 1));
            sum -= nums[left];
            left++;
        }

        return result;
    }
}