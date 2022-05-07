
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
class Solution {
    private void inorderTraversal(TreeNode root, ArrayList<Integer> res) {
        if (root != null) {
            inorderTraversal(root.left, res);
            res.add(root.val);
            inorderTraversal(root.right, res);
        }
    }
    
    public int kthSmallest(TreeNode root, int k) {
        ArrayList<Integer> inorderSeq = new ArrayList<Integer>();
        inorderTraversal(root, inorderSeq);
        return inorderSeq.get(k - 1);
    }
}