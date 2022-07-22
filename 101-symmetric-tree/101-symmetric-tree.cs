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
    public bool IsSymmetric (TreeNode root) {
        if (root == null) return true;
        return IsMirror (root, root);
    }

    private bool IsMirror (TreeNode nodeA, TreeNode nodeB) {
        if (nodeA == null && nodeB == null) return true;
        if (nodeA == null || nodeB == null) return false;

        return nodeA.val == nodeB.val &&
            IsMirror (nodeA.left, nodeB.right) &&
            IsMirror (nodeA.right, nodeB.left);

    }
}