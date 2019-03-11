using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public static List<int> Get4SumList(int num1, int num2, int num3, int target, Dictionary<int, int> table) {
        int dis = target - num1 - num2 - num3;
        return dis <= num3 ? null : 
            table.ContainsKey(dis) ? new List<int>{ num1, num2, num3, dis } : null;
    }

    public static List<List<int>> Get4SumList(int num1, int num2, int target, Dictionary<int, int> table) {
        List<List<int>> ret = new List<List<int>>();
        int dis = target - num1 - num2;
        foreach (var pair in table.Where(pair => pair.Key > num2)) {
            if (pair.Key * 2 > dis) {
                break;
            }
            if (pair.Value >= 2 && pair.Key * 2 == dis) {
                ret.Add(new List<int>{ num1, num2, pair.Key, pair.Key });
            } 
            if (pair.Value >= 1) {
                var list = Get4SumList(num1, num2, pair.Key, target, table);
                if (list != null) {
                    ret.Add(list);
                }
            }
        }
        return ret;
    }

    public static List<List<int>> Get4SumList(int num1, int target, Dictionary<int, int> table) {
        List<List<int>> ret = new List<List<int>>();
        int dis = target - num1;
        foreach (var pair in table.Where(pair => pair.Key > num1)) {
            if (pair.Key * 3 > dis) {
                break;
            }
            if (pair.Value >= 3 && pair.Key * 3 == dis) {
                ret.Add(new List<int>{ num1, pair.Key, pair.Key, pair.Key });
            } 
            if (pair.Value >= 2) {
                var list = Get4SumList(num1, pair.Key, pair.Key, target, table);
                if (list != null) {
                    ret.Add(list);
                }
            } 
            if (pair.Value >= 1) {
                ret.AddRange(Get4SumList(num1, pair.Key, target, table));
            }
        }
        return ret;
    }

    public IList<IList<int>> FourSum(int[] nums, int target) {
        Dictionary<int, int> table = new Dictionary<int, int>();
        Array.Sort(nums);
        foreach (var num in nums) {
            if (!table.ContainsKey(num)) {
                table.Add(num, 0);
            }
            ++table[num];
        }

        List<IList<int>> ret = new List<IList<int>>();
        foreach (var pair in table) {
            if (pair.Key * 4 > target) {
                break;
            }
            if (pair.Value >= 4 && pair.Key * 4 == target) {
                ret.Add(new List<int>{ pair.Key, pair.Key, pair.Key, pair.Key });
            } 
            if (pair.Value >= 3) {
                var list = Get4SumList(pair.Key, pair.Key, pair.Key, target, table);
                if (list != null) {
                    ret.Add(list);
                }
            } 
            if (pair.Value >= 2) {
                ret.AddRange(Get4SumList(pair.Key, pair.Key, target, table));
            }
            if (pair.Value >= 1) {
                ret.AddRange(Get4SumList(pair.Key, target, table));
            }
        }
        return ret;
    }
}
