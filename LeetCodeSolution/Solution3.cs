namespace LeetCodeSolution;

public class Solution3
{
    public int LengthOfLongestSubstring(string s)
    {
        var res = 0;
        var length = s.Length;
        var map = new Dictionary<char, int>();
        var left = 0;
        for (var right = 0; right < length; right++)
        {
            if (map.TryAdd(s[right], right))
            {
                res = Math.Max(res, right + 1 -left);
            }
            else
            {
                var l = map[s[right]] + 1;
                for (var i = left; i < l; i++)
                {
                    map.Remove(s[i]);
                }
                map[s[right]] = right;
                left = l;
            }
        }
        return res;
    }
    
    public int LengthOfLongestSubstring2(string s) {
        var dict = new Dictionary<char,int>();
        int result = 0;
        int left = 0;
        for(int right = 0;right<s.Length;right++){
            if(dict.TryGetValue(s[right],out var val) &&val>=left){
                left = val+1;
            }
            dict[s[right]] = right;
            result = Math.Max(result,right-left+1);
        }
        return result;
    }
}