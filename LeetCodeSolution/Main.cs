namespace LeetCodeSolution;

internal static class Program
{
    public static void Main(string[] args)
    {
        var res = Solution2461.MaximumSubarraySum([1,5,4,2,9,9,9], 3);
        Console.WriteLine("result:" + string.Join(",", res));
    }
}