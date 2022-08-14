public class Solution {
    public int UniqueMorseRepresentations(string[] words) {
        string[] morse = new string[]{".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
        var set = new HashSet<string>();
        foreach (var word in words){
            string str = "";
            foreach (var ch in word){
                str += morse[ch - 'a'];
            }
            set.Add(str);
        }
        return set.Count();
    }
}