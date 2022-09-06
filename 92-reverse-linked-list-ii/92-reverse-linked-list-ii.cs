/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {

    private bool stop;
    private ListNode left;

    public void recurseAndReverse(ListNode right, int m, int n) {

        if (n == 1) return;

        right = right.next;

        if (m > 1) this.left = this.left.next;

        this.recurseAndReverse(right, m - 1, n - 1);

        if (this.left == right || right.next == this.left) this.stop = true;   

        if (!this.stop) {
            int t = this.left.val;
            this.left.val = right.val;
            right.val = t;

            this.left = this.left.next;
        }
    }

    public ListNode ReverseBetween(ListNode head, int left, int right) {
        this.left = head;
        this.stop = false;
        this.recurseAndReverse(head, left, right);
        return head;
    }
}