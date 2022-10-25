public class Solution {
    public int SplitArray(int[] nums, int m) {
        
        int sum = 0;
        int max = 0;
        foreach(var num in nums)
        {
            max = Math.Max(max, num);
            sum += num;
        }
        
        int l = max;
        int r = sum;
        
        while(l < r)
        {
            int mid = l + (r - l)/2;
            if(isValid(nums, mid, m))
            {
                r = mid;
            }
            else
            {
                l = mid + 1;
            }            
        }
        return l;
    }
    
    private bool isValid(int[] nums, int target, int m)
    {
        int total = 0;
        int count = 1;        
        foreach(var num in nums)
        {
            total += num;
            if(total > target)
            {
                total = num;
                count++;
            } 
            if(count > m)
                return false;
        }
        return true;        
    }
}

//Idea:
// => The answer lies between the Max number in the array and the Total Sum of the array.
// => We do a Binary Search between Max and Sum to find the minimum Sum