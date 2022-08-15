public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        int lo = 0;
        int hi = nums.Length - 1;
        while (lo < hi) {
            if (nums[lo] % 2 > nums[hi] % 2) {
                int tmp = nums[hi];
                nums[hi] = nums[lo];
                nums[lo] = tmp;
            }
            if (nums[lo] % 2 == 0) lo++;
            if (nums[hi] % 2 == 1) hi--;
        }
        return nums;
    }
}