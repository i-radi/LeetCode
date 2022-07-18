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
        var res = new List<int>();
        if(root == null) return res;
        var stack = new Stack<Node>();
        stack.Push(root);
        
        while(stack.Count > 0)
        {
            var node = stack.Pop();
            res.Add(node.val);
            if(node.children!=null)
            {
                for(int i=node.children.Count -1 ; i>=0;i--)
                    stack.Push(node.children[i]);    
            }
        }
        
        return res;
    }
}