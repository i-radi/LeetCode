public class Solution
{
    public string RemoveKdigits(string num, int k)
    {
        Stack<char> stack = new();
        int numberOfRemoves = 0;
        foreach (char character in num)
        {
            while (k > numberOfRemoves && stack.Count > 0 && stack.Peek() > character)
            {
                stack.Pop();
                numberOfRemoves++;
            }

            stack.Push(character);
        }

        while (k > numberOfRemoves && stack.Count > 0)
        {
            stack.Pop();
            numberOfRemoves++;
        }

        int[] digits = stack.Reverse().SkipWhile(x => x is '0').Select(x => x - '0').ToArray();
        return digits.Any() ? string.Concat(digits) : "0";
    }
}