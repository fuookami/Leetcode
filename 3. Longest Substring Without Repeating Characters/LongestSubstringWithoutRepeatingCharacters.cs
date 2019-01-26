using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        List<char> sub = new List<char>();
        int maxLen = 0;
        foreach (var ch in s) {
            int index = sub.IndexOf(ch);
            if (index != -1) {
                if (sub.Count > maxLen) {
                    maxLen = sub.Count;
                }
                sub.RemoveRange(0, index + 1);
            }
            sub.Add(ch);
        }
        if (sub.Count > maxLen) {
            maxLen = sub.Count;
        }
        return maxLen;
    }
}

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        
    }
}
