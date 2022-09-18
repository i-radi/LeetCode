class Solution {
    public int Divide(int dividend, int divisor) {
        int sign = (dividend < 0) ^ (divisor < 0) ? -1 : 1;
        long ldividend = Math.Abs((long)dividend);
        long ldivisor = Math.Abs((long)divisor);
        
        long ans = 0;
        while(ldivisor <= ldividend) {
            long tmp = ldivisor;
            long mul = 1;
            while(ldividend >= (tmp << 1)) {
                tmp <<= 1;
                mul <<= 1;
            }
            
            ans += mul;
            ldividend -= tmp;}
        
        ans *= sign;
        
        if(ans >= Int32.MaxValue) {
            return Int32.MaxValue;
        }else{
            return (int) ans;
        }
    }
}