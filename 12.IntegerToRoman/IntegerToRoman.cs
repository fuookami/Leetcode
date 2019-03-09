using System.Collections.Generic;
using System.Text;

public class Solution {
    public class RomanPattern {
        public char Character { get; }
        public int Unit { get; }
        public RomanPattern Prefix { get; }
        public static RomanPattern I { get; }
        public static RomanPattern V { get; }
        public static RomanPattern X { get; }
        public static RomanPattern L { get; }
        public static RomanPattern C { get; }
        public static RomanPattern D { get; }
        public static RomanPattern M { get; }

        static RomanPattern() {
            I = new RomanPattern('I', 1);
            V = new RomanPattern('V', 5, I);
            X = new RomanPattern('X', 10, I);
            L = new RomanPattern('L', 50, X);
            C = new RomanPattern('C', 100, X);
            D = new RomanPattern('D', 500, C);
            M = new RomanPattern('M', 1000, C);
        }

        public RomanPattern(char ch, int unit, RomanPattern prefix = null) {
            Character = ch;
            Unit = unit;
            Prefix = prefix;
        }
    }

    public static List<RomanPattern> GetPatterns() {
        return new List<RomanPattern>{ RomanPattern.M, RomanPattern.D, RomanPattern.C, RomanPattern.L, RomanPattern.X, RomanPattern.V, RomanPattern.I };
    }

    public string IntToRoman(int num) {
        List<RomanPattern> patterns = GetPatterns();
        StringBuilder sb = new StringBuilder(32);
        
        foreach (var pattern in patterns) {
            int number = num / pattern.Unit;
            sb.Append(pattern.Character, number);
            num -= number * pattern.Unit;

            if (pattern.Prefix != null) {
                var prefix = pattern.Prefix;
                int unitWithPrefix = pattern.Unit - prefix.Unit;
                if (num >= unitWithPrefix) {
                    sb.Append(prefix.Character);
                    sb.Append(pattern.Character);
                    num -= unitWithPrefix;
                }
            }
        }

        return sb.ToString();
    }
}
