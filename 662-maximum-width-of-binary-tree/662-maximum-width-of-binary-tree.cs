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
    
   public class Pair{
    public TreeNode root;
    public int idx;
    public Pair(TreeNode root,int idx){
        this.root=root;
        this.idx=idx;
        }
    }
    
    public int WidthOfBinaryTree(TreeNode root) {
        Queue<Pair> q = new Queue<Pair>();
        q.Enqueue(new Pair(root,0));
        int ans=0;
        while(q.Count > 0){
            int size=q.Count();
            int lm=q.Peek().idx;
            int rm=q.Peek().idx;
            while(size-->0){
                Pair current=q.Dequeue();
                rm=current.idx;
                if(current.root.left!=null)
                    q.Enqueue(new Pair(current.root.left,2*current.idx+1));
                 if(current.root.right!=null)
                    q.Enqueue(new Pair(current.root.right,2*current.idx+2));
            
            }
            ans=Math.Max(ans,rm-lm+1);
        }
        return ans;
    }
}