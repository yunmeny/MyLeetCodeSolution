namespace LeetCodeSolution;

public class Solution438
{
    public IList<int> FindAnagrams(string s, string p) {
        var res = new List<int>();
        var length = s.Length;
        var pLength = p.Length;
        var pCount = new Dictionary<char, int>();
        var sCount = new Dictionary<char, int>();
        for (var i = 0; i < pLength; i++)
        {
            pCount[p[i]] = pCount.GetValueOrDefault(p[i], 0) + 1;
        }
        for (var r = 0; r < length; r++)
        {
            sCount[s[r]] = sCount.GetValueOrDefault(s[r], 0) + 1;
            var left = r - pLength + 1;
            if (left < 0) continue;
            var flag = true;
            foreach (var (key, value) in pCount)
            {
                if (sCount.GetValueOrDefault(key, 0) != value)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                res.Add(left);
            }
            sCount[s[left]] -= 1;
        }
        return res;
    }
}