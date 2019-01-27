using System.Collections.Generic;

public class Solution {
    static public List<int> MergeSortedArrays(int[] nums1, int[] nums2) {
        List<int> list = new List<int>(nums1.Length + nums2.Length);
        int i1 = 0, i2 = 0;
        int j1 = nums1.Length, j2 = nums2.Length;
        for (; i1 != j1 && i2 != j2; ) {
            if (nums1[i1] < nums2[i2]) {
                list.Add(nums1[i1]);
                ++i1;
            } else {
                list.Add(nums2[i2]);
                ++i2;
            }
        }
        if (i1 == j1) {
            for (; i2 != j2; ++i2) {
                list.Add(nums2[i2]);
            }
        } else {
            for (; i1 != j1; ++i1) {
                list.Add(nums1[i1]);
            }
        }
        return list;
    }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var list = MergeSortedArrays(nums1, nums2);
        if(list.Count % 2 == 0)
        {
            int middleIndex = list.Count / 2 - 1;
            return (double)(list[middleIndex] + list[middleIndex + 1]) / 2;
        }
        else
        {
            int middleIndex = list.Count / 2;
            return list[middleIndex];
        }
    }
}
