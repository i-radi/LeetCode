public class Solution {
public int TrailingZeroes(int n) {
    int i = 0;
    for(i = 0; 0 < n / 5; i += n / 5, n /= 5);
    return i;
}
}