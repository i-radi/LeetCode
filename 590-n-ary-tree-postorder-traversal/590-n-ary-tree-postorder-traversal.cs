/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<int> Postorder(Node root) {
        var ret = new List<int>();
        Postorder(root, ret);
        return ret;
    }
    
    private void Postorder(Node node, IList<int> list)
    {
        if(node == null) return;
        if(node.children!=null){
            foreach(var n in node.children){
                Postorder(n,list);
            }
        }
        
        list.Add(node.val);
        
    }
}