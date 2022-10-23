public class Solution {
    public int Calculate(string s) {
        int num=0;
        int sign=1;
        int res = 0;
        Stack<int> stack = new Stack<int>();    //use stack to save (), put res and sign to stack for '('
        for (int i=0; i<s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                num=0;  //reset number here
                while(i<s.Length && char.IsDigit(s[i])) //go to last digit and do calculation
                {
                    num = num*10 + s[i++]-'0';  //you can change i within for
                }
                i--;    
                res += num * sign;  //go to last digit in this number and do calculation
            }
            else if (s[i] == '+')
                sign=1;
            else if (s[i] == '-')
                sign=-1;
            else if (s[i] == '(') 
            {
                stack.Push(res);
                stack.Push(sign);
                sign = 1;       //don't forget reset sign and result
                res = 0;
            }
            else if (s[i] == ')')
                res = res * stack.Pop() + stack.Pop();  //1st pop is sign, 2nd pop is prev result
        }
        return res;
    }
}