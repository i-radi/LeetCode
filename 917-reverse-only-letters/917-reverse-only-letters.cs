public class Solution {
    public string ReverseOnlyLetters(string s) {
        int j = s.Length-1;
        StringBuilder sb = new StringBuilder();
        for(int i = 0 ;i<s.Length ;i++){
            if (Char.IsLetter(s[i])){
                while(!Char.IsLetter(s[j]))j--;
                sb.Append(s[j]); 
                j--;
            }
            else{
                sb.Append(s[i]); 
            }
        }
        return sb.ToString();
    }
}