public class Solution {
    public string RemoveDuplicates(string s) {
        if(string.IsNullOrEmpty(s)) return s;
        var stack = new Stack<char>();
        foreach(var c in s)
        {
            if(stack.Count == 0){
                stack.Push(c);
            }else{
                if(stack.Peek() == c){
                    stack.Pop();
                }else{
                    stack.Push(c);
                }
            }
        }
        var str = stack.ToArray();
        Array.Reverse(str);
        return new string(str);
    }
}