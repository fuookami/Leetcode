using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
    public static Dictionary<char, List<char>> LetterCombinationMap = new Dictionary<char, List<char>>{
        {'2', new List<char>{'a', 'b', 'c'}},
        {'3', new List<char>{'d', 'e', 'f'}},
        {'4', new List<char>{'g', 'h', 'i'}},
        {'5', new List<char>{'j', 'k', 'l'}},
        {'6', new List<char>{'m', 'n', 'o'}},
        {'7', new List<char>{'p', 'q', 'r', 's'}},
        {'8', new List<char>{'t', 'u', 'v'}},
        {'9', new List<char>{'w', 'x', 'y', 'z'}}
    };


    public IList<string> LetterCombinations(string digits) {
        if (digits.Length == 0) {
            return new List<String>();
        }

        List<StringBuilder> deque = new List<StringBuilder>(4 * digits.Length);
        foreach (var ch in LetterCombinationMap[digits[0]]) {
            StringBuilder sb = new StringBuilder(digits.Length);
            sb.Append(ch);
            deque.Add(sb);
        }
        
        for (int i = 1, j = digits.Length; i != j; ++i) {
            var thisLetters = LetterCombinationMap[digits[i]];
            int q = deque.Count;
            for (int p = 0; p != q; ++p) {
                var prefix = deque[p].ToString();

                foreach (var ch in thisLetters) {
                    var sb = new StringBuilder(digits.Length);
                    sb.Append(prefix);
                    sb.Append(ch);
                    deque.Add(sb);
                }
            }
            deque.RemoveRange(0, q);
        }

        List<String> ret = new List<String>(deque.Count);
        foreach (var sb in deque) {
            ret.Add(sb.ToString());
        }
        return ret;
    }
}
