public class Solution {
    public int[] SumEvenAfterQueries(int[] nums, int[][] queries) {

        int S = 0;
        foreach (int x in nums)
            if (x % 2 == 0)
                S += x;

        int[] ans = new int[queries.Length];

        for (int i = 0; i < queries.Length; ++i) {
            int val = queries[i][0], index = queries[i][1];
            if (nums[index] % 2 == 0) S -= nums[index];
            nums[index] += val;
            if (nums[index] % 2 == 0) S += nums[index];
            ans[i] = S;
        }

        return ans;
    }
}