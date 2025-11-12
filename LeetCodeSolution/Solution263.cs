namespace LeetCodeSolution;

public class Solution263
{
    // 递归解法 栈溢出
    public bool IsUgly(int n)
    {
        if (n < 0)
        {
            return false;
        }
        
        var divisors = new List<double> { 2, 3, 5 };
        
        
        if (n is 1 or 0)
        {
            return true;
        }

        var res = false;
        foreach (var divisor in divisors)
        {
            var d = n / divisor;
            if (n % divisor == 0)
            {
                res = IsUgly((int)d);
            }
            if (divisors.Contains(d))
            {
                return true;
            }
        }

        return res;
    }
    
    
    // 迭代解法
    public bool IsUgly2(int n)
    {
        // 丑数必须是正整数，排除 0 和负数
        if (n <= 0)
        {
            return false;
        }
        // 1 是丑数（无质因数）
        if (n == 1)
        {
            return true;
        }
        // 合法质因数（用 int 避免类型转换）
        int[] divisors = [2, 3, 5];
    
        // 对每个质因数，持续整除直到不能除
        foreach (int d in divisors)
        {
            while (n % d == 0)
            {
                n /= d; // 等价于 n = n / d
            }
        }
    
        // 剩余 n 为 1 → 所有质因数都是 2、3、5
        return n == 1;
    }
}