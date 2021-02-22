// Definition for singly-linked list.
#[derive(PartialEq, Eq, Debug)]
pub struct ListNode {
    pub val: i32,
    pub next: Option<Box<ListNode>>,
}

impl ListNode {
    #[inline]
    fn new(val: i32) -> Self {
        Self { next: None, val }
    }

    fn new_list(val: &[i32]) -> Box<ListNode> {
        let mut head = Box::new(Self::new(val[0]));
        let mut curr = &mut *head;
        for i in 1..val.len() {
            curr = curr.append(val[i]);
        }
        head
    }

    fn append(&mut self, val: i32) -> &mut Self {
        let next = Box::new(Self::new(val));
        self.next = Option::Some(next);
        self.next.as_mut().unwrap()
    }
}

struct Solution {}

impl Solution {
    fn append(node: &mut ListNode, val: i32) -> &mut ListNode {
        node.next = Option::Some(Box::new(ListNode::new(val)));
        node.next.as_mut().unwrap()
    }

    pub fn add_two_numbers(
        l1: Option<Box<ListNode>>,
        l2: Option<Box<ListNode>>,
    ) -> Option<Box<ListNode>> {
        let mut head = Box::new(ListNode::new(0));
        let mut curr = &mut *head;
        let mut carry = false;
        let mut lhs_curr = l1.as_ref();
        let mut rhs_curr = l2.as_ref();
        while !lhs_curr.is_none() || !rhs_curr.is_none() {
            let mut sum = if carry { 1 } else { 0 };

            if let Option::Some(ref node) = lhs_curr {
                sum += node.val;
                lhs_curr = node.next.as_ref();
            }
            if let Option::Some(ref node) = rhs_curr {
                sum += node.val;
                rhs_curr = node.next.as_ref();
            }
            carry = sum >= 10;
            curr = Self::append(curr, sum % 10);
        }
        if carry {
            Self::append(curr, 1);
        }
        head.next
    }
}

fn print(head: &Box<ListNode>) {
    let mut curr = Option::Some(head);
    while !curr.is_none() {
        print!("{}, ", curr.unwrap().val);
        match &curr.unwrap().next {
            Option::Some(next) => curr = Option::Some(&next),
            Option::None => break,
        }
    }
    print!("\n");
}

fn main() {
    let list1 = ListNode::new_list(&[9, 9, 9, 9, 9, 9, 9]);
    let list2 = ListNode::new_list(&[9, 9, 9, 9]);
    let list3 = Solution::add_two_numbers(Option::Some(list1), Option::Some(list2));
    print(list3.as_ref().unwrap());
}
