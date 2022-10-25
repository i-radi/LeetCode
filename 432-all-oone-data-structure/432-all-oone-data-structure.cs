public class AllOne {

    private class Node{
        public int value;
		//set of keys having same value;
        public HashSet<string> keySet;
        public Node next;
        public Node prev;
        public Node(){
            keySet = new HashSet<string>();
        }
        public Node(int v, HashSet<string> set){
            value = v;
            keySet = set;
            next = null;
            prev = null;
        }
    }
    
    Node head, tail;
    Dictionary<string, Node> dict;
    /** Initialize your data structure here. */
    public AllOne() {
        dict = new Dictionary<string, Node>();
        head = new Node(Int32.MaxValue, new HashSet<string>());
        tail = new Node(Int32.MinValue, new HashSet<string>());
        tail.prev = head;
        head.next = tail;
    }
    
    /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
    public void Inc(string key) {
        
        //If key don't exist need to add;
        if(!dict.ContainsKey(key)){
            //Get current Min key;
            var minK = GetMinKey();
            Node tmp;
            //Edge case no min key, only head and tail.
            if(string.IsNullOrEmpty(minK)){
                tmp = new Node(1, new HashSet<string>());
                tmp.next = head.next;
                tmp.prev = tail.prev;
                head.next = tmp;
                tail.prev = tmp;
            }else{ 
                tmp = dict[minK];
                if(tmp.value != 1){
                    var t = new Node(1, new HashSet<string>());
                    tmp.next.prev = t;
                    t.next = tmp.next;
                    t.prev = tmp;
                    tmp.next = t;
                    tmp = t;
                }
            }
            tmp.keySet.Add(key);
            dict.Add(key, tmp);
        }else{
            Node tmp = dict[key];
            var nValue = tmp.value +1;
            if(tmp.prev.value == nValue){
                tmp.prev.keySet.Add(key);
                tmp.keySet.Remove(key);
                //Check after remove, if current set is empty;
                if(tmp.keySet.Count==0){
                    tmp.prev.next = tmp.next;
                    tmp.next.prev = tmp.prev;
                }
                
                tmp = tmp.prev;
            }else{
                tmp.keySet.Remove(key);
                
                var t = new Node(nValue, new HashSet<string>(){key});
                t.next = tmp;
                t.prev = tmp.prev;
                tmp.prev.next = t;
                tmp.prev = t;

                if(tmp.keySet.Count==0){
                    tmp.prev.next = tmp.next;
                    tmp.next.prev = tmp.prev;
                }
                
                tmp = t;
            }
            dict[key] = tmp;
        }
    }
    
    /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
    public void Dec(string key) {
        if(!dict.ContainsKey(key)){
            return;
        }
        var n = dict[key];
        if(n.value == 1){
            n.keySet.Remove(key);
            if(n.keySet.Count==0){
                n.prev.next = n.next;
                n.next.prev = n.prev;
            }
            dict.Remove(key);
        }else{
            var nValue = n.value-1;
            if(n.next.value == nValue){
                n.keySet.Remove(key);
                n.next.keySet.Add(key);
                
                if(n.keySet.Count==0){
                    n.prev.next = n.next;
                    n.next.prev = n.prev;
                }
                
                n = n.next;
            }else{
                n.keySet.Remove(key);
                var tmp = new Node(nValue, new HashSet<string>(){key});
                tmp.prev = n;
                tmp.next = n.next;
                n.next.prev = tmp;
                n.next = tmp;
                
                if(n.keySet.Count==0){
                    n.prev.next = n.next;
                    n.next.prev = n.prev;
                }
                
                n = tmp;
            }
            dict[key] = n;
        }
    }
    
    /** Returns one of the keys with maximal value. */
    public string GetMaxKey() {

        var set = head.next.keySet;
        foreach(var k in set){
            return k;
        }
        return string.Empty;
    }
    
    /** Returns one of the keys with Minimal value. */
    public string GetMinKey() {

        var set = tail.prev.keySet;
        foreach(var k in set){
            return k;
        }
        return string.Empty;
    }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */