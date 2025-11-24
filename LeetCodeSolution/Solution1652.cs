namespace LeetCodeSolution;

public class Solution1652
{
    public int[] Decrypt(int[] code, int k)
    {
        if (k == 0)
        {
            return new int[code.Length];
        }
        var res = new int[code.Length];
        var length = code.Length;
        for (var right = 0; right < length; right++)
        {
            if (k > 0)
            {
                for (var i = 1; i <= k; i++)
                {
                    res[right] += code[(right + i) % length];
                }
            }
            else
            {
                for (var i = -1; i >= k; i--)
                {
                    res[right] += code[(right + i + length) % length];
                }
            }
        }
        return res;
    }
}