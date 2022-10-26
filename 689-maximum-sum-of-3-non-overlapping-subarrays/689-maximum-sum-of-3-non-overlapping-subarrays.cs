public class Solution 
{
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        var kSumList = new List<int>();
        int kSum = 0, max = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            kSum += nums[i];
            if(i >= k) kSum -= nums[i - k];
            if(i + 1 >= k) kSumList.Add(kSum);
        }

        int[] leftMaxIndex = new int[kSumList.Count], rightMaxIndex = new int[kSumList.Count], result = new int[3];
        for(int i = 0; i < kSumList.Count; i++)
            leftMaxIndex[i] = i == 0 ? i : kSumList[i] > kSumList[leftMaxIndex[i - 1]] ? i : leftMaxIndex[i - 1];

        for(int i = kSumList.Count - 1; i >= 0; i--)
            rightMaxIndex[i] = i == kSumList.Count - 1 ? i : kSumList[i] >= kSumList[rightMaxIndex[i + 1]] ? i : rightMaxIndex[i + 1];

        for(int i = k; i < kSumList.Count - k; i++)
        {
            var sum = kSumList[i] + kSumList[leftMaxIndex[i - k]] + kSumList[rightMaxIndex[i + k]];
            if(sum > max)
            {
                max = sum;
                result = new int[] {leftMaxIndex[i - k], i, rightMaxIndex[i + k]};
            }
        }

        return result;
    }
}