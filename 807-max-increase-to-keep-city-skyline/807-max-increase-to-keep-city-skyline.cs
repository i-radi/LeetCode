public class Solution {
    public int MaxIncreaseKeepingSkyline(int[][] grid) {

        int N = grid.Length;
        int[] rowMaxes = new int[N];
        int[] colMaxes = new int[N];

        for (int r = 0; r < N; ++r)
            for (int c = 0; c < N; ++c) {
                rowMaxes[r] = Math.Max(rowMaxes[r], grid[r][c]);
                colMaxes[c] = Math.Max(colMaxes[c], grid[r][c]);
        }

        int ans = 0;
        for (int r = 0; r < N; ++r)
            for (int c = 0; c < N; ++c)
                ans += Math.Min(rowMaxes[r], colMaxes[c]) - grid[r][c];

        return ans;
    }
}