public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
    var deg = new List<int>();
    var adj = new List<int>[numCourses];     
    for(int i=0; i<numCourses; i++){
        adj[i] = new List<int>();
        deg.Add(0);
    }
    
    for(int i=0; i<prerequisites.Length; i++){
        adj[prerequisites[i][1]].Add(prerequisites[i][0]);
        deg[prerequisites[i][0]]++;
    }
    
    var q = new Queue<int>();
    
    for(int i=0; i<numCourses; i++){
        if(deg[i] == 0)q.Enqueue(i);
    }
    
    while(q.Count() > 0){
        int node = q.Dequeue();
        
        foreach(var v in adj[node]){
            deg[v]--;
            if(deg[v] == 0)q.Enqueue(v);
        }
    }
    
    for(int i=0; i<numCourses; i++){
        if(deg[i] != 0)return false;
    }
    
    return true;
   }      
}
