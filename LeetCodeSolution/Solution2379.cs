namespace LeetCodeSolution;

public static class Solution2379
{
    public static int MinimumRecolors(string blocks, int k)
    {
        var res = blocks.Length;
        var left = 0;
        var blocksCount = 0;
        for (var right = 0; right < blocks.Length; right++)
        {
            if (blocks[right] == 'W')
            {
                blocksCount++;
            }
            if (right < k)
            {
                res = blocksCount;
                continue;
            }
            if (blocks[left] == 'W')
            {
                blocksCount--;
            }
            left++;
            var curString = blocks.Substring(left, right - left + 1);
            if (blocksCount < res)
            {
                res = blocksCount;
            }
        }
        return res;
    }
}