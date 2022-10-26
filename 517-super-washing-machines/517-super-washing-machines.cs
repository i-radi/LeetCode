public class Solution {
    
    public int FindMinMoves(int[] machines) {
        int sum = machines.Sum();
        
        if (sum % machines.Length != 0)
            return -1;
        
        int wanted = sum / machines.Length;
        
        int result = 0;
        int delta = 0;
        
        foreach (int value in machines) 
            result = Math.Max(Math.Max(result, Math.Abs(delta += value - wanted)), value - wanted);
                
        return result;
    }
    
}