public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode curr = head, currLastN = null, preCurrLastN = null;
        for (int i = 0; i != n; ++i) {
            curr = curr.next;
        }
        
        currLastN = head;
        if (curr == null) {
            return head.next;
        }

        curr = curr.next;
        currLastN = currLastN.next;
        preCurrLastN = head;
        while (curr != null) {
            curr = curr.next;
            currLastN = currLastN.next;
            preCurrLastN = preCurrLastN.next;
        }

        preCurrLastN.next = currLastN.next;
        return head;
    }
}
