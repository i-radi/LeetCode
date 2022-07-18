/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<int> Preorder(Node root) {
        var ret = new List<int>();
        Preorder(root,ret);
        return ret;
    }
    
    private void Preorder(Node node, IList<int> ret)
    {
        if(node==null) return;
        ret.Add(node.val);
        if(node.children == null) return;
        foreach(var n in node.children)
        {
            Preorder(n, ret);
        }
    }
}