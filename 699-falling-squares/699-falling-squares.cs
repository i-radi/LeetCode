public class Solution 
{
    public IList<int> FallingSquares(int[][] positions) 
    {
        var result = new List<int>();
        var intervals = new List<Interval>();
        int max = 0;
        foreach(var p in positions)
        {
            var interval = new Interval(p[0], p[0] + p[1] - 1, p[1]);
            max = Math.Max(max, InsertInterval(intervals, interval));
            result.Add(max);
        }
        
        return result;
    }
    
    private int InsertInterval(List<Interval> intervals, Interval interval)
    {
        int maxOverlappingHeight = 0;
        foreach(var i in intervals) {
            if (i.End < interval.Start) continue;
            if (i.Start > interval.End) continue;
            maxOverlappingHeight = Math.Max(maxOverlappingHeight, i.Height);
        }
        
        interval.Height += maxOverlappingHeight;
        intervals.Add(interval);
        return interval.Height;
    }
}

public class Interval
{
    public int Start;
    public int End;
    public int Height;
    public Interval(int s, int e, int h)
    {
        Start = s;
        End = e;
        Height = h;
    }
}