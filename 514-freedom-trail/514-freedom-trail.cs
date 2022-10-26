public class Solution
    {
        private int Helper(IDictionary<char, IList<int>> char2RingIndices, ref string ring, ref string key, int ringIdx, int keyIdx, int?[,] dp)
        {
            if (keyIdx == key.Length)
            {
                return 0;
            }

            if (dp[ringIdx, keyIdx].HasValue)
            {
                return dp[ringIdx, keyIdx].Value;
            }

            checked
            {

                int res = int.MaxValue;

                foreach (var k in char2RingIndices[key[keyIdx]])
                {
                    var move = Math.Min(ringIdx + ring.Length - k, Math.Min(Math.Abs(ringIdx - k), (ring.Length - ringIdx + k)));
                    res = Math.Min(res, move + Helper(char2RingIndices, ref ring, ref key, k, keyIdx + 1, dp));
                }


                dp[ringIdx, keyIdx] = res;
                return res;
            }
        }

        public int FindRotateSteps(string ring, string key)
        {
            int?[,] dp = new int?[ring.Length, key.Length];

            IDictionary<char, IList<int>> char2RingIndices = new Dictionary<char, IList<int>>();

            for (int i = 0; i < ring.Length; i++)
            {
                if (!char2RingIndices.ContainsKey(ring[i]))
                {
                    char2RingIndices[ring[i]] = new List<int>();
                }
                char2RingIndices[ring[i]].Add(i);
            }

            return Helper(char2RingIndices, ref ring, ref key, 0, 0, dp) + key.Length;
        }
    }