public class Solution {
    public bool IsBipartite(int[][] graph) {
        int[] ans = new int[graph.Length];
        for (int i = 0;i < graph.Length; i++)
        {
            if (ans[i] == 0)
            {
                ans[i] = 1;
                if (!CheckNode(graph,ans,i))
                {
                    return false;
                }   
            } 
        }
        return true;
    }

    bool CheckNode(int[][] graph,int[] ans, int i)
    {
        for (int j = 0; j < graph[i].Length; j++)
        {
            int index = graph[i][j];
            if (ans[index] == ans[i])
            {
                return false;
            }
            else if (ans[index] == 0)
            {
                ans[index] = -ans[i];
                if (!CheckNode(graph,ans,index))
                {
                    return false;
                }
            }
        }
        return true;
    }
}
