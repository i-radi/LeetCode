public class Solution 
{
    public int MinStickers(string[] stickers, string target) 
    {  
        int n = target.Length, N = 1 << n;
        int[] dp = Enumerable.Repeat(int.MaxValue, N).ToArray();
        dp[0] = 0;
        for (int i = 0; i < N; i++)
        {
            if (dp[i] != int.MaxValue) 
            {
                foreach(var sticker in stickers) 
                {
                    int status = i;
                    foreach(char c in sticker) 
                    {
                        for (int r = 0; r < n; r++) 
                        {
                            int pos = 1 << r;
                            if (target[r] == c && (pos & status) == 0)
                            {
                                status |= pos;
                                break;
                            }
                        }
                    }
                    dp[status] = Math.Min(dp[status], dp[i] + 1);
                }
            }
        }
        
        return dp[N-1] == int.MaxValue ? -1 : dp[N-1];
    }
}