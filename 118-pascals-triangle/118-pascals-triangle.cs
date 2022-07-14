public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var res = new List<IList<int>>();
        //if (numRows == 0) return res;
        
        var firstRow = new List<int>();
        firstRow.Add(1);
        res.Add(firstRow);
        
        for (var i=1; i<numRows; i++){
            var prevRow = res[i-1];
            var row = new List<int>();
            
            row.Add(1);
            for (var j=1; j<i; j++){
                row.Add (prevRow[j-1]+prevRow[j]);
            }
            row.Add(1);
            res.Add(row);
        }
        
        return res;
    }
}