namespace LeetCodeSolution;

internal static class Program
{
    public static void Main(string[] args)
    {
        var res = Solution2090.GetAverages([1,11,17,21,29], 4);
        Console.WriteLine("result:" + string.Join(",", res));
    }
}