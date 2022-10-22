public class Solution {
    public bool IsScramble(string s1, string s2) {
        var n = s1.Length;

        if (n != s2.Length) {
            return false;
        }

        // check whether they have same letters
        var s1CharArray = s1.ToCharArray();
        var s2CharArray = s2.ToCharArray();

        Array.Sort(s1CharArray);
        Array.Sort(s2CharArray);

        for (int i = 0; i < s1CharArray.Length; i++) {
            if (s1CharArray[i] != s2CharArray[i]) {
                return false;
            }
        }

        // DP: s1[i], s2[j], length
        var dp = new bool[n, n, n + 1];

        // start with len = 1
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (s1[i] == s2[j]) {
                    dp[i, j, 1] = true;
                }
            }
        }

        for (int len = 2; len <= n; len++) {
            for (int i = 0; i < n - len + 1; i++) {
                for (int j = 0; j < n - len + 1; j++) {
                    for (int k = 1; k < len; k++) {
                        // (gr eat) or (eat gr)
                        if ((dp[i, j, k] && dp[i + k, j + k, len - k]) ||
                            (dp[i, j + len - k, k] && dp[i + k, j, len - k])
                        ) {
                            dp[i, j, len] = true;
                        }
                    }
                }
            }
        }

        return dp[0, 0, n];
    }
}