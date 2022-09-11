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
    public TreeNode SortedArrayToBST(int[] nums) {
        return buildBST(nums,0,nums.Length-1);
    }
    
    private TreeNode buildBST(int[] nums, int l, int r){
        if(l > r) return null;
        int m = l + (r-l)/2;
        TreeNode node = new TreeNode(nums[m]);
        node.left = buildBST(nums, l, m-1);
        node.right = buildBST(nums,m+1,r);
        return node;
    }
        
}