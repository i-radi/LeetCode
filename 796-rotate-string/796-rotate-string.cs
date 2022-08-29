public class Solution {
    public bool RotateString(string s, string goal) 
        => s.Length==goal.Length && $"{s}{s}".Contains(goal);   
    
}