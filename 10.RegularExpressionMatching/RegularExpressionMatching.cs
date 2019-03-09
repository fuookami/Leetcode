using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public enum Type
    {
        Do,
        Letter,
        End
    }

    public class Node
    {
        public Type NodeType { get; }
        public char Letter { get; }
        public bool Repeating { get; set; }
        public List<Node> NextNodes { get; set; }

        public bool Match(char ch)
        {
            switch (NodeType)
            {
                case Type.Do:
                    return true;
                case Type.Letter:
                    return Letter == ch;
                case Type.End:
                    return false;
            }
            return false;
        }

        public static Node GenerateDoNode()
        {
            return new Node(Type.Do, '.');
        }

        public static Node GenerateLetterNode(char letter)
        {
            return new Node(letter);
        }

        public static Node GenerateEndNode()
        {
            return new Node(Type.End, '$');
        }

        private Node(Type type, char letter)
        {
            NodeType = type;
            Letter = letter;
            Repeating = false;
            NextNodes = new List<Node>();
        }

        private Node(char letter)
            : this(Type.Letter, letter)
        {
        }
    }

    public class NodeComparer : IEqualityComparer<Node>
    {
        public bool Equals(Node lhs, Node rhs)
        {
            return lhs.NodeType == rhs.NodeType
                && lhs.Letter == rhs.Letter
                && lhs.Repeating == rhs.Repeating;
        }

        public int GetHashCode(Node node)
        {
            return (node.Letter << 8) ^ (node.Repeating ? 1 : 0);
        }
    }

    public static List<Node> AnalyzePatternNode(string p)
    {
        List<Node> ret = new List<Node>();
        if (p.Length == 0 || p[0] == '*')
        {
            return ret;
        }
        for (int i = 0, j = p.Length; i != j; ++i)
        {
            if (p[i] == '.')
            {
                ret.Add(Node.GenerateDoNode());
            }
            else if (char.IsLower(p[i]))
            {
                ret.Add(Node.GenerateLetterNode(p[i]));
            }
            else if (p[i] == '*')
            {
                ret[ret.Count - 1].Repeating = true;
            }
            else
            {
                return null;
            }
        }
        ret.Add(Node.GenerateEndNode());
        return ret;
    }

    public static List<Node> GenerateMatchMachine(string p)
    {
        var patternNodes = AnalyzePatternNode(p);
        if (patternNodes == null || patternNodes.Count == 0)
        {
            return patternNodes;
        }
        else
        {
            List<Node> headers = new List<Node>();

            bool isHeaders = true;
            for (int i = 0, j = patternNodes.Count; i != j; ++i)
            {
                if (isHeaders)
                {
                    headers.Add(patternNodes[i]);
                }
                if (!patternNodes[i].Repeating)
                {
                    isHeaders = false;
                }

                for (int m = i + 1, n = patternNodes.Count; m != n; ++m)
                {
                    patternNodes[i].NextNodes.Add(patternNodes[m]);
                    if (!patternNodes[m].Repeating)
                    {
                        break;
                    }
                }
            }

            return headers;
        }
    }

    public bool IsMatch(string s, string p)
    {
        var matchMachine = GenerateMatchMachine(p);
        if (matchMachine == null)
        {
            return false;
        }
        else if (s.Length == 0)
        {
            return matchMachine.Count == 0 || 
                matchMachine.Find(node => node.NodeType == Type.End) != null;
        }
        else
        {
            var j = s.Length;
            List<Tuple<Node, int>> matchNodeDeque = new List<Tuple<Node, int>>();
            foreach (var matchNode in matchMachine)
            {
                matchNodeDeque.Add(new Tuple<Node, int>(matchNode, 0));
            }
            while (matchNodeDeque.Count != 0)
            {
                var currMatchNode = matchNodeDeque[0].Item1;
                var i = matchNodeDeque[0].Item2;
                matchNodeDeque.RemoveAt(0);
                if (currMatchNode.Repeating)
                {
                    while (true)
                    {
                        if (!currMatchNode.Match(s[i]))
                        {
                            foreach (var nextMatchNode in currMatchNode.NextNodes)
                            {
                                if (nextMatchNode.NodeType != Type.End && nextMatchNode.Match(s[i]) 
                                    && matchNodeDeque.Find(tuple => tuple.Item1 == nextMatchNode && tuple.Item2 == i) == null)
                                {
                                    matchNodeDeque.Add(new Tuple<Node, int>(nextMatchNode, i));
                                }
                            }
                            break;
                        }
                        else
                        {
                            ++i;
                            if (i == j)
                            {
                                break;
                            }
                            foreach (var nextMatchNode in currMatchNode.NextNodes)
                            {
                                if (nextMatchNode.NodeType != Type.End && nextMatchNode.Match(s[i])
                                    && matchNodeDeque.Find(tuple => tuple.Item1 == nextMatchNode && tuple.Item2 == i) == null)
                                {
                                    matchNodeDeque.Add(new Tuple<Node, int>(nextMatchNode, i));
                                }
                            }
                        }
                    }
                    if (i == j)
                    {
                        if (currMatchNode.NextNodes.Find(node => node.NodeType == Type.End) != null)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (currMatchNode.Match(s[i]))
                    {
                        ++i;
                        if (i == j)
                        {
                            if (currMatchNode.NextNodes.Find(node => node.NodeType == Type.End) != null)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            foreach (var nextMatchNode in currMatchNode.NextNodes)
                            {
                                if (nextMatchNode.NodeType != Type.End && nextMatchNode.Match(s[i])
                                    && matchNodeDeque.Find(tuple => tuple.Item1 == nextMatchNode && tuple.Item2 == i) == null)
                                {
                                    matchNodeDeque.Add(new Tuple<Node, int>(nextMatchNode, i));
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
