public class Solution {
    public int ReversePairs(int[] nums) {
        int n = nums.Length - 1;
        return this.MergeSort(nums, 0, n);
    }
    
    private int MergeSort(int[] nums, int left, int right)
    {
        if (left >= right)
        {
            return 0;
        }
        
        int mid = left + (right - left) / 2;
        int res = 0;
        res += this.MergeSort(nums, left, mid);
        res += this.MergeSort(nums, mid + 1, right);
        res += this.Merge(nums, left, mid, right);
        
        return res;
    }
    
    private int Merge(int[] nums, int left, int mid, int right)
    {
        int count = 0;
        int[] sortedArray = new int[right - left + 1];
        int leftPartP = left;
        int rightPartP = mid + 1;
        
        while(leftPartP <= mid && rightPartP <= right)
        {
            if ((long)nums[leftPartP] > (long)2 * nums[rightPartP])
            {
                count += mid - leftPartP + 1;
                rightPartP++;
            }
            else
            {
                leftPartP++;
            }
        }
        
        leftPartP = left;
        rightPartP = mid + 1;
        int curIndex = 0;
        while (leftPartP <= mid && rightPartP <= right)
        {
            if (nums[leftPartP] > nums[rightPartP])
            {
                sortedArray[curIndex++] = nums[rightPartP++];
            }
            else
            {
                sortedArray[curIndex++] = nums[leftPartP++];
            }
        }
        
        while(leftPartP <= mid)
        {
            sortedArray[curIndex++] = nums[leftPartP++];
        }
        
        while(rightPartP <= right)
        {
            sortedArray[curIndex++] = nums[rightPartP++];
        }
        
        Array.Copy(sortedArray, 0, nums, left, right - left + 1);
        
        return count;
    }
}