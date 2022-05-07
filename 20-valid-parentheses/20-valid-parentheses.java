class Solution {
    public static boolean isValid(String s) {
        Stack<Character> leftSymbols = new Stack<>();
        for (char c : s.toCharArray()) {
            if (c == '(' || c == '{' || c == '[') {
                leftSymbols.push(c);
            }
            else if (c == ')' && !leftSymbols.isEmpty() && leftSymbols.peek() == '(') {
                leftSymbols.pop();
            } else if (c == '}' && !leftSymbols.isEmpty() && leftSymbols.peek() == '{') {
                leftSymbols.pop();
            } else if (c == ']' && !leftSymbols.isEmpty() && leftSymbols.peek() == '[') {
                leftSymbols.pop();
            }
            else {
                return false;
            }
        }
        return leftSymbols.isEmpty();
    }
     public static void main(String args[])
    {
        String str = "({[]})";
        System.out.print(isValid(str));
    }
}