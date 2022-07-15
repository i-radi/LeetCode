public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var numbers = new HashSet<int>(nums);
        if (nums.Length != numbers.Count)
            return true;
        return false;
    }
}