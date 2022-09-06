public class Solution {
    public int DistanceBetweenBusStops(int[] distance, int start, int destination) {
         if(start==destination) return 0;
        
        int a = Math.Min(start,destination) ;
        int b = Math.Max(start,destination) ;
        int total = 0 ;
        int dis = 0;
        for(int i=a;i<b;i++) dis += distance[i];
        foreach(int j in distance) total += j;
        return Math.Min(total-dis,dis);
    }
}