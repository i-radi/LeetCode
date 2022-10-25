public class Solution {
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        
        List<string> res = new List<string>();
        if(words == null || words.Length == 0)
            return res;
      
        HashSet<string> wordSet = new HashSet<string>();
        Array.Sort(words, (a,b) => a.Length - b.Length);
        foreach(var word in words)
        {
            if(IsConcatenated(word, wordSet))
                res.Add(word);
            
            wordSet.Add(word);
        }
        
        return res;
    }
    
    public bool IsConcatenated(string word, HashSet<string> wordSet)
    {
        if(wordSet.Count == 0)
            return false;
        
        bool[] dp = new bool[word.Length + 1];
        dp[0] = true;
        
        // check substrings starting with length 1 for current word
        for(int i = 1; i <= word.Length; i++)
        {
            // check if the substring is concatenated
            // divide the substring into 2 parts, the 1st part has length j
            for(int j = 0; j < i; j++)
            {                
                if(dp[j] && wordSet.Contains(word.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }
        
        return dp[word.Length];
    }
}