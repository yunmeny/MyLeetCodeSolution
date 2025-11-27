namespace LeetCodeSolution;

public class Solution1695
{
    // 动态滑窗，跟 904 题类似
    // 与 904 题相同的，运行时间较长，有明显的优化空间
    public int MaximumUniqueSubarray(int[] nums)
    {
        var ans = 0;
        var left = 0;
        var length = nums.Length;
        var existNum = new HashSet<int>();
        var sum = 0;
        for (var right = 0; right < length; right++)
        {
            if (existNum.Add(nums[right]))
            {
                sum += nums[right];
                ans = Math.Max(ans, sum);
            }
            else
            {
                while (existNum.Contains(nums[right]))
                {
                    existNum.Remove(nums[left]);
                    sum -= nums[left];
                    left++;
                }
                existNum.Add(nums[right]);
                sum += nums[right];
            }
        }
        return ans;
    }
    
    // 转换一下就变成了这样的代码，与解法 3 高度相似，但是 3 运行时间大幅下降
    // 运行时间基本不变
    public int MaximumUniqueSubarray4(int[] nums)
    {
        var ans = 0;
        var left = 0;
        var length = nums.Length;
        var existNum = new HashSet<int>();
        var sum = 0;
        for (var right = 0; right < length; right++)
        {
            while (existNum.Contains(nums[right]))
            {
                existNum.Remove(nums[left]);
                sum -= nums[left];
                left++;
            }
            existNum.Add(nums[right]);
            sum += nums[right];
            ans = Math.Max(ans, sum);
        }
        return ans;
    }

    // 这里给出了一个优化的解法，10ms 左右
    // 主要是利用了前缀和的思想，以及字典的存储
    // 这里的 pre 是指上一个相同元素的位置
    // 这样就可以直接计算出当前的子数组的和
    // 然后再更新字典中的值
    // 这样就可以避免重复计算
    // 时间复杂度为 O(n)，空间复杂度为 O(n)
    public int MaximumUniqueSubarray2(int[] nums)
    {
        var length = nums.Length;
        var preSum = new int[length + 1];
        var cnt = new Dictionary<int, int>();
        int res = 0, pre = 0;
        for (var i = 0; i < length; i++)
        {
            preSum[i + 1] = preSum[i] + nums[i];
            pre = Math.Max(pre, cnt.GetValueOrDefault(nums[i], 0));
            res = Math.Max(res, preSum[i + 1] - preSum[pre]);
            cnt[nums[i]] = i + 1;
        }

        return res;
    }

    // 还有一种更快的解法，3ms 左右
    // 主要是利用了数组的下标来存储元素的位置
    // 这样就可以直接计算出当前的子数组的和
    // 然后再更新数组中的值
    // 这样就可以避免重复计算
    // 时间复杂度为 O(n)，空间复杂度为 O(1)
    public int MaximumUniqueSubarray3(int[] nums)
    {
        var hash = new bool[10005];
        int ans = 0, cur = 0, l = 0;
        foreach (var num in nums)
        {
            while (hash[num])
            {
                hash[nums[l]] = false;
                cur -= nums[l];
                l++;
            }
            hash[num] = true;
            cur += num;
            ans = Math.Max(ans, cur);
        }
        return ans;
    }
}