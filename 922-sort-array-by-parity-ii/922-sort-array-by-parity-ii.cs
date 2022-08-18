public class Solution {
    public int[] SortArrayByParityII(int[] nums) 
    {
        for(int i = 0 ; i < nums.Length; i++)
            if (nums[i] % 2 != i % 2)
                for(int j = i + 1; j < nums.Length; j++)
                    if (nums[j] % 2 == i % 2)
                    {
                        // swap nums[i] with nums[j]
                        var temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                        break;
                    }

        return nums;
    }
}