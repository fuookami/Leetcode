using System.Collections.Generic;

public class Solution {
    public bool IsPalindrome(int x) {
        if (x < 0) {
            return false;
        } else if (x < 10) {
            return true;
        } else if (x % 10 == 0) {
            return false;
        } else {
            int reverse = 0; 
            while (x > reverse) {
                int digit = x % 10;
                reverse = reverse * 10 + digit;
                x = x / 10;
            }

            return x == reverse || x == (reverse / 10);
        }
    }
}
