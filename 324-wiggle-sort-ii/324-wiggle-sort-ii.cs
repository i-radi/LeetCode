public class Solution {
    public void WiggleSort(int[] nums) {
        if(nums.Length<=1) return ;
        Array.Sort(nums);
        var copy = nums.Clone() as int[];
        var mid = nums.Length%2 ==0? (nums.Length/2-1): (nums.Length/2); 
        for(var i=0;i<nums.Length;i++){
            nums[i] = i%2==0? copy[mid-i/2]: copy[nums.Length-1 - i/2]; 
        }
    }
}