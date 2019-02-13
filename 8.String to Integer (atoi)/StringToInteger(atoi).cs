using System;

public class Solution {
    public int MyAtoi(string str) {
        int ret = 0;
        int i = 0;
        bool negative = false;
        for (; i != str.Length && str[i] == ' '; ++i);
        if (i == str.Length) {
            return 0;
        }
        if (str[i] == '-') {
            negative = true;
            ++i;
        } else if (str[i] == '+') {
            ++i;
        }

        try {
            checked {
                for (; i != str.Length && Char.IsDigit(str[i]); ++i) {
                    ret = ret * 10 + (str[i] - '0');
                }
            }
        } catch (OverflowException) {
            return negative ? Int32.MinValue : Int32.MaxValue;
        }
        return negative ? -ret : ret;
    }
}
