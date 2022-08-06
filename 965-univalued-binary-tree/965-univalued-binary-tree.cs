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
    public bool IsUnivalTree(TreeNode root) {
        if(root == null) return true;
        int v = root.val;
        return IsUnivalTree(root,v);
    }
    
    private bool IsUnivalTree(TreeNode node, int v)
    {
        if(node == null) return true;
        if(node.val != v) return false;
        return IsUnivalTree(node.left,v) && IsUnivalTree(node.right,v);
    }
}