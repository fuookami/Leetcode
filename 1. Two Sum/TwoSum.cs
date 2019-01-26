public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0, j = nums.Length; i != j; ++i) {
            int difference = target - nums[i];
            if (map.ContainsKey(difference)) {
                return new int[2]{ map[difference], i };
            } else if (!map.ContainsKey(nums[i])) {
                map.Add(nums[i], i);
            }
        }
        return null;
    }
}
