public class Solution {
    public int Divide(int dividend, int divisor) {

        if(dividend == Int32.MinValue && divisor==-1){
            return Int32.MaxValue;
        }
        if(dividend/divisor > Int32.MaxValue){
            return Int32.MaxValue;
        }
        else if(dividend/divisor < Int32.MinValue){
            return Int32.MinValue;
        }
        else{
            return dividend/divisor;
        }
        
    }
}