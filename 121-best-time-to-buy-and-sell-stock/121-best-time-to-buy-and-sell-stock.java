class Solution {
    public static int maxProfit(int[] prices) {
         if(prices == null || prices.length == 0) return 0;
        int min = prices[0];
        int max = Integer.MIN_VALUE;
        
        for(int i = 0; i < prices.length; i++){
            if((prices[i] - min) > max) max = prices[i] - min;
            if(prices[i] < min) min = prices[i];
        }
        
        return max;
    }
    
     public static void main(String args[])
    {
        int [] prices = {7,1,5,3,6,4};
        System.out.print(maxProfit(prices));
    }
}