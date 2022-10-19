public class Solution {
    public bool IsMatch(string s, string p) {
        
        int sp = 0;
        int pp = 0;
        int starPos = -1;
        int match = 0;

        while(sp < s.Length){
            if(pp < p.Length && (s[sp] == p[pp] || p[pp] == '?')){
                sp++;
                pp++;
            }else if(pp < p.Length && p[pp] == '*'){
                starPos = pp;
                match = sp;
                pp++;
            }else if(starPos != -1){
                pp = starPos + 1;
                match++;
                sp = match;
            }else{
                return false;
            }
        }

        while(pp < p.Length && p[pp] == '*') pp++;

        return pp == p.Length;

    }
}