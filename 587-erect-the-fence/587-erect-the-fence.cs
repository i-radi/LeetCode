public class Solution {
    public int[][] OuterTrees(int[][] trees) {
        
        Array.Sort(trees, (a, b) => a[0] == b[0]? b[1] - a[1] : a[0] - b[0]);
        
        Stack<int[]> stack = new Stack<int[]>();
        
        // low convex hull
        for(int i = 0; i < trees.Length; i++)
        {
            // check if stack.Peek() is part of the hull
            // stack.ElementAt(1): 2nd top element in the stack.
            while(stack.Count >= 2 && orientation(stack.Peek(), trees[i], stack.ElementAt(1)) > 0)
            {
                // stack.Peek() is in trees[i]'s counterclockwise direction, so stack.Peek() can't be the hull
                stack.Pop();
            }
            stack.Push(trees[i]);
        }
        
        // up convex hull
        for(int j = trees.Length - 1; j >=0; j--)
        {
            while(stack.Count >= 2 && orientation(stack.Peek(), trees[j], stack.ElementAt(1)) > 0)
                stack.Pop();
            stack.Push(trees[j]);
        }
        
        HashSet<int[]> set = new HashSet<int[]>(stack);
        return set.ToArray();
    }
    
    private int orientation(int[] p, int[] q, int[] r)
    {
        /*
            Check if tree P is in tree Q's counterclockwise direction
            
            direction = slopPR - slopQR = (p[1] - r[1]) / (p[0] - r[0]) - (q[1] - r[1]) / (q[0] - r[0]) 
            
            if direction > 0, P is in Q's counterclockwise direction
            else, P is in Q's clockwise direction

        */
        
        int direction = (p[1] - r[1]) * (q[0] - r[0]) - (p[0] - r[0]) * (q[1] - r[1]);  
        return direction;
    }
}