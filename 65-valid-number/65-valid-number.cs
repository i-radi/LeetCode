public class Solution 
{    
    private class State
    {
        public bool IsValidEndState { get; set; }

        public Func<char, State> NextState { get; set; }

        public static bool IsSign(char c)
        {
            return c == '+' || c == '-';
        }

        public static bool IsExp(char c)
        {
            return c == 'e' || c == 'E';
        }

        public static bool IsDot(char c)
        {
            return c == '.';
        }

        public static bool IsDigit(char c)
        {
            return Char.IsDigit(c);
        }
    }
    
    private State Init;
    private State Decimal;
    private State Integer;
    private State OnlyInts;
    private State Dot;
    private State Sign;
    private State Exp;
    private State DecimalSign;
    private State Invalid;
    
    public Solution()
    {
        Init = new State {
            NextState = 
                c =>
                {
                    if (State.IsDigit(c)) return Integer;
                    if (State.IsSign(c)) return Sign;
                    if (State.IsDot(c)) return Dot;
                    return Invalid;
                },
            IsValidEndState = false
        };
        
        Sign = new State {
            NextState = 
                c =>
                {
                    if (State.IsDigit(c)) return Integer;
                    if (State.IsDot(c)) return Dot;
                    return Invalid;
                },
            IsValidEndState = false
        };
        
        DecimalSign = new State {
            NextState = 
                c => State.IsDigit(c) ?  OnlyInts : Invalid,
            IsValidEndState = false
        };
        
        Dot = new State {
            NextState = 
                c => State.IsDigit(c) ? Decimal : Invalid,
            IsValidEndState = false
        };
        
        Integer = new State {
            NextState = 
                c =>
                {
                    if (State.IsDigit(c)) return Integer;
                    if (State.IsExp(c)) return Exp;
                    if (State.IsDot(c)) return Decimal;
                    return Invalid;
                },
            IsValidEndState = true
        };
        
        Decimal = new State {
            NextState = 
                c =>
                {
                    if (State.IsDigit(c)) return Decimal;
                    if (State.IsExp(c)) return Exp;
                    return Invalid;
                },
            IsValidEndState = true
        };
        
        Exp = new State {
            NextState = 
                c =>
                {
                    if (State.IsDigit(c)) return OnlyInts;
                    if (State.IsSign(c)) return DecimalSign;
                    return Invalid;
                },
            IsValidEndState = false
        };
        
        OnlyInts = new State {
            NextState = 
                c => State.IsDigit(c) ? OnlyInts : Invalid,
            IsValidEndState = true
        };
        
        Invalid = new State();      
    }
    
    public bool IsNumber(string s) {
        State state = Init;
        foreach (char c in s)
        {
            state = state.NextState(c);
            if (state.Equals(Invalid)) return false;
        }
        return state.IsValidEndState;
    }
}