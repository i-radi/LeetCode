public class Solution {
    public int LongestValidParentheses(string s) {
        int left = 0, right = 0, maxLen = 0, len = s.Length;
        
        //From left to right
        for(int i=0; i<len; i++)
        {
            if(s[i] == '(') left++;
            else right++;
            
            if(left == right) maxLen = Math.Max(maxLen, 2 * right);
            else if(right >= left)
            {
                left = 0;
                right = 0;
            }
        }
        
        //reset counters
        left = 0;
        right = 0;
        
        //From right to left
        for(int i= len-1; i>=0; i--)
        {
            if(s[i] == '(') left ++;
            else right ++;
            
            if(left == right) maxLen = Math.Max(maxLen, 2 * right);
            else if( left >= right)
            {
                left = 0;
                right = 0;
            }
        }
        
        return maxLen;
    }
}