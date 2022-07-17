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
    public IList<int> InorderTraversal(TreeNode root) {
        var res = new List<int>();
        var stack = new Stack<TreeNode>();
        var p = root;
        while(p!=null || stack.Count > 0)
        {
            if(p!=null)
            {
                stack.Push(p);
                p = p.left;
            }else{
                p = stack.Pop();
                res.Add(p.val);
                p = p.right;
            }
        }
        
        return res;
    }
}