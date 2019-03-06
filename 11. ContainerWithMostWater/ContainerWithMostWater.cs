public class Solution {
    public int MaxArea(int[] height) {
        int i = 0, j = height.Length - 1;
        int currMaxArea = 0;
        while (i != j) {
            int currArea = Math.Min(height[i], height[j]) * (j - i);
            if (currArea > currMaxArea) {
                currMaxArea = currArea;
            }
            if (height[i] > height[j]) {
                --j;
            } else {
                ++i;
            }
        }
        return currMaxArea;
    }
}
