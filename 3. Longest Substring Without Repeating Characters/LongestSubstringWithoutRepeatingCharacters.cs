using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var previous = 0;
        var maxLen = 0;
        var thisLen = 0;
        var indexs = new int[128];
        for (int i = 0; i != 128; ++i) {
            indexs[i] = -1;
        }

        for (int i = 0; i != s.Length; ++i) {
            var ch = (int)s[i];
            var index = indexs[ch];
            if (index >= previous) {
                thisLen = i - previous;
                if (thisLen > maxLen) {
                    maxLen = thisLen;
                }
                previous = index + 1;
            }
            indexs[ch] = i;
        }
        thisLen = s.Length - previous;
        if (thisLen > maxLen) {
            maxLen = thisLen;
        }
        return maxLen;
    }
}
