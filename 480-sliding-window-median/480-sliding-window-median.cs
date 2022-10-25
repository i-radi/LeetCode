public class Solution
{
    public double[] MedianSlidingWindow(int[] nums, int k)
    {
        var res = new List<double>();
        var sl = new SortedList<long, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            sl.Add(GetId(i, nums), nums[i]);
            if (sl.Count > k)
            {
                sl.Remove(GetId(i - k, nums));
            }
            if (sl.Count == k)
            {
                if (k % 2 == 0) res.Add((sl[sl.Keys[k / 2 - 1]] / 2.0 + sl[sl.Keys[k / 2]] / 2.0));
                else res.Add(sl[sl.Keys[k / 2]]);
            }
        }

        return res.ToArray();
    }

    public long GetId(int i, int[] nums)
    {
        return Convert.ToInt64(nums[i]) * nums.Length + i;
    }
}