public class Solution {
  public int OddEvenJumps(int[] arr) {
    var memo = new int?[arr.Length, 2];
    var sortedList = new SortedList<int, List<int>>();
    
    for(var i = 0; i < arr.Length; ++i){
      if(!sortedList.ContainsKey(arr[i]))
        sortedList.Add(arr[i], new());
      sortedList[arr[i]].Add(i);
    }
    
    int GetClosestMaxValueWithKeyGreaterThanIndex(int i){
      for(var j = sortedList.IndexOfKey(arr[i]); j < sortedList.Count; ++j)
        foreach(var k in sortedList.Values[j])
          if(k > i)
            return k;
      return -1;
    }
    
    int GetClosestMinValueWithKeyGreaterThanIndex(int i){
      for(var j = sortedList.IndexOfKey(arr[i]); j >= 0; --j)
        foreach(var k in sortedList.Values[j])
          if(k > i)
            return k;
      return -1;
    }

    int Jump(int i = 0, int isOddJump = 1){
      if(i == arr.Length - 1)
        return 1;
      
      if(i >= arr.Length)
        return 0;
      
      if(memo[i, isOddJump].HasValue)
        return memo[i, isOddJump].Value;
      
      var nextK = isOddJump == 1 ?
        GetClosestMaxValueWithKeyGreaterThanIndex(i) : 
        GetClosestMinValueWithKeyGreaterThanIndex(i);
      
      if(nextK < 0)
        memo[i, isOddJump] = 0;
      else
        memo[i, isOddJump] = Jump(nextK, isOddJump == 1 ? 0 : 1);
      
      return memo[i, isOddJump].Value;
    }
    
    var counter = 0;
    
    for(var i = arr.Length - 1; i >= 0; --i)
        counter += Jump(i);
    
    return counter;
  }
}