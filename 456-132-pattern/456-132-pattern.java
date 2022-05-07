 class Solution {
     public boolean find132pattern(int[] nums) {
         if(nums == null || nums.length < 3){
             return false;
         }
         
         int s3 = Integer.MIN_VALUE;
         Stack<Integer> stk = new Stack<>();
         for(int i = nums.length - 1; i >= 0; i--){
             if(nums[i] < s3){
                 return true;
             }
             
             while(!stk.isEmpty() && stk.peek() < nums[i]){
                 s3 = stk.pop();
             }
             
             stk.push(nums[i]);
         }
         
         return false;
     }
 }