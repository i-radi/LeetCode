public class Solution {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        if (k < 1 || t < 0) return false;
        var map = new Dictionary<long,long>();
        for (int i = 0; i < nums.Length; i++) {
            long remappedNum = (long) nums[i] - int.MinValue;
            long bucket = remappedNum / ((long) t + 1);
            if (map.ContainsKey(bucket)
                    || (map.ContainsKey(bucket - 1) && remappedNum - map[bucket - 1] <= t)
                        || (map.ContainsKey(bucket + 1) && map[bucket + 1] - remappedNum <= t))
                            return true;
            if (map.Count() >= k) {
                long lastBucket = ((long) nums[i - k] - int.MinValue) / ((long) t + 1);
                map.Remove(lastBucket);
            }
            map[bucket]= remappedNum;
        }
        return false;

    }
}