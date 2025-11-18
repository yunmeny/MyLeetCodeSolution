namespace LeetCodeSolution;

public class Solution1423
{
    
    // 滑动窗口解法
    // 看了别人的思路，受到的启发，逆向思维
    public int MaxScore(int[] cardPoints, int k)
    {
        var res = 0;
        var sum = cardPoints.Sum();
        var subSum = 0;
        var length = cardPoints.Length;
        var min = sum;
        for (var r = 0; r < length; r++)
        {
            subSum += cardPoints[r];
            var left = r - (length - k) + 1;
            if (left < 0) continue;
            if (left > r)
            {
                return sum;
            }
            if (subSum < min)
            {
                min = subSum;
                res = sum - subSum;
            }
            subSum -= cardPoints[left];
        }
        return res;
    }
}