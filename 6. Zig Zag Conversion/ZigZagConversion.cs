using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows <= 1) {
            return s;
        } else {
            int sum = numRows + (numRows - 2);
            int difference = sum;
            List<char> ret = new List<char>(s.Length);
            for (int i = 0, j = s.Length; i != numRows; ++i, difference -= 2) {
                int thisDifference = difference;
                if (thisDifference == 0 || thisDifference == sum) {
                    thisDifference = sum;
                    for (int p = i; p < j; p += thisDifference) {
                        ret.Add(s[p]);
                    }
                } else {
                    for (int p = i; p < j; p += thisDifference, thisDifference = sum - thisDifference) {
                        ret.Add(s[p]);
                    }
                }
            }
            return new string(ret.ToArray());
        }
    }
}
