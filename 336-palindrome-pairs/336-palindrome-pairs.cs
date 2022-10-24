public class Solution {
public IList<IList<int>> PalindromePairs(string[] words)
{
    // declare variables variables
    int n = words.Length;
    Node root = new Node(), ptr;
    var pairs = new List<IList<int>>();
    
    // iterate words from shortest to longest
    foreach (int i in Enumerable.Range(0, n).OrderBy(i => words[i].Length))
    {
        // check for exact reversal at previous index
        f(i);
        
        // expand odd-length palindromes
        for (int j = 0; j < words[i].Length; j++)
        {
            g(i, j, j);
        }
        // expand even-length palindromes
        for (int j = 1; j < words[i].Length; j++)
        {
            g(i, j - 1, j);
        }
        
        // add to trie
        ptr = root;
        for (int j = 0; j < words[i].Length; j++)
        {
            ptr = ptr[words[i][j]] ??= new Node();
        }
        ptr.Index = i;
    }
    
    // check if word at index i has a reverse match in the trie
    void f(int i)
    {
        int? j = h(i, 0, words[i].Length - 1);
        if (j.HasValue)
        {
            pairs.Add(new[] { j.Value, i });
            pairs.Add(new[] { i, j.Value });
        }
    }
    
    // check if word at index i can be expanded at specified starting l and r
    void g(int i, int l, int r)
    {
        // expand until we hit an edge
        while (l >= 0 && r < words[i].Length)
        {
            if (words[i][l--] != words[i][r++])
            {
                return;
            }
        }
        // more characters to the left
        if (l >= 0)
        {
            int? j = h(i, 0, l);
            if (j.HasValue)
            {
                pairs.Add(new[] { i, j.Value });
            }
        }
        // more characters to the right
        else if (r < words[i].Length)
        {
            int? j = h(i, r, words[i].Length - 1);
            if (j.HasValue)
            {
                pairs.Add(new[] { j.Value, i });
            }
        }
        // both edges hit, this is a palindrome, check for empty match
        else
        {
            if (root.Index.HasValue)
            {
                pairs.Add(new[] { root.Index.Value, i });
                pairs.Add(new[] { i, root.Index.Value });
            }
        }
    }
    
    // utility function to search trie for reversed word segment
    int? h(int i, int l, int r)
    {
        ptr = root;
        for (int j = r; j >= l; j--)
        {
            ptr = ptr[words[i][j]];
            if (ptr == null)
            {
                break;
            }
        }
        return ptr?.Index;
    }

    return pairs;
}

public class Node
{
    private Node[] nodes = new Node[26];

    public int? Index;
    public Node this[char c]
    {
        get => nodes[c - 'a'];
        set => nodes[c - 'a'] = value;
    }
}
}