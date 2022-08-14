public class Solution {
    public int UniqueMorseRepresentations(string[] words) {
        string[] morse = new string[]{".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
        var set = new HashSet<string>();
        foreach (var word in words){
            var str = new StringBuilder();
            foreach (var ch in word){
                str.Append(morse[ch - 'a']);
            }
            set.Add(str.ToString());
        }
        return set.Count();
    }
}