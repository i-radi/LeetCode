public class Solution {
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        int m = matrix.Length, n = matrix[0].Length;
        int[,] prefixSum = new int[m + 1, n + 1];
        
        for(int i = 1; i <= m; i++)
        {
            for(int j = 1; j <= n; j++)
                prefixSum[i, j] = prefixSum[i - 1, j] + prefixSum[i, j - 1] - prefixSum[i - 1, j - 1] + matrix[i - 1][j - 1];
                //prefixSum[i,j] denotes the sum of elements between matrix[0][0] ~ matrix[i-1][j-1]
        }
        
        int max = int.MinValue;
        HashSet<int> set = new();
        for(int r1 = 1; r1 <= m; r1++)
        {
            for(int r2 = r1; r2 <= m; r2++)
            {
                set.Clear();
                set.Add(0);
                
                for(int col = 1; col <= n; col++)
                {
                    int rangeSum = prefixSum[r2, col] - prefixSum[r1 - 1, col];
                    
                    foreach(var num in set)
                    {
                        int sum = rangeSum - num;
                        if(sum <= k)
                            max = Math.Max(max, sum);
                    }
                    
                    set.Add(rangeSum);
                }
            }
        }
        
        return max;
    }
}