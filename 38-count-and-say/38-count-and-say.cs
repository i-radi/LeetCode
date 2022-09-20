public class Solution {
    public string CountAndSay(int n) {
        return f(n,"1");
    }
    
    private string f(int rep,String s){
        if(rep==1) return s;
        int left=0,right=0;
        string res = "";
        
        while(right<s.Length){
            while(right<s.Length && s[right]==s[left]) right++;
            int size = right-left;
            res += size.ToString() + s[left];
            left=right;
        }
        return f(rep-1,res);
    }
}