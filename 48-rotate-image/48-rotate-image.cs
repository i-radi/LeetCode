public class Solution {
    public void Rotate(int[][] matrix) {
        transpose(matrix);
        reverse(matrix);
    }
    
    private void transpose(int[][] matrix) {
        int n = matrix.Length;
        for(int i=0;i<n;i++) {
            for(int j=i+1;j<n;j++) {
                int tmp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = tmp;
            }
        }
    }
    
    private void reverse(int[][] matrix) {
        int n = matrix.Length;
        for(int i=0;i<n;i++) {
            for(int j=0;j<n/2;j++) {
                int tmp = matrix[i][j];
                matrix[i][j] = matrix[i][n-j-1];
                matrix[i][n-j-1] = tmp;
            }
        }
    }
}