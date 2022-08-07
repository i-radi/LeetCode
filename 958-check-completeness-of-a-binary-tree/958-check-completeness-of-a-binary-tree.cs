/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsCompleteTree(TreeNode root) {
        if(root == null) return true;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var missing = false;
        
        while(queue.Count > 0)
        {
            var size = queue.Count;
            var node = queue.Dequeue();    
            if(node == null)missing = true;
            else
            {
                if(missing) return false;
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }
        
        return true;
    }
}