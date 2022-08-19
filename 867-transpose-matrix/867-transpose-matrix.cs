public class Solution {
    public int[][] Transpose(int[][] matrix) {
        int R = matrix.Length, C = matrix[0].Length;
        var ans = new int[C][];
        for (int i = 0; i < C; i++){
            ans[i] = new int[R];
        }
        for (int i = 0; i < R; ++i)
            for (int j = 0; j < C; ++j) {
                ans[j][i] = matrix[i][j];
            }
        return ans;
    }  
}