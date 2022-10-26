public class Solution 
{
    public int KInversePairs(int n, int k) 
    {
        var dp = new int[n + 1, k + 1];
        for(int i = 0; i <= n; i++)
            for(int j = 0; j <= k; j++)
                dp[i,j] = -1;
        return KInversePairs(n, k, dp);
    }
    
    public int KInversePairs(int n, int k, int[,] dp) 
    {
        if(k == 0) return 1;
        if(n == 0 || k < 0) return 0;
        if(dp[n, k] != -1) return dp[n, k];
        long result = KInversePairs(n - 1, k, dp) 
                    + KInversePairs(n, k - 1, dp) 
                    - KInversePairs(n - 1, k - n, dp);      
        dp[n, k] = (int) ((result + 1_000_000_007) % 1_000_000_007);
        return dp[n, k];
    }
}