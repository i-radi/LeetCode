public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        return PermuteRec(new HashSet<int>(nums), new List<int>());
    }
    
   private List<IList<int>> PermuteRec(HashSet<int> nums, List<int> prefix){
       var res = new List<IList<int>>();
       if (nums.Count == 0){
           res.Add(new List<int>(prefix));
       }
       var remainingNums = new HashSet<int>(nums);
       foreach(var c in nums){
           remainingNums.Remove(c);
           prefix.Add(c);
           res.AddRange(PermuteRec(remainingNums, prefix));
           remainingNums.Add(c);
           prefix.RemoveAt(prefix.Count - 1);
       }
       return res;
   }
}