namespace LeetCodeSolution;

public class Solution3090
{
    
    // 笨办法
    public int MaximumLengthSubstring(string s) {
        var res = 0;
        var length = s.Length;
        var map = new Dictionary<char, int[]>();
        var left = 0;
        for (var right = 0; right < length; right++)
        {
            if (!map.TryGetValue(s[right], out var value) || value[1] == 0)
            {
                map.TryAdd(s[right], new int[3]);
                map[s[right]][0] = right;
                map[s[right]][1]++;
                res = Math.Max(res, right + 1 -left);
            }
            else if (value[1] < 2)
            {
                map[s[right]][2] = right;
                map[s[right]][1]++;
                res = Math.Max(res, right + 1 -left);
            }
            else
            {
                for (var i = left; i < map[s[right]][0]; i++)
                {
                    if (map[s[i]][1] == 2)
                    {
                        map[s[i]][1]--;
                        map[s[i]][0] = map[s[i]][2];
                    }
                    else
                    {
                        map[s[i]][1] = 0;
                    }
                }
                left = map[s[right]][0] + 1;
                map[s[right]][0] = map[s[right]][2];
                map[s[right]][2] = right;
            }
        }
        return res;
    }
    
    public int MaximumLengthSubstring2(string S)
    {
        char[] s = S.ToCharArray();
        int ans = 0, pre = 0;
        int [] city = new int [26];
        for (int i = 0; i < s.Length; i++)
        {
            int p = s[i] - 'a';
            city[p]++;
            while (city[p] > 2)
            {
                city[s[pre] - 'a']--;
                pre++;
            }
            ans = Math.Max(ans, i - pre + 1);
        }
        return ans;
    }
}