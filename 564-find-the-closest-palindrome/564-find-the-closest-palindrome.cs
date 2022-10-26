public class Solution 
{
    public string NearestPalindromic(string n) 
    {
        long number = Convert.ToInt64(n);
        int length = n.Length;
        bool hasEvenDigits = length % 2 == 0;
        
        // case 1: single digit
        if(n == "0")
        {
            return "1";
        }        
        
        if(number <= 10 && number > 0)
        {
            return (number - 1).ToString();
        }
        
        // case 2: 10, 100, 1000
        if(number % 10 == 0 && number != 0 && n[0] == '1' && hasAllDigit(n.Substring(1), '0'))
        {            
            return (number - 1).ToString();
        }
           
        // case 3: 11, 101, 1001
        if(number == 11 || (number % 10 == 1 && n[0] == '1' && hasAllDigit(n.Substring(1, n.Length - 2), '0')))
        {
            return (number - 2).ToString();
        }
        
        // case 4: 99,999,99999
        if(hasAllDigit(n, '9'))
        {
            return (number + 2).ToString();
        }  
        
        // case 5: check root and find palindrome        
        string root = n.Substring(0, (length + 1) / 2 );   
        int rootValue = Convert.ToInt32(root);
        
        long equal = toPalindrome(root, hasEvenDigits);
        long onePlus = toPalindrome((rootValue + 1).ToString(), hasEvenDigits);
        long oneMinus = toPalindrome((rootValue - 1).ToString(), hasEvenDigits);
        
        long diffEqual = Math.Abs(number - equal);
        long diffOnePlus = Math.Abs(number - onePlus);
        long diffOneMinus = Math.Abs(number - oneMinus);
        
        long minDiff, result;
        if(diffOnePlus < diffOneMinus)
        {
            minDiff = diffOnePlus;
            result = onePlus;
        }
        else
        {
            minDiff = diffOneMinus;
            result = oneMinus;
        }
        
        // Number is already palindrome
        if(diffEqual == 0)
        {
            return result.ToString();
        }
        
        if(diffEqual <= minDiff)
        {
            if(diffEqual < minDiff || equal < result)
            {
                return equal.ToString();
            }
        }
        
        return result.ToString();  
    } 
    
    private long toPalindrome(string n, bool hasEventDigits)
    {
        string reverse = new string(n.Reverse().ToArray());        
        if(!hasEventDigits)
        {
            reverse = reverse.Substring(1);
        }
        
        return Convert.ToInt64(n + reverse);
    }  
    
    private bool hasAllDigit(string n, char digit)
    {
        foreach(char c in n)
        {
            if(c != digit)
            {
                return false;
            }
        }
        
        return true;
    } 
}