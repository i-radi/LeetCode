/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        var nodeMapping = new Dictionary<Node, Node>();
        for (var cur = head; cur != null; cur = cur.next){
            var nodeCopy = GetOrCreateNewNode(nodeMapping, cur);
            if (cur.next != null)
                nodeCopy.next = GetOrCreateNewNode(nodeMapping, cur.next);
            
            if (cur.random != null)
                nodeCopy.random = GetOrCreateNewNode(nodeMapping, cur.random);
            
        }
        return head == null ? null : nodeMapping[head];
    }
    
    private Node GetOrCreateNewNode(Dictionary<Node, Node> nodeMapping, Node key){
        if (!nodeMapping.ContainsKey(key)){
            nodeMapping.Add(key, new Node(key.val));
        }
        return nodeMapping[key];
    }
}