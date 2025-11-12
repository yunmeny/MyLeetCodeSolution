namespace LeetCodeSolution;

public static class Solution1343
{
    public static int NumOfSubrrays(int[] arr, int k, int threshold) {
        var res = 0;
        var sum = arr[..k].Sum();
        if (sum >= threshold * k)
        {
            res++;
        }
        for (var i = k; i < arr.Length; i++)
        {
            sum = sum - arr[i - k] + arr[i];
            if (sum >= threshold * k)
            {
                res++;
            }
        }
        return res;
    }
}