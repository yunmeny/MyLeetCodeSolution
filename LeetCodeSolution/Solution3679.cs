namespace LeetCodeSolution;

public class Solution3679
{
    public int MinArrivalsToDiscard(int[] arrivals, int w, int m)
    {
        var len = arrivals.Length;
        var res = 0;
        var dic = new Dictionary<int, int>();
        for (var right = 0; right < len; right++)
        {
            dic[arrivals[right]] = dic.GetValueOrDefault(arrivals[right], 0) + 1;
            if (dic[arrivals[right]] > m)
            {
                dic[arrivals[right]]--;
                res++;
                arrivals[right] = -1;
            }
            var left = right - w + 1;
            if (left < 0 || arrivals[left] == -1)
            {
                continue;
            }
            dic[arrivals[left]]--;
        }
        return res;
    }
}