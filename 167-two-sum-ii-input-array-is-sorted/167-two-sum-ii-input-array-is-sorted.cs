public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int s = 0;
        int e = numbers.Length - 1;
        
        while(s<e){
            var sum = numbers[s] + numbers[e];
            if(sum == target)   return new int[]{s+1, e+1};
            else if(sum > target)   e--;
            else    s++;
        }
        return new int[]{s+1, e+1};
    }
}