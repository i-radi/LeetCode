public class Solution {
    public int StrongPasswordChecker(string password) 
    {
        if (password == null || password.Length == 0)
            return 6;
        
        int countAdd = (password.Length < 6)? 6 -  password.Length : 0;
        int countRemove = (password.Length >20)? password.Length - 20 : 0;
        
        bool hasLowerCase = false;
        bool hasUpperCase = false;
        bool hasDigit = false;
       
        int countSeries3 = 0;
        int countSeries4 = 0;
        int countSeries5 = 0;
        int breaksNeeded = 0;
        
        char lastCh = '\n'; 
        int lastChCount = 0;
        
        foreach(char ch in password)
        {
            if (ch>='0' && ch<='9') hasDigit = true;
            if (ch>='A' && ch<='Z') hasUpperCase = true;
            if (ch>='a' && ch<='z') hasLowerCase = true;
            
            if (lastCh == ch)
            {
                lastChCount ++;
            }
            else
            {
               if (lastChCount > 2)
               {
                    if (lastChCount % 3 == 0) countSeries3++;
                    else if ((lastChCount - 1) % 3 == 0) countSeries4++;
                    else countSeries5++;
                   
                    breaksNeeded +=  lastChCount / 3;
               }
               lastChCount = 1;
               lastCh = ch; 
            }
        }

       if (lastChCount > 2)
       {
            if (lastChCount % 3 == 0) countSeries3++;
            else if ((lastChCount - 1) % 3 == 0) countSeries4++;
            else countSeries5++;
           
            breaksNeeded +=  lastChCount / 3;
       }

        int countRemoveAdj = countRemove;
        
        breaksNeeded -= Math.Min(countRemoveAdj, countSeries3);
        countRemoveAdj -= Math.Min(countRemoveAdj, countSeries3);
        
        if (countRemoveAdj > 0)
        {
            breaksNeeded -= Math.Min(countRemoveAdj/2, countSeries4);
            countRemoveAdj -= Math.Min(countRemoveAdj, countSeries4 * 2);
        }

        if (countRemoveAdj > 0)
        {
            breaksNeeded -= Math.Min(countRemoveAdj/3, breaksNeeded);
        }
        
        int countMissing = (hasLowerCase? 0 : 1) + (hasUpperCase? 0 : 1) + (hasDigit? 0 : 1);

        return Math.Max( Math.Max(countMissing, countAdd), breaksNeeded) + countRemove;
        
    }
}