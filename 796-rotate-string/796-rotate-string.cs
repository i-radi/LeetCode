public class Solution {
    public bool RotateString(string s, string goal) {
        string s1=s+s;
        return s.Length==goal.Length && s1.Contains(goal);   
    }
}