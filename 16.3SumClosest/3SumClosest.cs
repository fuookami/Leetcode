using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static int TwoSumClosest(int num1, int num2, HashSet<int> set, int target, Func<int, bool> predicate)
    {
        int closestAbs = Int32.MaxValue;
        int closest = Int32.MaxValue;
        int sum = num1 + num2;
        foreach (var num3 in set.Where(predicate))
        {
            int dis = sum + num3 - target;
            int disAbs = Math.Abs(dis);
            if (disAbs < closestAbs)
            {
                closestAbs = disAbs;
                closest = dis;
            }
            if (closest == 0)
            {
                return 0;
            }
        }
        return closest;
    }

    public int ThreeSumClosest(int[] nums, int target)
    {
        HashSet<int> set = new HashSet<int>();
        Dictionary<int, int> table = new Dictionary<int, int>();
        Array.Sort(nums);
        foreach (var num in nums)
        {
            if (!set.Contains(num))
            {
                set.Add(num);
                table.Add(num, 0);
            }
            ++table[num];
        }

        int closestAbs = Int32.MaxValue;
        int closest = Int32.MaxValue;
        foreach (var pair in table)
        {
            int thisDisAbs = Int32.MaxValue;
            int thisDis = 0;
            int num1 = pair.Key;
            if (pair.Value >= 3)
            {
                thisDis = 3 * num1 - target;
                thisDisAbs = Math.Abs(thisDis);
                if (thisDis == 0)
                {
                    return target;
                }
            }
            if (pair.Value >= 2)
            {
                var sum = num1 * 2;
                int thisClosest = TwoSumClosest(num1, num1, set, target, e => e != num1);
                if (thisClosest == 0)
                {
                    return target;
                }
                int thisClosestAbs = Math.Abs(thisClosest);
                if (thisClosestAbs < thisDisAbs)
                {
                    thisDisAbs = thisClosestAbs;
                    thisDis = thisClosest;
                }
            }
            foreach (var num2 in set.Where(e => e > num1))
            {
                int thisClosest = TwoSumClosest(num1, num2, set, target, e => e > num2);
                if (thisClosest == 0)
                {
                    return target;
                }
                int thisClosestAbs = Math.Abs(thisClosest);
                if (thisClosestAbs < thisDisAbs)
                {
                    thisDisAbs = thisClosestAbs;
                    thisDis = thisClosest;
                }
            }

            if (thisDisAbs < closestAbs)
            {
                closestAbs = thisDisAbs;
                closest = thisDis;
            }
        }
        return target + closest;
    }
}
