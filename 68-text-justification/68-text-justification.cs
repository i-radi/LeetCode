public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth) {
        if (words == null || words.Length == 0)
            return new List<string>();
        
        IList<string> res = new List<string>();
        
        for (int i = 0; i < words.Length; i++)
        {
                StringBuilder cur = new StringBuilder();
                int j = i,
                    len = 0;

                while (i < words.Length && len + words[i].Length + i - j <= maxWidth)
                    len += words[i++].Length;

                i--;

                if (j == i)
                {
                    int k = maxWidth - words[j].Length;

                    cur.Append(words[j]);

                    while (k-- > 0)
                        cur.Append(" ");
                }
                else if (i == words.Length - 1)
                {
                    int k = maxWidth;

                    while (j <= i)
                    {
                        cur.Append(words[j] + " ");
                        k -= words[j].Length + 1;
                        j++;
                    }
                    
                    cur = new StringBuilder(cur.ToString().Trim());
                    k++;
                    
                    while (k-- > 0)
                        cur.Append(" ");
                }
                else
                {
                    int baseCnt = (maxWidth - len) / (i - j),
                        cnt = (maxWidth - len) % (i - j);

                    if (cnt != 0)
                        while (cnt-- > 0)
                        {
                            int k = 0;

                            cur.Append(words[j++]);

                            while (k++ < baseCnt + 1)
                                cur.Append(" ");
                        }

                    while (j < i)
                    {
                        int k = 0;

                        cur.Append(words[j++]);

                        while (k++ < baseCnt)
                            cur.Append(" ");
                    }

                    cur.Append(words[j]);
                }

                res.Add(cur.ToString());
        }
        
        return res;
    }
}