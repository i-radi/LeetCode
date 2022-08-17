public class RecentCounter {
    Queue<int> q;
    public RecentCounter() {
       q = new Queue<int>();
    }
    
    public int Ping(int t) {
        q.Enqueue(t);
        while (q.Peek() < t - 3000){
            q.Dequeue();
        }
        return q.Count;
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */