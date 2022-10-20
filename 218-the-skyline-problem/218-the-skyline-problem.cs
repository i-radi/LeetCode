public class Solution {
    public class Event {
        public int left;
        public int height;
        public bool start;
    }
    
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        var ans = new List<IList<int>>();
        var pq = new SortedDictionary<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        pq.Add(0, 1);
        var events = new List<Event>();
        foreach (var b in buildings) {
            events.Add(new Event { left = b[0], height = b[2], start = true });
            events.Add(new Event { left = b[1], height = b[2], start = false });
        }
        
        events.Sort((a, b) => {
            if (a.left == b.left) {                                
                if (a.start != b.start)
                    return -1;
                return a.start ? b.height.CompareTo(a.height) : a.height.CompareTo(b.height);
            }
            return a.left.CompareTo(b.left);
        });
        
        int currMax = 0;
        foreach (Event e in events) {
            if (e.start)
            {
                if (pq.ContainsKey(e.height))
                    pq[e.height]++;
                else
                   pq.Add(e.height, 1); 
            }
            else
            {
                if (pq[e.height] == 1)
                    pq.Remove(e.height);
                else
                    pq[e.height]--;
            }
            
            int curr = pq.First().Key;
            if (curr != currMax)
            {
                ans.Add(new List<int>() { e.left, curr });
                currMax = curr;
            }            
        }
        
        return ans;
    }    
}