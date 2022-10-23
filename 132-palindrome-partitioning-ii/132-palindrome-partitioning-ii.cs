public class Solution {
public int MinCut(string s){
    byte[,] dp = new byte[s.Length, s.Length];
    for (int i = s.Length - 1; i >= 0; i--)
        for (int j = i; j < s.Length; j++)
            if (s[i] == s[j] && (j - i <= 2 || dp[i + 1, j - 1] == 1))
                dp[i, j] = 1;
    int[] result = new int[s.Length];
    for (int i = 0; i < result.Length; i++) result[i] = result.Length;
    for (int j = 0; j < s.Length; j++)
        for (int i = 0; i <= j; i++)
            if (dp[i, j] == 1)
                result[j] = Math.Min(result[j], i == 0 ? 0 : result[i - 1] + 1);
    return result[s.Length - 1];
}
}