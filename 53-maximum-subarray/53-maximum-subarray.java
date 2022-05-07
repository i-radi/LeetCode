class Solution {
    public static int maxSubArray(int[] nums) {
        int ans = nums[0];
        int subarr_sum = nums[0];

        for(int i=1 ; i < nums.length ; i++)
        {
            subarr_sum = Math.max(nums[i],nums[i] + subarr_sum);
            ans = Math.max(ans, subarr_sum);
        }
        return ans;

    }
    
     public static void main(String args[])
    {
        int [] nums = {-2,1,-3,4,-1,2,1};
        System.out.print(maxSubArray(nums));
    }
}