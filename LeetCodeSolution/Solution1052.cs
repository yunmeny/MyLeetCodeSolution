namespace LeetCodeSolution;

public class Solution1052
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        var maxSatisfied = 0;
        var satisfied = 0;
        var n = customers.Length;
        for (var i = 0; i < n; i++)
        {
            if (grumpy[i] == 0)
            {
                satisfied += customers[i];
            }
        }
        for (var r = 0; r < n; r++)
        {
            if (grumpy[r] == 1)
            {
                satisfied += customers[r];
            }
            var l = r - minutes + 1;
            if (l < 0) continue;
            if (satisfied > maxSatisfied)
            {
                maxSatisfied = satisfied;
            }
            if (grumpy[l] == 1)
            {
                satisfied -= customers[l];
            }
        }
        return maxSatisfied;
    }
}