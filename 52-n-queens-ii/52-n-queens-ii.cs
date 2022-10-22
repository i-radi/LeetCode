public class Solution {
    List<IList<string>> res;
    public int TotalNQueens(int n) {
        res = new List<IList<string>>();
        DFS(0, new List<int>(new int[n]), n);
        
        return res.Count;
    }
    
    private void DFS(int t, List<int> x, int n)
    {
        if(t >= n)
        {
            //Fill helper array with dots
            char[] chArr = new char[n];
            Array.Fill(chArr, '.');
            
            var matrix = new List<string>();
            for(int i=0; i<n; i++)
            {
                //Place Queen in helper array
                chArr[i] = 'Q';
                //Construct chess board with helper array
                matrix.Add(new string(chArr));
                //Reset helper array for next iteration
                chArr[i] = '.';                
            }
            //Add to answers
            res.Add(matrix);
        }
        else
        {
            //columns
            for(int i=0; i<n; i++)
            {
                //check new queen placement does not affect all previous queens
                bool skip = false;
                for(int j=0; j<t; j++)
                {
                    /*
                    New choice should not affect previous queens
                    1. Vertically
                    2. Diagonally Means, 
                        delta row shift = delta column shift:
                        a. Delta row = delta column,
                        b. Delta row = negative delta column
                    */
                    if(x[j] == i || Math.Abs(x[j] - i) == Math.Abs(t - j))
                    {
                        skip = true;
                        break;
                    }
                }
                if(skip) continue;
                
                //place queen
                x[t] = i;
                //recurse for next iteration
                DFS(t+1, x, n);
            }
        }
    }
}