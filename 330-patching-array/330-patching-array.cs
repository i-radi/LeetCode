 public class Solution
    {
        public int MinPatches(int[] nums, int n)
        {
            checked
            {
                (long from, long to) range = (1, 1);
                int res = 0;
                int idx = 0;

                while (n >= range.to)
                {
                    if (idx < nums.Length && nums[idx] <= range.to)
                    {
                        range = (range.from, range.to + nums[idx]);
                        idx++;
                    }
                    else
                    {
                        res++;
                        range = (range.from, 2 * range.to);
                    }
                }

                return res;
            }
        }
    }