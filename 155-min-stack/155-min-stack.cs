public class MinStack {

    Stack<int> stack = new Stack<int>();
    Stack<int> minStack = new Stack<int>();
    
    public MinStack() 
    {
        
    }
    
    public void Push(int val) 
    {
    if(stack.Count == 0 || minStack.Peek() >= val)
        {
            minStack.Push(val);
        }
        
        stack.Push(val); 
    }
    
    public void Pop()
    {
        if (stack.Count == 0) return;
        var v = stack.Pop();
        if(minStack.Peek() == v)
        {
            minStack.Pop();
        }
    }

    public int Top()
    {
        return stack.Peek();
    }

    public int GetMin()
    {
        return minStack.Peek();
    }
}


/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */