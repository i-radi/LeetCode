public class Solution {
public int[] MaxSlidingWindow(int[] nums, int k) {
        int[] ret=new int[nums.Length-k+1];
        List<int> li=new List<int>();
        for(int i=0;i<nums.Length;i++)
        {
            while(li.Count>0&&nums[li.Last()]<nums[i])
                li.RemoveAt(li.Count-1);
            li.Add(i);
            if(i-k>=li[0])
                li.RemoveAt(0);
            if(i-k+1>=0)
                ret[i-k+1]=nums[li[0]];
        }
        return ret;
    }
}