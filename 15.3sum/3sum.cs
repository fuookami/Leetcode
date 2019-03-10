using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public List<List<int>> Get3SumList(int num, HashSet<int> nums) {
        List<List<int>> ret = new List<List<int>>();
        foreach (var num1 in nums.Where(e => e > num)) {
            var dis = 0 - num - num1;
            if (dis <= num1) {
                break;
            }
            if (nums.Contains(dis)) {
                ret.Add(new List<int>{ num, num1, dis });
            }
        }
        return ret;
    }

    public IList<IList<int>> ThreeSum(int[] nums) {
        HashSet<int> set = new HashSet<int>();
        Dictionary<int, int> table = new Dictionary<int, int>();
        Array.Sort(nums);
        foreach (var num in nums) {
            if (!set.Contains(num)) {
                set.Add(num);
                table.Add(num, 0);
            }
            ++table[num];
        }

        List<IList<int>> ret = new List<IList<int>>();
        foreach (var pair in table) {
            var list = Get3SumList(pair.Key, set);
            if (pair.Value >= 2) {
                int dis = 0 - pair.Key * 2;
                if (dis != pair.Key && set.Contains(dis)) {
                    list.Add(pair.Key < dis ? new List<int>{ pair.Key, pair.Key, dis } : new List<int>{ dis, pair.Key, pair.Key });
                }
            } 
            if (pair.Key * 3 == 0 && pair.Value >= 3) {
                list.Add(new List<int>{ pair.Key, pair.Key, pair.Key });
            }
            
            ret.AddRange(list);
        }
        return ret;
    }
}
