namespace LeetCodeSolution;

public class Solution3652
{
    public long MaxProfit(int[] prices, int[] strategy, int k) {
        var profit = 0L;
        var length = prices.Length;
        for (var i = 0; i < length; i++)
        {
            profit += prices[i] * strategy[i];
        }
        var res = profit;

        for (var r = 0; r < length; r++)
        {
            var left = r - k + 1;
            var mid = r - k / 2;
            profit -= prices[r] * strategy[r];
            profit += prices[r];
            if (mid < 0) continue;
            profit -= prices[mid];
            if (left < 0) continue;
            if (profit > res)
            {
                res = profit;
            }
            profit += prices[left] * strategy[left];
        }
        return res;
    }
}