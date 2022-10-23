public class Solution {
    public string ShortestPalindrome(string s) {
        int maxLen = 0;
        for(int i = s.Length-1; i>=0; i--)
        {
            int start = 0;
            int end = i;
            while(start<= end)
            {
                if(s[start] == s[end])
                {
                    start++;  
					end--;                   
                }
                else
                    break;
            }
            
            if(end< start)
            {
                maxLen = i+1;
                break;
            }            
        }        
        char[] addition = s.Substring(maxLen).Reverse().ToArray();        
        return new string(addition) + s; 
    }
}