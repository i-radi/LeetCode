public class Solution {
    public int StrStr(string haystack, string needle) {

        if (needle==null) return 0; 
        int n = haystack.Length;
        int m = needle.Length;
        for (int i = 0; i <= n - m; i++) {
            for (int j = 0; j < m && haystack[i + j] == needle[j]; j++)
                if (j == m - 1) return i;
        }
        return -1;
    }
}