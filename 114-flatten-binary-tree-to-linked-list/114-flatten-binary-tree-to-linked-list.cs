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
    public void Flatten(TreeNode root) {
        if(root == null) return;
        var left = root.left;
        var right = root.right;
        Flatten(root.left);
        Flatten(root.right);

        root.right = left;
        root.left = null;
        var curr = root;
        while(curr.right!=null) curr = curr.right;
        curr.right = right;
    }
}