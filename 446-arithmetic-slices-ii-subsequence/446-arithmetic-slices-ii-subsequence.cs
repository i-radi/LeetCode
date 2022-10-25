public class Solution {
 public int NumberOfArithmeticSlices(int[] nums) {
            int res = 0;
            var ldi = new List<Dictionary<int, int>>();
            int n = nums.Length;

            for (int j = 0; j < n; j++)
            {
                ldi.Add(new Dictionary<int, int>());
                for (int k = 0; k < j; k++)
                {
                    long tempkey = (long)nums[j] - (long)nums[k];
                    if (tempkey > int.MaxValue || tempkey < int.MinValue)
                        continue;

                    int key = (int)tempkey;

                    int d = ldi[j].ContainsKey(key) ? ldi[j][key] : 0;
                    int t = ldi[k].ContainsKey(key) ? ldi[k][key] : 0;

                    res += t;
                    ldi[j][key] = d + t + 1;
                }
            }

            return res;
    }
}