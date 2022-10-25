public class Solution 
{
    public bool CanCross(int[] stones) 
    {
        if (stones.Length == 1) return false;
        if (stones[1] != 1) return false;

        var changes = new int[]{-1, 0, 1};

        var stoneAndArrayIndex = new Dictionary<int, int>();
        
        // The first one is always 1, so start from the second.
        // Also zero means stay at the current position, so it is uesless.
        for (int i = 1; i < stones.Length; i++)
        {
            stoneAndArrayIndex[stones[i]] = i;
        }
        var indexAndDpHashSet = new Dictionary<int, HashSet<int>>();

        var lastStone = stones.Last();

        indexAndDpHashSet[1] = new HashSet<int>();
        indexAndDpHashSet[1].Add(1);

        for (int i = 1; i < stones.Length; i++)
        {
            if (!indexAndDpHashSet.ContainsKey(i)) continue;
            var curIndexAndDpHashSet = indexAndDpHashSet[i];
            foreach(var dp in curIndexAndDpHashSet)
            {
                foreach(var change in changes)
                {
                    if (dp == 0) continue;

                    var nextK = dp + change;
                    var nextStone = nextK + stones[i];

                    if (lastStone == nextStone) return true;
                    if (stoneAndArrayIndex.ContainsKey(nextStone))
                    {
                        var tempIndex = stoneAndArrayIndex[nextStone];

                        if (tempIndex == i) continue;
                        if (!indexAndDpHashSet.ContainsKey(tempIndex)) indexAndDpHashSet[tempIndex] = new HashSet<int>();
                        indexAndDpHashSet[tempIndex].Add(nextK);
                    }                   
                }
            }
        }

        return false;
    }
}