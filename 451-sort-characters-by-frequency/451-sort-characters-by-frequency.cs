public class Solution {
    public string FrequencySort(string s)
    {
        var freqMap = new Dictionary<char, int>();
        foreach(var c in s)
        {
            if (!freqMap.ContainsKey(c)) freqMap.Add(c, 0);
                freqMap[c] ++;
        }

        var pq = new PriorityQueue<char, int>(new FreqComparer());
        foreach(var key in freqMap.Keys){
            pq.Enqueue(key, freqMap[key]);
        }
        var res = new StringBuilder();
        while(pq.Count > 0){
            var currentChar = pq.Dequeue();
            var freq = freqMap[currentChar];
            for(var i = 0; i < freq; i++){
                res.Append(currentChar);
            }
        }
        return res.ToString();
    }
}

public class FreqComparer: IComparer<int>{
    public int Compare(int a, int b){
        return b - a;
    }
}