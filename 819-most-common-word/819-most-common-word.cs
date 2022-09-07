public class Solution {
    
    public string MostCommonWord(string paragraph, string[] banned) {
        Dictionary<string, int> words = new Dictionary<string, int>();
        HashSet<string> ban = banned.ToHashSet();
        int max = 0;
        string maxWord = "";

        string[] strings = paragraph.ToLower().Split(new char[] {'.',',',' ','!','?',';','"','\''});

        foreach(string s in strings)
        {
            if (!String.IsNullOrEmpty(s) && words.ContainsKey(s))
            {
                words[s]++;
            }
            else if(!String.IsNullOrEmpty(s) && !ban.Contains(s))
            {
                words.Add(s,1);
            }
        }

        foreach(string s in words.Keys)
        {
            if(max < words[s])
            {
                max = words[s];
                maxWord = s;
            }
        }
        return maxWord;
    }
}