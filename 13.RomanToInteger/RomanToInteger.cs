using System.Collections.Generic;

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

    public static Dictionary<char, RomanPattern> GetPatterns() {
        Dictionary<char, RomanPattern> ret = new Dictionary<char, RomanPattern>();
        ret.Add(RomanPattern.I.Character, RomanPattern.I);
        ret.Add(RomanPattern.V.Character, RomanPattern.V);
        ret.Add(RomanPattern.X.Character, RomanPattern.X);
        ret.Add(RomanPattern.L.Character, RomanPattern.L);
        ret.Add(RomanPattern.C.Character, RomanPattern.C);
        ret.Add(RomanPattern.D.Character, RomanPattern.D);
        ret.Add(RomanPattern.M.Character, RomanPattern.M);
        return ret;
    }

    public int RomanToInt(string s) {
        var matches = new List<Tuple<RomanPattern, bool>>();
        if (s.Length == 0) {
            return 0;
        } else {
            var patterns = GetPatterns();
            for (int i = 0, j = s.Length; i != j; ++i) {
                var pattern = patterns[s[i]];
                if (pattern == null) {
                    return 0;
                }
                int k = matches.Count - 1;
                if (k != -1 && pattern.Prefix == matches[k].Item1) {
                    matches.RemoveAt(k);
                    matches.Add(new Tuple<RomanPattern, bool>(pattern, true));
                } else {
                    matches.Add(new Tuple<RomanPattern, bool>(pattern, false));
                }
            }
        }

        int ret = 0;
        foreach (var match in matches) {
            var pattern = match.Item1;
            ret += match.Item2 ? (pattern.Unit - pattern.Prefix.Unit) : pattern.Unit;
        }
        return ret;
    }
}
