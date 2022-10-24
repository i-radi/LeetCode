public class SummaryRanges 
{
    List<int[]> ranges;
    public SummaryRanges() 
    {
        this.ranges = new List<int[]>();
    }

    public void AddNum(int val)
    {
        int index = GetIndexToInsert(val);
        if (index == this.ranges.Count)
            this.ranges.Add(new int[] {val, val});
        else if (this.ranges[index][0] <= val && val <= this.ranges[index][1]) 
            return;
        else
            this.ranges.Insert(index, new int[] {val, val});
        
        if(index + 1 < this.ranges.Count && ranges[index + 1][0] == val + 1)
        {
            this.ranges[index][1] = ranges[index + 1][1];
            this.ranges.RemoveAt(index + 1);
        }
        
        if(index - 1 >= 0 && ranges[index - 1][1] == val - 1)
        {
            this.ranges[index][0] = ranges[index - 1][0];
            this.ranges.RemoveAt(index - 1);
        }
    }
    
    public int[][] GetIntervals() 
    {
        return this.ranges.ToArray();
    }
    
    private int GetIndexToInsert(int val)
    {
        var array = this.ranges.Select(x => x[1]).ToArray();
        var index = Array.BinarySearch(array, val);
        if(index < 0) index = ~index;
        return index;
    }
}