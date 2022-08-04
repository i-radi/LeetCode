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
    private int _ans = 0;
    private int _level = 0;
    public int FindBottomLeftValue(TreeNode root) {
        Traverse(root, 1);
        return _ans;
    }
    
    private void Traverse(TreeNode node, int level)
    {
        if(node == null) return;
        if(level > _level)
        {
            _level = level;
            _ans = node.val;
        }
        
        Traverse(node.left, level+1);
        Traverse(node.right, level + 1);
    }
}
