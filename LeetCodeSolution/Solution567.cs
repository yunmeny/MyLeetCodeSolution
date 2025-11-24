namespace LeetCodeSolution;

public class Solution567
{
    public bool CheckInclusion(string s1, string s2) {
        var k = s1.Length;
        var length = s2.Length;
        var s1Count = new int[26];
        var s2Count = new int[26];

        for (var i = 0; i < k; i++)
        {
            s1Count[s1[i] - 'a']++;
        }
        for (var right = 0; right < length; right++)
        {
            s2Count[s2[right] - 'a']++;
            var left = right - k + 1;
            if (left < 0) continue;
            if (s1Count.SequenceEqual(s2Count))
            {
                return true;
            }
            s2Count[s2[left] - 'a']--;
        }
        return false;
    }
}