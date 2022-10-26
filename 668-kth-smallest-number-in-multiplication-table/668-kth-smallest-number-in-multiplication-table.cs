 public class Solution
    {
        private long Check(int m, int n, long candidate)
        {
            long res = 0;

            for (int i = 1; i <= m; i++)
            {
                res += Math.Min(candidate / i, n);
            }

            return res;
        }

        public int FindKthNumber(int m, int n, int k)
        {
            checked
            {

                long left = 1;
                long right = m * n;

                while (left < right)
                {
                    if (right - left <= 1)
                    {
                        break;
                    }

                    long mid = left + (right - left) / 2;
                    long check = Check(m, n, mid);


                    if (check < k)
                    {
                        left = mid;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                if (Check(m,n,left) < k)
                {
                    return (int)right;
                }

                return (int) left;
            }
        }
    }