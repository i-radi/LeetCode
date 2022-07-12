public class Solution {
    public int[][] ReconstructQueue(int[][] people) {
        //Sort by height & rank
        Array.Sort(people, new QueueComparer()); // nlogn
        var res = new int[people.Length][];
        var count = 0;
        var height = 0;
        
        foreach(var person in people){
            height = person[0];
            count = person[1];
            var personPosition = 0;
            while(count > 0 || res[personPosition] != null){
                if (res[personPosition] == null || res[personPosition][0] >= person[0]){
                    count--;
                }
                personPosition++;
            }
            res[personPosition] = person;
        }
        return res;
    }
}

// Array of 2 elements
// Index 0 => Height
// Index 1 => Rank
public class QueueComparer : IComparer<int[]>{
    public int Compare(int[] a, int[] b){
        if (a[0] == b[0]){
            return a[1] - b[1];
        }
        return a[0] - b[0];
    }
}