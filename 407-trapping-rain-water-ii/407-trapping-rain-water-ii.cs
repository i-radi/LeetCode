public class Solution {
    public int TrapRainWater(int[][] heightMap) {
        
        if(heightMap == null || heightMap.Length == 0)
            return 0;
        
        int m = heightMap.Length, n = heightMap[0].Length;
        SortedDictionary<int,Queue<(int,int,int)>> dic = new SortedDictionary<int,Queue<(int,int,int)>>();
        bool[,] visited = new bool[m,n];
        
        // add the leftmost and rightmost lands
        for(int i = 0; i < m ;i++)
        {
            if(dic.ContainsKey(heightMap[i][0]))
                dic[heightMap[i][0]].Enqueue((i,0,heightMap[i][0]));
            else
            {
                Queue<(int,int,int)> queue = new Queue<(int,int,int)>();
                queue.Enqueue((i,0,heightMap[i][0]));
                dic.Add(heightMap[i][0], queue);
            }
            visited[i,0] = true;
            
            if(dic.ContainsKey(heightMap[i][n-1]))
                dic[heightMap[i][n-1]].Enqueue((i,n-1,heightMap[i][n-1]));
            else
            {
                Queue<(int,int,int)> queue = new Queue<(int,int,int)>();
                queue.Enqueue((i,n-1,heightMap[i][n-1]));
                dic.Add(heightMap[i][n-1], queue);
            }
            visited[i,n-1] = true;
        }
        
        // add the top and bottom lands
        for(int j = 0; j < n; j++)
        {
            if(dic.ContainsKey(heightMap[0][j]))
                dic[heightMap[0][j]].Enqueue((0,j,heightMap[0][j]));
            else
            {
                Queue<(int,int,int)> queue = new Queue<(int,int,int)>();
                queue.Enqueue((0,j,heightMap[0][j]));
                dic.Add(heightMap[0][j], queue);
            }
            visited[0,j] = true;
            
            if(dic.ContainsKey(heightMap[m-1][j]))
                dic[heightMap[m-1][j]].Enqueue((m-1,j,heightMap[m-1][j]));
            else
            {
                Queue<(int,int,int)> queue = new Queue<(int,int,int)>();
                queue.Enqueue((m-1,j,heightMap[m-1][j]));
                dic.Add(heightMap[m-1][j], queue);
            }
            visited[m-1,j] = true;
        }
        
        int[,] dirs = new int[,]{{-1,0}, {1,0}, {0,-1}, {0,1}};
        int res = 0;
        while(dic.Count > 0)
        {
            var currKv = dic.First();
            var curr = dic[currKv.Key].Dequeue();
            if(dic[currKv.Key].Count == 0)
                dic.Remove(currKv.Key);
            
            for(int i = 0; i < 4; i++)
            {
                int nextRow = curr.Item1 + dirs[i,0];
                int nextCol = curr.Item2 + dirs[i,1];
                if(nextRow >= 0 && nextRow < m && nextCol >= 0 && nextCol < n && !visited[nextRow,nextCol])
                {
                    if(heightMap[nextRow][nextCol] < curr.Item3)
                    {
                        // amount of water that [nextRow,nextCol] can trap
                        res += curr.Item3 - heightMap[nextRow][nextCol];
                        if(dic.ContainsKey(heightMap[nextRow][nextCol]))
                            dic[heightMap[nextRow][nextCol]].Enqueue((nextRow,nextCol,curr.Item3));
                        else
                        {
                            Queue<(int,int,int)> queue = new Queue<(int,int,int)>();
                            queue.Enqueue((nextRow,nextCol,curr.Item3));
                            dic.Add(heightMap[nextRow][nextCol], queue);
                        }
                    }
                    else
                    {
                        if(dic.ContainsKey(heightMap[nextRow][nextCol]))
                            dic[heightMap[nextRow][nextCol]].Enqueue((nextRow,nextCol,heightMap[nextRow][nextCol]));
                        else
                        {
                            Queue<(int,int,int)> queue = new Queue<(int,int,int)>();
                            queue.Enqueue((nextRow,nextCol,heightMap[nextRow][nextCol]));
                            dic.Add(heightMap[nextRow][nextCol], queue);
                        }
                    }
                    visited[nextRow,nextCol] = true;
                }
            }
        }
        
        return res;
    }
}