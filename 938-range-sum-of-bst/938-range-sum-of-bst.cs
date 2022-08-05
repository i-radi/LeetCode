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
    public int RangeSumBST(TreeNode root, int low, int high) {
        var queue = new Queue<TreeNode>();
        int rangeSum = 0;
        queue.Enqueue(root);
        
        while(queue.Any()) {
            TreeNode current = queue.Dequeue();
            if(current.val >= low && current.val <= high) {
                rangeSum += current.val;
            }
            if(current.left != null) 
                queue.Enqueue(current.left);
            
            if(current.right != null) 
                queue.Enqueue(current.right);
        }
        
        return rangeSum;
    }
}