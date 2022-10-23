 public class Solution
    {
        public int MaxProfit(int k, int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }

            k = Math.Min(k, prices.Length / 2);

            checked
            {
                int[] prevSellDp = new int[k + 1];
                int[] prevBuyDp = new int[k + 1];

                int[] sellDp = new int[k + 1];
                int[] buyDp = new int[k + 1];

                for (int i = 0; i < prices.Length; i++)
                {
                    for (int j = 0; j <= k; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            buyDp[0] = -prices[0];
                        }
                        else if (i == 0)
                        {
                            buyDp[j] = -prices[0];
                        }
                        else if (j == 0)
                        {
                            buyDp[0] = -prices[i];
                            buyDp[0] = Math.Max(buyDp[0], prevBuyDp[0]);
                        }
                        else
                        {
                            sellDp[j] = Math.Max(sellDp[j], prevSellDp[j]);
                            sellDp[j] = Math.Max(sellDp[j], sellDp[j - 1]);

                            buyDp[j] = int.MinValue;

                            buyDp[j] = Math.Max(buyDp[j], prevBuyDp[j]);
                            buyDp[j] = Math.Max(buyDp[j], buyDp[j - 1]);

                            sellDp[j] = Math.Max(sellDp[j], prevBuyDp[j - 1] + prices[i]);
                            buyDp[j] = Math.Max(buyDp[j], prevSellDp[j] - prices[i]);
                        }
                    }

                    var tmp = prevSellDp;
                    prevSellDp = sellDp;
                    sellDp = tmp;

                    tmp = buyDp;
                    buyDp = prevBuyDp;
                    prevBuyDp = tmp;
                }

                return prevSellDp[k];
            }
        }
    }