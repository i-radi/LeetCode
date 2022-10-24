public class Solution 
{
    public bool IsRectangleCover(int[][] rec) 
    {
        var hashSet = new HashSet<string>();
        int  l = rec[0][0], b = rec[0][1], r = rec[0][2], t = rec[0][3], sum = 0;
        foreach(var elem in rec)
        {
            int x1 =  elem[0], y1 =  elem[1], x2 =  elem[2], y2 =  elem[3];
            l = Math.Min(l, x1); b = Math.Min(b, y1);
            r = Math.Max(r, x2); t = Math.Max(t, y2);
            string[] keys = new string[] {x1 + ":" + y1, x1 + ":" + y2, x2 + ":" + y1, x2 + ":" + y2};
            sum += (x2 - x1) * (y2 - y1);
            foreach(var key in keys)
            {
                if(hashSet.Contains(key))
                    hashSet.Remove(key);
                else
                    hashSet.Add(key);
            }
        }
        
        if(hashSet.Count != 4 || 
           !hashSet.Contains(l + ":" + b) || 
           !hashSet.Contains(l + ":" + t) || 
           !hashSet.Contains(r + ":" + b)|| 
           !hashSet.Contains(r + ":" + t))
            return false;
        
        return (r - l) * (t - b) == sum;
    }
}