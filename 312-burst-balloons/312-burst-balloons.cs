public class Solution {
    public int MaxCoins(int[] nums) {
        var numList = nums.ToList();
        numList.Add(1);
        numList.Insert(0, 1);
        
        var n = numList.Count;

        var dp = new int[n, n];

        for (int len = 1; len <= n - 2; len++) {
            for (int left = 1; left < n - len; left++) {
                var right = left + len - 1;

                for (int i = left; i <= right; i++) {
                    var oneResult = numList[left - 1] * numList[i] * numList[right + 1] + dp[left, i - 1] + dp[i + 1, right];
                    dp[left, right] = Math.Max(dp[left, right], oneResult);
                }
            }
        }

        return dp[1, n - 2];
    }
}