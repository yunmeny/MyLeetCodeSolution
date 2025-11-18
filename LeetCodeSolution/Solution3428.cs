using System.Text;

namespace LeetCodeSolution;

public class Solution3428
{
    public static IEnumerable<int> GetAllSubsequences(int[] source, int k)
    {
        ArgumentNullException.ThrowIfNull(source);

        var list = source.ToList();
        var max = list.Max();
        var min = list.Min();
        var count = list.Count;
        Int128 all = (Int128)1 << count; // 结果为262144？ 2^18
        // 遍历所有可能的非空子集（2^count - 1种可能）
        for (Int128 i = 1; i < all; i++)
        {
            var subsequence = new HashSet<int>();
            var skip = false;
            // 检查每个位是否设置，确定是否包含对应元素
            for (var j = 0; j < count; j++)
            {
                if ((i & ((Int128)1 << j)) != 0)
                {
                    Console.Write(list[j] + " ");
                    subsequence.Add(list[j]);
                    if (subsequence.Contains(max) && subsequence.Contains(min))
                    {
                        yield return max + min;
                    }
                }

                if (subsequence.Count <= k) continue;
                skip = true;
                break;
            }

            if (!skip)
            {
                yield return subsequence.Max() + subsequence.Min();
            }
        }
    }

    public int MinMaxSums(int[] nums, int k)
    {
        var numsList = GetAllSubsequences(nums, k);
        var sums = 0;
        foreach (var i in numsList)
        {
            Console.WriteLine("sum:" + i);
            sums += i;
        }

        return (int)(sums % 1000000007L);
    }

    public List<int[]> GetSubQueue(int[] nums, int k)
    {
        var res = new List<int[]>();
        var subsequence = new List<int>();
        GenerateSubsequences(nums, res, k);
        // Dfs(nums, subsequence,0, res, k);
        return res;
    }

    // 优化思路：
    // 1. 使用数组代替List减少包装开销
    // 2. 采用共享缓冲区+长度标记的方式减少对象创建
    // 3. 避免不必要的复制操作
    private void GenerateSubsequences(int[] nums, List<int[]> res, int k)
    {
        if (nums == null || nums.Length == 0 || k <= 0)
            return;

        // 使用栈存储状态：当前索引、当前子序列缓冲区、当前长度
        Stack<Tuple<int, int[], int>> stack = new Stack<Tuple<int, int[], int>>();

        // 初始缓冲区容量设为k（最大可能长度），避免动态扩容
        stack.Push(Tuple.Create(0, new int[k], 0));

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            int index = current.Item1;
            int[] buffer = current.Item2;
            int length = current.Item3;

            // 只添加非空子序列
            if (length > 0)
            {
                // 仅复制有效长度的部分到新数组（避免完整复制缓冲区）
                int[] subSequence = new int[length];
                Array.Copy(buffer, subSequence, length);
                res.Add(subSequence);
            }

            // 达到最大长度则不再继续
            if (length >= k)
                continue;

            // 反向入栈保持原有顺序，同时复用缓冲区概念
            for (int i = nums.Length - 1; i >= index; i--)
            {
                // 创建新的缓冲区（避免共享修改问题）
                int[] newBuffer = new int[k];
                if (length > 0)
                {
                    Array.Copy(buffer, newBuffer, length);
                }

                newBuffer[length] = nums[i];

                stack.Push(Tuple.Create(i + 1, newBuffer, length + 1));
            }
        }
    }

    // 进一步优化：如果只需要计算min/max sum而不需要保存所有子序列
    // 可以在生成时直接计算，避免存储所有子序列（内存使用会大幅降低）
    private void CalculateMinMaxSumsDirectly(int[] nums, int k, out long minSum, out long maxSum)
    {
        minSum = long.MaxValue;
        maxSum = long.MinValue;
        int[] buffer = new int[k];

        CalculateHelper(nums, 0, buffer, 0, k, ref minSum, ref maxSum);
    }

    private void CalculateHelper(int[] nums, int index, int[] buffer, int length, int k,
        ref long minSum, ref long maxSum)
    {
        if (length > 0)
        {
            long sum = 0;
            for (int i = 0; i < length; i++)
                sum += buffer[i];

            if (sum < minSum) minSum = sum;
            if (sum > maxSum) maxSum = sum;
        }

        if (length >= k)
            return;

        for (int i = index; i < nums.Length; i++)
        {
            buffer[length] = nums[i];
            CalculateHelper(nums, i + 1, buffer, length + 1, k, ref minSum, ref maxSum);
        }
    }


    private void Dfs(int[] nums, List<int> subsequence, int index, List<List<int>> res, int k)
    {
        if (subsequence.Count > 0)
        {
            // 解引用
            var tem = subsequence.ToList();
            res.Add(tem);
            // Console.WriteLine(string.Join(" ", subsequence));
        }

        for (var i = index; i < nums.Length; i++)
        {
            if (subsequence.Count >= k)
            {
                break;
            }

            subsequence.Add(nums[i]); // 选择当前元素
            Dfs(nums, subsequence, i + 1, res, k); // 递归    
            subsequence.RemoveAt(subsequence.Count - 1); // 回溯
        }
    }


    
    
    // 数学分析解法
    private const int MOD = 1000000007;

    public int MinMaxSums2(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0 || k <= 0)
        {
            return 0;
        }

        // 排序数组，便于计算比当前元素小/大的数量
        Array.Sort(nums);
        int n = nums.Length;
        long total = 0;

        for (int i = 0; i < n; i++)
        {
            // 计算当前元素作为最大值的贡献次数
            int smallerCount = i; // 左侧比当前元素小的数量
            int maxSelect = Math.Min(k - 1, smallerCount); // 最多选k-1个（加上自己总长度≤k）
            long maxContribution = ComputeCombinationSum(smallerCount, maxSelect);

            // 计算当前元素作为最小值的贡献次数
            int largerCount = (n - 1) - i; // 右侧比当前元素大的数量
            int minSelect = Math.Min(k - 1, largerCount);
            long minContribution = ComputeCombinationSum(largerCount, minSelect);

            // 累加总贡献（当前元素×(作为max的次数+作为min的次数)）
            total = (total + (long)nums[i] * (maxContribution + minContribution)) % MOD;
        }

        return (int)total;
    }

    // 计算组合数之和：sum_{t=0 to m} C(a, t)，即从a个元素中选0~m个的总方案数
    private long ComputeCombinationSum(int a, int m)
    {
        if (a < 0 || m < 0) return 0;
        m = Math.Min(m, a); // 最多选a个（选超过a个的方案数为0）

        long sum = 0;
        long currentCombination = 1; // C(a, 0) = 1
        sum = currentCombination;

        for (int t = 1; t <= m; t++)
        {
            // 递推计算C(a, t) = C(a, t-1) * (a - t + 1) / t
            currentCombination = currentCombination * (a - t + 1) % MOD;
            currentCombination = currentCombination * ModInverse(t) % MOD;
            sum = (sum + currentCombination) % MOD;
        }

        return sum;
    }

    // 计算模逆元（费马小定理，MOD为质数）
    private long ModInverse(int x)
    {
        return Pow(x, MOD - 2);
    }

    // 快速幂计算：a^b mod MOD
    private static long Pow(long a, long b)
    {
        long result = 1;
        a %= MOD;
        while (b > 0)
        {
            if (b % 2 == 1)
            {
                result = result * a % MOD;
            }

            a = a * a % MOD;
            b /= 2;
        }

        return result;
    }
    
}