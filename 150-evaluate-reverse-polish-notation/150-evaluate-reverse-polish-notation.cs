public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        foreach(var t in tokens) {
            if(t=="+" || t=="-" ||t=="*" ||t=="/") {
                int a = stack.Pop();
                int b = stack.Pop();
                if(t=="+") {
                    stack.Push(a+b);
                }else if(t=="-") {
                    stack.Push(b - a);
                }else if(t=="*") {
                    stack.Push(b * a);
                }else {
                    stack.Push((int)(b / a));
                }
            } else {
                stack.Push(int.Parse(t));
            }
        }
        
        return stack.Pop();
    }
}