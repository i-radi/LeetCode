public class Solution {
    public int MaxEnvelopes(int[][] envelopes) {
        //Longest increasing sunsequence. TC: NLog(N)
        int len = envelopes.Length;
        if(len < 2) return len;
        
        envelopes = envelopes.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToArray();
        int count = 0;
        int[] dp = new int[len];
        
        for(int i=0; i<len; i++)
        {
            int idx = Array.BinarySearch(dp, 0, count, envelopes[i][1]);
            if(idx < 0) idx = ~idx;
            dp[idx] = envelopes[i][1];
            if(idx == count) count++;
        }
        
        return count;
    }
}