using System;

public class Solution {
    public int MyAtoi(string str) {
        str = str.Trim();
        bool negative = false;
        int index = 0;
        if (str.Length == 0) {
            return 0;
        }
        if (str[0] == '-') {
            negative = true;
            index = 1;
        } else if (str[0] == '+') {
            index = 1;
        }
        int temp = 0;
        try {
            checked {
                foreach (var ch in str.Substring(index)) {
                    if (!Char.IsDigit(ch)) {
                        return negative ? -temp : temp;
                    }
                    temp = temp * 10 + (ch - '0');
                }
            }
        } catch (OverflowException) {
            return negative ? Int32.MinValue : Int32.MaxValue;
        }
        return negative ? -temp : temp;
    }
}
