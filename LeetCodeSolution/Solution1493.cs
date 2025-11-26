namespace LeetCodeSolution;

public class Solution1493
{
    
    // 还是比较暴力的解法，但是也能通过
    public int LongestSubarray(int[] nums)
    {
        var res = 0;
        var oneCount = 0;
        var zeroCount = 0;
        for (var right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 1)
            {
                oneCount++;
            }
            else
            {
                zeroCount++;
                var count = 0;
                res = Math.Max(res, oneCount);
                for (var i = right + 1; i < nums.Length; i++)
                {
                    if (nums[i] == 0)
                    {
                        if (count == 0)
                        {
                            oneCount = 0;
                            right = i - 1;
                            break;
                        }
                        oneCount = count;
                        right = i - 1;
                        break;
                    }
                    count++;
                    res = Math.Max(res, oneCount + count);
                }
            }
        }
        if (zeroCount == 0)
        {
            res = Math.Max(res, oneCount - 1);
        }
        return res;
    }
    
    // 更简洁
    public int LongestSubarray2(int[] nums) {
        var i = 0;
        var j = 0;
        var cntZ = 0;
        var ans = 0;

        for (; j < nums.Length; j++) {
            cntZ += 1 - nums[j];
            while (cntZ > 1) {
                cntZ -= (1- nums[i++]);
            }
            ans = Math.Max(ans, j - i);
        }

        return ans;
    }
    
    public int LongestSubarray3(int[] nums) {
        int res=0;
        bool hasZero=false;
        int left=0,right=0;
        for(;right<nums.Length;right++){
            if(nums[right]==0){
                if(hasZero){
                    while(nums[left]!=0){
                        left++;
                    }
                    left++;
                }
                hasZero=true;
            }
            res=Math.Max(res,right-left);
        }
        return res;
    }
}