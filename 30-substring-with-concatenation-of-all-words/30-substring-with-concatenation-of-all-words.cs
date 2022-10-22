public class Solution {
    /// Oct. 9, 2020
    /// Using brute force solution - go over all possible start position in the string
    /// search all words in dictionary
    /// Think about pruning ideas - ? 
    /// Study C# code written:
    /// 
    public IList<int> FindSubstring(string s, string[] words) {
        var indexes = new List<int>();      
        
        if(words.Length == 0)
        {
            return indexes;
        }
        
        var size = words.Length;
        var length = words[0].Length;        
        var expect = new Dictionary<string, int>();
        
        foreach(string word in words)
        {
            if(expect.ContainsKey(word))
            {
                expect[word]++;
            }
            else
            {
                expect.Add(word, 1);
            }
        }
        
        var seen = new Dictionary<string, int>();
		
		// last i + (n * length - 1) < s.Length
        for(int start = 0; start < s.Length - size * length + 1; start++)
        {
            seen.Clear();
            
            int count = 0;
            while(count < size)
            {
                var word = s.Substring(start + count * length, length);
                
                if(!expect.ContainsKey(word))
                {
                    break;
                }                
                
                if(seen.ContainsKey(word))
                {
                    seen[word]++;
                }
                else
                {
                    seen.Add(word, 1);
                }

                if(seen[word] > expect[word])
                {
                    break;
                }               

                count++;
            }
            
            if(count == size)
            {
                indexes.Add(start);            
            }
        }
        
        return indexes;
    }
}