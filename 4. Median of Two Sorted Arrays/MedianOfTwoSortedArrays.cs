public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if (nums1.Length == 0 && nums2.Length == 0) {
            return .0;
        }
        int i1 = 0, i2 = 0;
        int j1 = nums1.Length, j2 = nums2.Length;
        int totalNum = j1 + j2;
        int counter = 0;
        int value = 0;
        if (totalNum % 2 == 0) {
            int mediumRhs = totalNum / 2;
            int mediumLhs = mediumRhs - 1;
            int lhs = 0, rhs = 0;
            while (true) {
                if (i1 == j1) {
                    value = nums2[i2];
                    ++i2;
                } else if (i2 == j2) {
                    value = nums1[i1];
                    ++i1;
                } else if (nums1[i1] < nums2[i2]) {
                    value = nums1[i1];
                    ++i1;
                } else {
                    value = nums2[i2];
                    ++i2;
                }

                if (counter == mediumLhs) {
                    lhs = value;
                } else if (counter == mediumRhs) {
                    rhs = value;
                    break;
                }
                ++counter;
            }
            return (double)(lhs + rhs) / 2;
        } else {
            int medium = totalNum / 2;
            while (true) {
                if (i1 == j1) {
                    value = nums2[i2];
                    ++i2;
                } else if (i2 == j2) {
                    value = nums1[i1];
                    ++i1;
                } else if (nums1[i1] < nums2[i2]) {
                    value = nums1[i1];
                    ++i1;
                } else {
                    value = nums2[i2];
                    ++i2;
                }

                if (counter == medium) {
                    break;
                }
                ++counter;
            }
            return (double)value;
        }
    }
}
