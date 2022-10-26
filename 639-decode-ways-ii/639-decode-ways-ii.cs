 public class Solution
    {
        private const int MODULO = 1_000_000_007;

        private void Helper(int[] dp, ref string s, int i, int currDigit)
        {
            //single digit
            dp[i] += (i == s.Length - 1 ? 1 : dp[i + 1]);
            dp[i] = dp[i] % MODULO;

            if (i != s.Length - 1)
            {
                //two digits
                if (s[i + 1] != '*')
                {
                    int candidate = currDigit * 10 + s[i + 1] - '0';
                    if (candidate >= 1 && candidate <= 26)
                    {
                        dp[i] += (i != s.Length - 2 ? dp[i + 2] : 1);
                        dp[i] = dp[i] % MODULO;
                    }
                }
                else
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        int candidate = currDigit * 10 + k;
                        if (candidate >= 1 && candidate <= 26)
                        {
                            dp[i] += (i != s.Length - 2 ? dp[i + 2] : 1);
                            dp[i] = dp[i] % MODULO;
                        }
                    }
                }
            }
        }

        public int NumDecodings(string s)
        {
            checked
            {
                int[] dp = new int[s.Length];

                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (s[i] == '0')
                    {
                        dp[i] = 0;
                        continue;
                    }

                    if (s[i] == '*')
                    {
                        for (int j = 1; j <= 9; j++)
                        {
                            Helper(dp, ref s, i, j);
                        }

                        continue;
                    }

                    Helper(dp, ref s, i, (s[i] - '0'));
                }

                return dp[0];
            }
        }
    }