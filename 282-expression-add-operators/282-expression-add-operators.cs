public class Solution {
    public IList<string> AddOperators(string num, int target) {
        
        List<string> res = new List<string>();
        if(string.IsNullOrEmpty(num))
            return res;
        
        dfs(num, target, 0, "", 0, 0, res);
        return res;
    }
    
    private void dfs(string num, int target, int idx, string expression, long expressionVal, long lastMonomial, List<string> res)
    {
        if(idx == num.Length)
        {
            if(expressionVal == target)
                res.Add(expression);
            return;
        }
        
        for(int i = idx; i < num.Length; i++)
        {
            string currStr = num.Substring(idx, i - idx + 1);
            
            if(currStr.Length > 1 && num[idx] == '0') break;  
            long currVal = long.Parse(currStr);
            
            if(idx == 0)
            {
                dfs(num, target, i + 1, expression + currStr, currVal, currVal, res);
            }
            else
            {
                // '+' and '-'
                dfs(num, target, i + 1, expression + "+" + currStr, expressionVal + currVal, currVal, res);
                dfs(num, target, i + 1, expression + "-" + currStr, expressionVal - currVal, -currVal, res);

                // '*'
                dfs(num, target, i + 1, expression + "*" + currStr, expressionVal - lastMonomial + lastMonomial * currVal, lastMonomial* currVal, res);
            }
        }
    }
}
