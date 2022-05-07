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
        public void RecoverTree(TreeNode root)
        {
            TreeNode firstElement = null;
            TreeNode secondElement = null;
            var previousElement = new TreeNode(Int32.MinValue);

            runInorderTraversal(root, ref firstElement, ref secondElement, ref previousElement);

            // swap the values of the two nodes
            var tmp = firstElement.val;
            firstElement.val = secondElement.val;
            secondElement.val = tmp;
        }

        private void runInorderTraversal(TreeNode root, ref TreeNode firstElement, ref TreeNode secondElement, ref TreeNode previousElement)
        {
            if (root == null)
                return;

            runInorderTraversal(root.left, ref firstElement, ref secondElement, ref previousElement);

            // if firstElement has not found and current node's value has violation, then current one is the first violation
            if (firstElement == null && previousElement.val > root.val)
            {
                firstElement = previousElement;
            }

            // only two nodes, reverse the order - catch first, catch second one
            if (firstElement != null && previousElement.val >= root.val)
            {
                // if the firstElment is found and current node's value has violation, then current one is the second violation
                secondElement = root;
            }

            // reset previousElement
            previousElement = root;

            runInorderTraversal(root.right, ref firstElement, ref secondElement, ref previousElement);
        }
}