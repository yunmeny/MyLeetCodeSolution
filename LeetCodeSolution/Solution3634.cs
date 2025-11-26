namespace LeetCodeSolution;

public class Solution3634
{
    public int MinRemoval(int[] nums, int k) {
        var res = nums.Length - 1;
        var sort = nums.OrderBy(x => x).ToList();
        var left = 0;
        for (var right = 1; right < sort.Count; right++)
        {
            if ((long)sort[left] * k >= sort[right])
            {
                var count = sort.Count - (right - left + 1);
                res = Math.Min(res, count);
                continue;
            }
            left++;
        }
        return res;
    }
}