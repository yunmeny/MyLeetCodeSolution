namespace LeetCodeSolution;

public class Quaternion(int q1, int q2, int q3, int q4)
{
    int q1 = q1;
    int q2 = q2;
    int q3 = q3;
    int q4 = q4;

    public void SetValue(int q1, int q2, int q3, int q4)
    {
        this.q1 = q1;
        this.q2 = q2;
        this.q3 = q3;
        this.q4 = q4;
    }
    public bool IsRight()
    {
        return q4 == q1 + q2 + q3;
    }
}

// 暴力解法 时间复杂度为 O(n^4)
public class Solution1995
{
    public int CountQuadruplets(int[] nums)
    {

        var count = 0;
        var quaternion = new Quaternion(0, 0, 0, 0);
        
        for (var i = nums.Length - 1; i > 2; i--)
        {
            for (var j = 0; j < i; j++)
            {
                for (var k = j + 1; k < i; k++)
                {
                    for (var l = k + 1; l < i; l++)
                    {
                        quaternion.SetValue(nums[j], nums[k], nums[l], nums[i]);
                        if (quaternion.IsRight())
                        {
                            count++;
                        }
                    }
                }
            }
        }
        return count;
    }
    
    // 大神解法 总耗时7ms
    public int CountQuadruplets3(int[] nums)
    {
        var len = nums.Length;
        var ret = 0;
        var dic = new Dictionary<int, int> { { nums[0] + nums[1], 1 } };
        //C
        for (var i = 2; i < len; i++)
        {
            //D
            for (var j = i + 1; j < len; j++)
            {
                if (dic.ContainsKey(nums[j] - nums[i]))
                    ret += dic[nums[j] - nums[i]];
            }

            for (var j = 0; j < i; j++)
            {
                // A + B
                dic.TryAdd(nums[j] + nums[i], 0);
                dic[nums[j] + nums[i]]++;
            }
        }

        return ret;
    }
}