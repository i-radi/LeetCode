public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int row = matrix.Length-1;
        for(int i = 1; i<matrix.Length; i++)
            if (target < matrix[i][0]) {
                row = i-1;
                break;
            }
                       
        for(int j =0; j<matrix[row].Length; j++)
            if (target == matrix[row][j]) return true;
        
        return false;
    }
}