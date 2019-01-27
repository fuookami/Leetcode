using System.Linq;

public class Solution {
    public string LongestPalindrome(string s) {
        if (s.Length <= 1) {
            return s;
        }
        var maxLen = default(int);
        var thisLen = default(int);
        var currBegin = default(int);
        for (int i = 0, j = s.Length, k = s.Length - 1; i != j; ) {
            var ch = s[i];
            var p = i - 1;
            var q = i + 1;
            for (; p >= 0 && s[p] == ch; --p);
            for (; q != j && s[q] == ch; ++q);
            i = q;

            for (; p >= 0 && q != j && s[p] == s[q]; --p, ++q);
            thisLen = q - p - 1;
            if (thisLen > maxLen) {
                maxLen = thisLen;
                currBegin = p + 1;
            }
            if (maxLen >= k) {
                break;
            }
        }
        return s.Substring(currBegin, maxLen);
    }
}
