public class Solution{ 
public int MaxProfit(int[] prices) {
        if (prices.Length == 0) return 0;
        int[,] maxProfitDP = new int[2, prices.Length];
        for (int i = 1, min = prices[0]; i < maxProfitDP.GetLength(1); i++){
            maxProfitDP[0, i] = Math.Max(maxProfitDP[0, i - 1], prices[i] - min);
            min = Math.Min(prices[i], min);
        }
        int maxProfit = maxProfitDP[0, maxProfitDP.GetLength(1) - 1];
        for (int i = maxProfitDP.GetLength(1) - 2, max = prices[prices.Length - 1]; i >= 0; i--){
            maxProfitDP[1, i] = Math.Max(maxProfitDP[0, i], maxProfitDP[0, i] + max - prices[i]);
            max = Math.Max(max, prices[i]);
            maxProfit = Math.Max(maxProfit, maxProfitDP[1, i]);
        }
        return maxProfit;
    }
}