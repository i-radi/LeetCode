public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {
        for (int i =1;i<=arr.Length;i++){
            if (arr[i-1]<arr[i]) continue;
            return i-1;
        }
        return -1;
    }
}