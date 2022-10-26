public class Solution {
    public int StrangePrinter(string s) {
        
        int[,,] dp = new int[100,100,100];
        return Memo(s,0,s.Length-1,0,dp);
    }
    
    public int Memo(string s, int l,  int r, int k, int[,,] dp)
    {
        if(l>r)
            return 0;
        if(dp[l,r,k]>0)
            return dp[l,r,k];
        while(l<r && s[l] ==s[l+1])
        {
            l++;
            k++;
        }
        
        dp[l,r,k] = Memo(s, l+1,r,0, dp) + 1;
        for(int i = l+ 1; i <=r; i++)
        {
            if(s[i] == s[l])
            {
                dp[l,r,k] = Math.Min(dp[l,r,k] , Memo(s, l+1, i-1,0,dp) + Memo(s,i,r,k+1,dp));
                
            }
        }
        return dp[l,r,k];
        
    }
}