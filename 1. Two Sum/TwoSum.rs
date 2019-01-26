struct Solution {
}

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        use std::collections::HashMap;
        let mut map : HashMap<i32, usize> = HashMap::with_capacity(nums.len());
        for i in 0..nums.len() {
            let difference = target - nums[i];
            if map.contains_key(&difference) {
                return vec![*map.get(&difference).unwrap() as i32, i as i32];
            }
            map.insert(nums[i], i);
        }
        return vec![];
    }
}

fn main() {
    let ret = Solution::two_sum(vec![2, 7, 11, 15], 9);
    println!("{} {}", ret[0], ret[1]);
    let pat = 
}
