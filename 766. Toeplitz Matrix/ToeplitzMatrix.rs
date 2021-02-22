struct Solution {}

impl Solution {
    pub fn is_toeplitz_matrix(matrix: Vec<Vec<i32>>) -> bool {
        if matrix.is_empty() || matrix.first().unwrap().is_empty() {
            return true;
        }

        let m = matrix.len();
        let n = matrix.first().unwrap().len();
        for k in (0..m).rev() {
            let mut i = k;
            let mut j = 0;
            let val = matrix[i][j];
            while i != m && j != n {
                if matrix[i][j] != val {
                    return false;
                }
                i += 1;
                j += 1;
            }
        }
        for k in (1..n).rev() {
            let mut i = 0;
            let mut j = k;
            let val = matrix[i][j];
            while i != m && j != n {
                if matrix[i][j] != val {
                    return false;
                }
                i += 1;
                j += 1;
            }
        }
        return true;
    }
}

fn main() {
    println!(
        "{}",
        Solution::is_toeplitz_matrix(vec!(vec!(1, 2, 3, 4), vec!(5, 1, 2, 3), vec!(9, 5, 1, 2)))
    );
    println!(
        "{}",
        Solution::is_toeplitz_matrix(vec!(vec!(1, 2), vec!(2, 2)))
    );
    println!(
        "{}",
        Solution::is_toeplitz_matrix(vec!(vec!(11, 74, 0, 93), vec!(40, 11, 74, 7)))
    );
}
