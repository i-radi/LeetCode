public class Solution {
    public int CountSubstrings(string s) {
        var res = 0;
        for (int i=0; i < s.Length; i++){
            res += GetPalindromesAroundCenter(s, i);
        }
        return res;
    }
    
    private int GetPalindromesAroundCenter(string str, int center){
        var count = 1;
        count += GetPalindromeCount(str, center - 1,center + 1);
        count += GetPalindromeCount(str, center,center + 1);
        return count;
    }
    
    private int GetPalindromeCount(string str, int start, int end){
        var count = 0;
        while(start >= 0 && end < str.Length){
            if (str[start--] != str[end++]){
                break;
            }
            count ++;
        }
        return count;
    }
}