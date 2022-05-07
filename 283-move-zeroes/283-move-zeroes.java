class Solution {
    public void moveZeroes(int[] a) {
       
        int i=0,j=0;
        int t=a.length-1;
        while(i<=t)
        {
            if(a[i]!=0)
            {
                a[j++]=a[i]; 
            }
            i++;
        }
        j=t-j+1;
        while(j!=0)
        {
            a[t--]=0;
            j--;
        }
    }     
}