public class Solution {
    public int CalculateMinimumHP(int[][] dungeon) {
        var n = dungeon.GetLength(0);
        if (n == 0) return 0;
        var m = dungeon[0].Length;

        var dp = new int[n, m];
        for (var i = n - 1; i >= 0; i--) {
            for (var j = m - 1; j >= 0; j--) {
                var candidate1 = int.MaxValue;
                var candidate2 = int.MaxValue;
                if (i < n - 1) {
                    candidate1 = dp[i + 1, j];
                }

                if (j < m - 1) {
                    candidate2 = dp[i, j + 1];
                }

                if (i == n - 1 && j == m - 1) {
                    dp[i, j] = Math.Max(0,-dungeon[i][j]);
                } else {
                    dp[i, j] = Math.Max(0, Math.Min(candidate1, candidate2) - dungeon[i][j]);
                }
            }
        }

        return dp[0, 0] + 1;
    }
}