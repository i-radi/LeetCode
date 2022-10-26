public class Solution {
public int FindIntegers(int n) {
    var bits = new BitArray(new[] { n });
    var memo = new int?[bits.Length, 4];
    int f(int i, bool underMax, bool oneOk) {
        if (i < 0) {
            return 1;
        }
        int j = (underMax ? 1 : 0) | (oneOk ? 2 : 0);
        if (memo[i, j].HasValue) {
            return memo[i, j]. Value;
        }
        int x = f(i - 1, underMax || bits[i], true);
        if ((underMax || bits[i]) && oneOk) {
            x += f(i - 1, underMax, false);
        }
        memo[i, j] = x;
        return x;
    }
    return f(bits.Length - 1, false, true);
}
}