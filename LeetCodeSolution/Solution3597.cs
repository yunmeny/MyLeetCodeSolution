using System.Text;

namespace LeetCodeSolution;

public class Solution3597
{
    // 暴力解法 时间复杂度为 O(n^2)
    public IList<string> PartitionString(string s)
    {
        var result = new List<string>();
        var length = s.Length;
        var charList = s.Select(c => c.ToString()).ToList();
        var sb = new StringBuilder();
        var i = 0;
        while (i < length)
        {
            if (!result.Contains(charList[i]))
            {
                result.Add(charList[i]);
                i++;
            }
            else
            {
                if (i + 1 >= length)
                {
                    i++;
                    continue;
                }

                sb.Clear();
                sb.Append(charList[i]);
                for (var j = i + 1; j < length; j++)
                {
                    sb.Append(charList[j]);
                    if (result.Contains(sb.ToString()))
                    {
                        if (j + 1 >= length)
                        {
                            i++;
                            break;
                        }

                        continue;
                    }

                    result.Add(sb.ToString());
                    i = j + 1;
                    break;
                }
            }
        }

        return result;
    }

    // 降低循环嵌套
    public IList<string> PartitionString2(string s)
    {
        var result = new List<string>();
        var tem = new HashSet<string>();
        var length = s.Length;
        var charList = s.Select(c => c.ToString()).ToList();
        var sb = new StringBuilder(charList[0]);
        var i = 0;
        var cur = charList[i];
        while (i < length)
        {
            if (tem.Add(sb.ToString()))
            {
                result.Add(sb.ToString());
                if (i + 1 == length) break;
                sb.Clear();
                sb.Append(charList[++i]);
                continue;
            }

            if (i + 1 == length) break;
            sb.Append(charList[++i]);
        }

        return result;
    }

    
    
    // 字典树解法
    public class Node
    {
        public Node[] son = new Node[26];

        public Node()
        {
        }
    }

    public IList<string> PartitionString3(string s)
    {
        var ans = new List<string>();
        Node root = new Node();
        Node cur = root;
        int left = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int m = s[i] - 'a';
            if (cur.son[m] == null)
            {
                cur.son[m] = new Node();
                ans.Add(s.Substring(left, i - left + 1));
                left = i + 1;
                cur = root;
            }
            else
            {
                cur = cur.son[m];
            }
        }

        return ans;
    }
}