public class Solution {
    public int findUnsortedSubarray(int[] nums) {
        int left = -1;
        int right = -1;
        int max = nums[0];
        int min = nums[nums.length - 1];
        for(int i = 1; i < nums.length; i ++) {
            max = Math.max(max, nums[i]);
            min = Math.min(min, nums[nums.length - i - 1]);
            if(max > nums[i])   right = i;
            if(min < nums[nums.length - i - 1]) left = nums.length - i - 1;
        }
        
        if(left  < 0)   return 0;
        return right - left + 1;
    }
}