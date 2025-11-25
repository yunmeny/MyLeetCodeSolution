namespace LeetCodeSolution;

public class Solution1493
{
    
    // 还是比较暴力的解法，但是也能通过
    public int LongestSubarray(int[] nums)
    {
        var res = 0;
        var oneCount = 0;
        var zeroCount = 0;
        var left = 0;
        var sum = 0;
        var map = new Dictionary<int, int>();
        for (var right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 1)
            {
                oneCount++;
            }
            else
            {
                zeroCount++;
                var count = 0;
                res = Math.Max(res, oneCount);
                for (var i = right + 1; i < nums.Length; i++)
                {
                    if (nums[i] == 0)
                    {
                        if (count == 0)
                        {
                            oneCount = 0;
                            right = i - 1;
                            break;
                        }
                        oneCount = count;
                        right = i - 1;
                        break;
                    }
                    count++;
                    res = Math.Max(res, oneCount + count);
                }
            }
        }
        if (zeroCount == 0)
        {
            res = Math.Max(res, oneCount - 1);
        }
        return res;
    }
}