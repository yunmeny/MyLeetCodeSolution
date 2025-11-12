using System.Text;

namespace LeetCodeSolution;

public class Solution1456
{
    
    // 滑动窗口 时间复杂度为 O(kn)
    public static int MaxVowels(string s, int k) {
        var win = s[..k];
        var count = win.Count(e=>IsVowel(e) == 1);
        var max = count;
        var sb = new StringBuilder(win);
        for (var i = k; i < s.Length; i++)
        {
            count = count - IsVowel(sb[0]) + IsVowel(s[i]);
            sb.Remove(0, 1);
            sb.Append(s[i]);
            if (count > max)
            {
                max = count;
            }
        }
        return max;
    }

    private static int IsVowel(char c)
    {
        return c switch
        {
            'a' or 'e' or 'i' or 'o' or 'u' => 1,
            _ => 0
        };
    }
    
    public static int MaxVowels2(string s, int k) {
        var count = 0;
        // 计算初始窗口
        for (var i = 0; i < k; i++) {
            if (IsVowel2(s[i])) {
                count++;
            }
        }
    
        if (count == k) {
            return k; // 提前退出
        }
    
        var max = count;
    
        // 滑动窗口
        for (var i = k; i < s.Length; i++) {
            // 移除左侧字符
            if (IsVowel2(s[i - k])) {
                count--;
            }
            // 添加右侧字符
            if (IsVowel2(s[i])) {
                count++;
            }
            // 更新最大值
            if (count <= max) continue;
            max = count;
            if (max == k) {
                break; // 提前退出
            }
        }
    
        return max;
    }

    private static bool IsVowel2(char c) {
        return c is 'a' or 'e' or 'i' or 'o' or 'u';
    }
    
    public static int MaxVowels3(string s, int k) {
        int count = 0;
        for (int i = 0; i < k; i++) {
            char c = s[i];
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') {
                count++;
            }
        }
        if (count == k) return k;
        int max = count;
        for (int i = k; i < s.Length; i++) {
            char leftChar = s[i - k];
            if (leftChar == 'a' || leftChar == 'e' || leftChar == 'i' || leftChar == 'o' || leftChar == 'u') {
                count--;
            }
            char rightChar = s[i];
            if (rightChar == 'a' || rightChar == 'e' || rightChar == 'i' || rightChar == 'o' || rightChar == 'u') {
                count++;
            }
        
            if (count > max) {
                max = count;
                if (max == k) break;
            }
        }
    
        return max;
    }
    
    // 不安全代码
    
    // 循环展开
    
    // 预计算元音表
    
}