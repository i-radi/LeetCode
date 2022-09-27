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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        
        IList<IList<int>> ans = new List<IList<int>>();
        traverse(root, 0, ans);
        
        for(int i=1;i<ans.Count();i+=2) {
            ans[i] = ans[i].Reverse().ToList();
        }
        
        return ans;
    }
    
    private void traverse(TreeNode node, int level, IList<IList<int>> ans) {
        if(node == null) return;
        if(level+1 > ans.Count())
            ans.Add(new List<int>());
        ans[level].Add(node.val);
        traverse(node.left, level+1, ans);
        traverse(node.right, level+1, ans);
    }
}