public class Solution {
    public int[] FindRedundantDirectedConnection(int[][] edges) 
    {
        int n = edges.Length;
        int[] inDegree = new int[n+1];
        
        foreach(var ed in edges)
            inDegree[ed[1]]++;
        
        List<int> potentialBadEdgesIndex = new();
        
        for(int i=0;i<n;i++)
        {
            if(inDegree[edges[i][1]]>1)
            {
                potentialBadEdgesIndex.Add(i);
            }
        }
        
        if(potentialBadEdgesIndex.Count==0)
            return CycleFound(edges,-1);
        
        var edgeCausingCycle = CycleFound(edges, potentialBadEdgesIndex[1]);
        
        if(edgeCausingCycle==null)
            return edges[potentialBadEdgesIndex[1]];
        
        return edges[potentialBadEdgesIndex[0]];
    }
    
    private int[] CycleFound(int[][] edges, int edgeIndexNotBeConsidered)
    {
        int n = edges.Length;
        UF uf = new(n+1);
        
        for(int i=0;i<n;i++)
        {
            if(i==edgeIndexNotBeConsidered)
                continue;
            
            if(uf.Union(edges[i][0],edges[i][1]))
            {
                return edges[i];
            }
        }
        
        return null;
    }
}

class UF
{
    private int[] rank;
    private int[] parent;
    
    public UF(int n)
    {
        rank = new int[n];
        parent = new int[n];
        
        for(int i=0;i<n;i++)
            parent[i]=i;
    }
    
    public bool Union(int x, int y)
    {
        int px = Find(x);
        int py = Find(y);
        
        if(px==py)
            return true;
        
        if(rank[px] < rank[py])
        {
            parent[px] = py;
        }
        else if(rank[py] < rank[px])
        {
            parent[py] = px;
        }
        else
        {
            parent[px] = py;
            rank[py]++;
        }
        
        return false;
    }
    
    private int Find(int x)
    {
        if(parent[x]==x)
            return x;
        
        return Find(parent[x]);
    }
}