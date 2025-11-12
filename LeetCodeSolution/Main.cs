namespace LeetCodeSolution;

internal static class Program
{
    public static void Main(string[] args)
    {
        Solution3428 solution = new Solution3428();
        // var res = solution.MinMaxSums([10,5,9,9,10,10,7,7,9,6,9,6,7,6,4,9,8,4,2,0,0,3,9,3,10,3,1,9,8,2,8,2,0,7,7,6,4,6,7,3,2,5,6,6,5,0,5,7,8,1], 29);
        // var res2 = solution.IsUgly(-2147483648);
        // Console.WriteLine("result:"+res2);

        var res = Solution2090.GetAverages([1,11,17,21,29], 4);
        Console.WriteLine("result:" + string.Join(",", res));
    }
}