struct Solution {}

impl Solution {
    pub fn length_of_longest_substring(s: String) -> i32 {
        let mut prev = 0;
        let mut max_len = 0;
        let mut indexes: [i32; 128] = unsafe { std::mem::zeroed() };
        for i in 0..128 {
            indexes[i] = -1;
        }

        let mut i = 0;
        for ch in s.as_bytes() {
            let j = *ch as usize;
            let index = indexes[j];
            if index >= prev {
                let this_len = i - prev;
                if this_len > max_len {
                    max_len = this_len;
                }
                prev = index + 1;
            }
            indexes[j] = i;
            i += 1;
        }

        let this_len = i - prev;
        if this_len > max_len {
            max_len = this_len;
        }
        max_len
    }
}

fn main() {
    println!(
        "{}",
        Solution::length_of_longest_substring("bbbb".to_string())
    );
}
