using System.Text;

namespace LeetCodeSolution;

public class Solution30
{
    
    // 暴力解法，409ms,超级慢，但是自己写的，思路清晰
    // 目前想到的优化点：
    // 每个窗口都需重新分割所有单词并统计次数，重复计算量大
    public IList<int> FindSubstring(string s, string[] words)
    {
        var res = new List<int>();
        var wordLength = words[0].Length;
        var wordsLength = words.Length;
        var wLength = wordsLength * wordLength;
        var sLength = s.Length;
        var map = new Dictionary<string, int>();
        foreach (var word in words)
        {
            map[word] = map.GetValueOrDefault(word, 0) + 1;
        }
        var sb = new StringBuilder();
        var val = new Dictionary<string, int>();
        for (var right = 0; right < sLength; right ++)
        {
            var left = right - wLength + 1;
            if (left < 0) continue;
            for (var i = 0; i < wordsLength; i++)
            {
                var str = s.Substring(left + i * wordLength, wordLength);
                val[str] = val.GetValueOrDefault(str, 0) + 1;
            }
            var equal = true;
            foreach (var m in map)
            {
                if (val.GetValueOrDefault(m.Key, 0) == m.Value) continue;
                equal = false;
                break;
            }
            if (equal)
            {
                res.Add(left);
            }
            val.Clear();
        }
        return res;
    }


    // “aaaaaaaa”情况不适用
    // 可优化为 4
    public IList<int> FindSubstring3(string s, string[] words)
    {
        var res = new List<int>();
        var wordLength = words[0].Length;
        var wordsLength = words.Length;
        var sLength = s.Length;
        var map = new Dictionary<string, int>();
        foreach (var word in words)
        {
            map[word] = map.GetValueOrDefault(word, 0) + 1;
        }

        var sb = new StringBuilder();
        var val = new Dictionary<string, int>();
        var i = 0;
        while (i < sLength)
        {
            sb.Append(s[i]);
            if (sb.Length < wordLength)
            {
                i++;
                continue;
            }

            // 预计子串长度大于s剩余的长度，直接跳出循环
            if ((wordsLength - 1) * wordLength > sLength - i) break;

            if (!map.ContainsKey(sb.ToString()))
            {
                i++;
                sb.Remove(0, 1);
                continue;
            }

            // val[sb.ToString()] = val.GetValueOrDefault(sb.ToString(), 0) + 1;
            // 如果sb长度等于wordLength，说明找到了一个单词，开始向后展开窗口
            for (var right = i - wordLength + 1; right < s.Length; right += wordLength)
            {
                var str = s.Substring(right, wordLength);
                // 如果str不在map中，说明不匹配，直接跳过
                if (map.GetValueOrDefault(str, 0) == 0)
                {
                    i = right + wordLength;
                    sb.Clear();
                    val.Clear();
                    break;
                }

                val[str] = val.GetValueOrDefault(str, 0) + 1;
                var l = right - (wordsLength - 1) * wordLength;
                if (l < i - wordLength + 1) continue;
                var equal = true;
                foreach (var m in map)
                {
                    if (val.GetValueOrDefault(m.Key, 0) != m.Value)
                    {
                        equal = false;
                    }
                }

                if (equal)
                {
                    res.Add(l);
                }

                var lStr = s.Substring(l, wordLength);
                if (--val[lStr] == 0)
                {
                    val.Remove(lStr);
                }
            }
        }

        return res;
    }


    // 只考虑了单词长度相等的情况，没有考虑单词长度不相等的情况
    public IList<int> FindSubstring2(string s, string[] words)
    {
        var res = new List<int>();
        var wordLength = words[0].Length;
        var wordsLength = words.Length;
        var map = new Dictionary<string, int>();
        foreach (var word in words)
        {
            map[word] = map.GetValueOrDefault(word, 0) + 1;
        }

        var sb = new StringBuilder();
        var val = new Dictionary<string, int>();
        for (var r = 0; r < s.Length; r += wordLength)
        {
            var str = s.Substring(r, wordLength);
            val[str] = val.GetValueOrDefault(str, 0) + 1;
            var l = r - (wordsLength - 1) * wordLength;
            if (l < 0) continue;
            var equal = true;
            foreach (var i in map)
            {
                if (val.GetValueOrDefault(i.Key, 0) != i.Value)
                {
                    equal = false;
                }
            }

            if (equal)
            {
                res.Add(l);
            }

            var lStr = s.Substring(l, wordLength);
            if (--val[lStr] == 0)
            {
                val.Remove(lStr);
            }
        }

        return res;
    }
    
    public IList<int> FindSubstring4(string s, string[] words) {
        var result = new List<int>();
        // 边界条件
        if (string.IsNullOrEmpty(s) || words?.Length == 0)
        {
            return result;
        }
        
        int wordLen = words[0].Length;
        int wordCount = words.Length;
        int totalLen = wordLen * wordCount;
        int sLen = s.Length;

        if (sLen < totalLen)
            return result;

        // 步骤1：统计words中每个单词的频率
        Dictionary<string, int> wordFreq = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (wordFreq.ContainsKey(word))
                wordFreq[word]++;
            else
                wordFreq[word] = 1;
        }

        // 步骤2：按偏移遍历（0 ~ wordLen-1），覆盖所有合法分割方式
        for (var offset = 0; offset < wordLen; offset++)
        {
            var left = offset;          // 窗口左边界（当前偏移下的起始位置）
            var right = offset;         // 窗口右边界
            var matchCount = 0;         // 匹配的单词数（频率完全一致的单词）
            var windowFreq = new Dictionary<string, int>();

            // 滑动窗口：右边界每次移动 wordLen（一个完整单词）
            while (right + wordLen <= sLen)
            {
                // 1. 截取当前右边界的单词，加入窗口
                string currWord = s.Substring(right, wordLen);
                right += wordLen;

                // 提前终止：单词不在words中，重置窗口
                if (!wordFreq.ContainsKey(currWord))
                {
                    left = right;
                    windowFreq.Clear();
                    matchCount = 0;
                    continue;
                }

                // 更新窗口频率
                if (windowFreq.ContainsKey(currWord))
                    windowFreq[currWord]++;
                else
                    windowFreq[currWord] = 1;

                // 若当前单词频率匹配words，匹配数+1
                if (windowFreq[currWord] == wordFreq[currWord])
                    matchCount++;

                // 2. 窗口长度超过 totalLen，移除左边界的单词
                while (right - left > totalLen)
                {
                    string leftWord = s.Substring(left, wordLen);
                    left += wordLen;

                    // 若移除的单词之前频率匹配，匹配数-1
                    if (windowFreq[leftWord] == wordFreq[leftWord])
                        matchCount--;

                    windowFreq[leftWord]--;
                }

                // 3. 所有单词匹配，记录起始索引
                if (matchCount == wordFreq.Count)
                    result.Add(left);
            }
        }

        return result;
    }
}