public class Solution {
    public int[] SortedSquares(int[] nums) {
        return nums.Select(x => x*x).OrderBy(x => x).ToArray();
    }
}