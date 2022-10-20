public class MedianFinder 
{
    List<int> Numbers;
    
    public MedianFinder() 
    {
        Numbers = new List<int>();
    }
    
    public void AddNum(int num) 
    {
        // Find where to insert this num in Numbers using Binary Search
        // NOTE: Binary Search is logarithmic time complexity O(logn) 
        int position = Numbers.BinarySearch(num);
        
        // So if BinarySearch returns -1 it means we should insert at the first position
        if (position < 0)
        {
            position = ~position; // Bitwise complement of -1 is 0
        }
        
        Numbers.Insert(position, num);
    }
    
    public double FindMedian() 
    {
        int count = Numbers.Count;
        if (count % 2 == 0)
        {
            // Even number of elements
            return (double)((Numbers[count / 2 - 1] + Numbers[count / 2]) * 0.5);
        }
        else
        {
            // Odd number of elements
            return (double)(Numbers[count / 2]);
        }            
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */