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
    public IList<int> RightSideView(TreeNode root) {
        
    List<int> list = new List<int>();
    if(root == null) return list;
    Queue<TreeNode> q = new Queue<TreeNode>();
    q.Enqueue(root);
    q.Enqueue(null);
    list.Add(root.val);
    while( q.Count() > 1 ){
        
        TreeNode temp = q.Dequeue();
        
        if(temp == null){
            q.Enqueue(null);
            TreeNode t = q.Peek();
            list.Add(t.val);
            continue;
        }
        if(temp.right != null) q.Enqueue(temp.right);
        if(temp.left != null) q.Enqueue(temp.left);
    }
    return list;    
    }
}