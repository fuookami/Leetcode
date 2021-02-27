using System.Collections.Generic;

public class Solution {
    public bool IsValid(string s) {
        Dictionary<char, char> ValidParentheses = new Dictionary<char, char>{
            { ')', '(' }, 
            { ']', '[' }, 
            { '}', '{' }
        };

        if (s.Length % 2 == 1) {
            return false;
        }

        Stack<char> stack = new Stack<char>(s.Length);
        foreach (var ch in s) {
            if (ValidParentheses.ContainsKey(ch)) {
                if (stack.Count == 0 || stack.Pop() != ValidParentheses[ch]) {
                    return false;
                }
            } else {
                stack.Push(ch);
            }
        }
        return stack.Count == 0;
    }
}
