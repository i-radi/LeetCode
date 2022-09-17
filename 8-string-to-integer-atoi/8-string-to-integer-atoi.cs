public class Solution {
    public int MyAtoi(string s) {
        if(s == String.Empty) return 0;
        
        int i = 0;
        int value = 0; 
        bool isNegative = false; 
        
        // skip leading spaces
        while(i < s.Length) {
            if(s[i] == ' '){
                i++;
                continue;
            }
            else{
                break;
            }
        }
        
        // if all chars are whitespaces and reached end of string
        // implies no digits return 0
        if(i == s.Length){
            return 0;
        }
        
        // verify first char after skipping whitespaces
        // is either - or + 
        // and not alphabet
        var first = s[i];
        if(first == '-') {
            isNegative = true;
            i++;
        } else if(first == '+') {
            isNegative = false;
            i++;
        } else if(!IsDigit(first)) { // start with non-digit return 0;
            return 0;
        }
        
        while(i < s.Length) {
            // validate is digit
            if(IsDigit(s[i])) {
                var digit = (s[i] - '0');
                // make sure number is within int.maxvalue and int.minValue
                if(Int32.MaxValue/10 < value || 
                   (Int32.MaxValue/10 == value && 
                   Int32.MaxValue %10 < digit)){
                    if(isNegative) {
                        return Int32.MinValue;
                    } else{
                        return Int32.MaxValue;
                    }
                    
                }
                
                // update value
                value = value * 10 + digit;
                i++;
            }
            else { // stop when non digit is found in trailing.
                break;
            }
        }
        
        if(isNegative) {
            return -1 * value;
        }
        
        return value;
        
    }
    
    private bool IsDigit(char c){
        return (c - '0' >= 0 && c - '0' <= 9 );
    }
}