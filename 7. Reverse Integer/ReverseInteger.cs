using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int Reverse(int x) {
        if (x == 0) {
            return 0;
        } else if (x == Int32.MinValue) {
            return 0;
        }
        bool negative = x < 0;
        x = Math.Abs(x);
        int temp = 0;
        for (; x != 0; x /= 10) {
            try {
                checked {
                    temp = temp * 10 + x % 10;
                }
            } catch(OverflowException) {
                return 0;
            }
        }
        return negative ? -temp : temp;
    }
}
