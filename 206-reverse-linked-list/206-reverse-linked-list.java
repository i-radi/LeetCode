class Solution {
    public ListNode reverseList(ListNode head) {
        if (head == null || head.next == null) return head;
        ListNode pre = null;
        ListNode tmp = null;
        while (head != null) {
            tmp = head.next;//tmp stores the next node of the current node 
            head.next = pre;// the next node on the current node points to pre 
            pre = head;// refresh the pre 
            head = tmp;// refresh the current node as tmp 
        }
        return pre;
    }
}