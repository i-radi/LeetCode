public class Solution 
{
    int[] dx = new int[] {0, 1, 0, -1};
    int[] dy = new int[] {1, 0, -1, 0};
    
    public int CutOffTree(IList<IList<int>> forest) 
    {
        if(forest == null || forest.Count == 0 || forest[0].Count == 0)  return -1;
        var trees = new List<int[]>();
        for(int i = 0; i < forest.Count; i++)
            for(int j = 0; j < forest[i].Count; j++)
                if(forest[i][j] > 1)
                    trees.Add(new int[] {forest[i][j], i, j});
        
        trees.Sort((a,b) => a[0].CompareTo(b[0]));
        int result = 0, x = 0, y = 0;
        foreach(var tree in trees)
        {
            var pathLength = FindPathLength(forest, x, y, tree[1], tree[2]);
            if(pathLength < 0) return -1;
            forest[tree[1]][tree[2]] = 1;
            result += pathLength;
            x = tree[1]; y = tree[2];
        }
        
        return result;
    }
    
    private int FindPathLength(IList<IList<int>> forest, int sx, int sy, int tx, int ty)
    {
        int r = forest.Count, c = forest[0].Count;
        var queue = new Queue<int[]>();
        var visited = new bool[r, c];
        visited[sx, sy] = true;
        queue.Enqueue(new int[] {sx, sy});
        int level = 0;
        while(queue.Count != 0)
        {
            int count = queue.Count;
            for(int cnt = 0; cnt < count; cnt++)
            {
                var curr = queue.Dequeue();
                if(curr[0] == tx && curr[1] == ty)
                    return level;
                for(int i = 0; i < 4; i++)
                {
                    int nx = curr[0] + dx[i], ny = curr[1] + dy[i];
                    if(nx >= 0 && nx < r && ny >= 0 && ny < c && !visited[nx, ny] && forest[nx][ny] > 0)
                    {
                        visited[nx, ny]=true;
                        queue.Enqueue(new int[] {nx, ny});
                    }
                }
            }
            
            level++;
        }
        
        return -1;
    }
}