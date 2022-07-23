public class Solution {
    public int Search(int[] nums, int target) {
        var left = 0;
        var right = nums.Length-1;
        
        while(left <= right)
        {
            var midPoint =left + (right-left)/2;
            if(nums[midPoint] == target)
                return midPoint;
            else if(nums[midPoint] > target)
                right = midPoint - 1;
            else
                left = midPoint + 1;
        }
        
        return -1;
    }
}