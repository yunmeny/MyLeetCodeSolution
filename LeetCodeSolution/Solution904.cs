namespace LeetCodeSolution;

public class Solution904
{
    public int TotalFruit(int[] fruits)
    {
        var ans = 0;
        var left = 0;
        var length = fruits.Length;
        var exitFruit = new Dictionary<int,int>();
        for (var right = 0; right < length; right++)
        {
            exitFruit[fruits[right]] = exitFruit.GetValueOrDefault(fruits[right], 0) + 1;
            if (exitFruit.Count <= 2)
            {
                ans = Math.Max(ans, right - left + 1);
            }
            else
            {
                while (exitFruit.Count > 2)
                {
                    exitFruit[fruits[left]]--;
                    if (exitFruit[fruits[left]] == 0)
                    {
                        exitFruit.Remove(fruits[left]);
                    }
                    left++;
                }
            }
        }

        return ans;
    }
}