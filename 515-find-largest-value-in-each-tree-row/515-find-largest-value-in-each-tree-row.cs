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
public class Solution
{
    public IList<int> LargestValues(TreeNode root)
    {
        var currentLargestValueDict = new Dictionary<int, int>();
        DFS(root, 1, currentLargestValueDict);

        var ret = new List<int>(currentLargestValueDict.Count);

        for(int i = 0; i < currentLargestValueDict.Count; i++)
        {
            ret.Add(currentLargestValueDict[i + 1]);
        }

        return ret;
    }

    private void DFS(TreeNode node, int level, IDictionary<int, int> largestValueDict)
    {
        if (node == null) return;
        var value = node.val;
        if (largestValueDict.ContainsKey(level))
        {
            largestValueDict[level] = Math.Max(value, largestValueDict[level]);
        }
        else
        {
            largestValueDict.Add(level, value);
        }

        DFS(node.left, level + 1, largestValueDict);
        DFS(node.right, level + 1, largestValueDict);
    }
}

