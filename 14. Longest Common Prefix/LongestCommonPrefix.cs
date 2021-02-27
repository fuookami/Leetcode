using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (strs.Length == 0) {
            return "";
        } else if (strs.Length == 1) {
            return strs[0];
        }

        int minLength = strs.Min(str => str.Length);
        List<char> prefix = new List<char>(minLength);
        for (int i = 0, j = minLength; i != j; ++i) {
            char ch = strs[0][i];
            for (int p = 1, q = strs.Length; p != q; ++p) {
                if (strs[p][i] != ch) {
                    return new string(prefix.ToArray());
                }
            }

            prefix.Add(ch);
        }

        return new string(prefix.ToArray());
    }
}
