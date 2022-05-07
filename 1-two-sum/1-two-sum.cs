public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Create a hashtable
        // Using Hashtable class
        Hashtable my_hashtable1 = new Hashtable();
        for (int i = 0 ; i < nums.Length ; ++i){
            int remain = target - nums[i];
            if (my_hashtable1.ContainsKey(remain))
                return new int[]{i,(int)my_hashtable1[remain]};
            my_hashtable1[nums[i]]=i;
            
        }
        return new int[]{0,0};
    }
}