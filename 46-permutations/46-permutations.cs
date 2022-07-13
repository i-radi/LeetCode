public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var res = new List<IList<int>>();
        PermuteRec(new HashSet<int>(nums), new List<int>(), res);
        return res;
    }
    
   private void PermuteRec(HashSet<int> nums, List<int> prefix, IList<IList<int>> res){
       if (nums.Count == 0){
           res.Add(new List<int>(prefix));
           return;
       }
       var remainingNums = new HashSet<int>(nums);
       foreach(var c in nums){
           remainingNums.Remove(c);
           prefix.Add(c);
           PermuteRec(remainingNums, prefix, res);
           remainingNums.Add(c);
           prefix.RemoveAt(prefix.Count - 1);
       }
   }
}