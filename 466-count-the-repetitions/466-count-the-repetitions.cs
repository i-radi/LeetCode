public class Solution {
     public int GetMaxRepetitions(string s1, int n1, string s2, int n2)
        {
            var h1 = new HashSet<char>();
            var h2 = new HashSet<char>();

            for (int i = 0; i < s1.Length; i++)
                h1.Add(s1[i]);

            for (int i = 0; i < s2.Length; i++)
                h2.Add(s2[i]);

            var it = h2.GetEnumerator();
            while (it.MoveNext())
            {
                // if s2 contains something that s1 does not.
                if (!h1.Contains(it.Current)) return 0; 
            }
            
            if (h1.Count() == 1 && h2.Count() == 1)
            {
                //For cases like "aaaaaaaaaaaa...." and "aa.."
                return ((n1 * s1.Length) / (n2 * s2.Length));
            }

            //Lens stores the length of a string that contains one "s2" and begins at index i.
            var lens = new int[s1.Length];

            for (int i = 0; i < s1.Length; i++)
            {
                int j = 0;
                int c = 0;

                while (j < s2.Length)
                {
                    if (s2[j] == s1[((i + c) % s1.Length)])
                        j++;
                    c++;
                }

                lens[i] = c - 1;
            }

            int count = 0;
            int total_length = s1.Length * n1;

            int temp = 0;
            int k = 0;
            int cur_index = 0;

            while (true)
            {
                k += lens[cur_index] + 1;
                if (k > total_length) break;

                temp++;
                if (temp == n2)
                {
                    count++;
                    temp = 0;
                }
                cur_index = (cur_index + lens[cur_index] + 1) % s1.Length;
            }

            return count;
        }
}