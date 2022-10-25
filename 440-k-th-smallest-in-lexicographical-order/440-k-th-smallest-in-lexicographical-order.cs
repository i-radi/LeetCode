 public class Solution
        {
            private void Helper(IList<int> res, IList<int> inputDigits, int startDigit, int k, int? trackIdx, int maxLength)
            {
                if (startDigit == 0)
                {
                    if (k == 0)
                    {
                        return;
                    }

                    k--;
                }

                if (maxLength == 0)
                {
                    return;
                }

                for (int digit = startDigit; digit <= 9; digit++)
                {
                    if (trackIdx == null || inputDigits[trackIdx.Value] > digit)
                    {
                        int t = maxLength;
                        int count = (((int)Math.Pow(10, t) - 1)) / 9;
                        if (k >= count)
                        {
                            k -= count;
                        }
                        else
                        {
                            res.Add(digit);
                            Helper(res, inputDigits, 0, k, null, maxLength - 1);
                            return;
                        }
                    }
                    else
                    {
                        if(inputDigits[trackIdx.Value] < digit)
                        {
                            int t = maxLength - 1;
                            int count = (((int)Math.Pow(10, t) - 1)) / 9;

                            if (k >= count)
                            {
                                k -= count;
                            }
                            else
                            {
                                res.Add(digit);
                                Helper(res, inputDigits, 0, k, null, maxLength - 2);
                                return;
                            }
                        }
                        else
                        {
                            int t = maxLength - 1;
                            int countOfCutSize = (((int)Math.Pow(10, t) - 1)) / 9;
                            int tmp = 0;
                            for (int i = trackIdx.Value + 1; i < inputDigits.Count; i++)
                            {
                                tmp *= 10;
                                tmp += inputDigits[i];
                            }

                            int count = countOfCutSize + tmp + 1;


                            if (k >= count)
                            {
                                k -= count;
                            }
                            else
                            {
                                res.Add(digit);
                                Helper(res, inputDigits, 0, k, trackIdx + 1, maxLength - 1);
                                return;
                            }

                        }
                    }
                }
            }

            public int FindKthNumber(int n, int k)
            {
                checked
                {
                    k--;
                    int digitsCount = (int) Math.Floor(Math.Log10(n)) + 1;
                    List<int> inputDigits = new List<int>(digitsCount);


                    int num = n;
                    while (num != 0)
                    {
                        inputDigits.Add(num % 10);
                        num /= 10;
                    }

                    inputDigits.Reverse();

                    IList<int> resDigits = new List<int>();

                    Helper(resDigits, inputDigits, 1, k, 0, digitsCount);

                    int res = 0;
                    for (int i = 0; i < resDigits.Count; i++)
                    {
                        res *= 10;
                        res += resDigits[i];
                    }
                    return res;
                }
            }
        }