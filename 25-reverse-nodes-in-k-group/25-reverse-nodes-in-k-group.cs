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
    public ListNode ReverseKGroup(ListNode head, int k) {
            ListNode currentHead = head,
                     node1 = head,
                     node2 = node1.next;
            int count = 1;

            while (true)
                if (count == k)
                {
                    currentHead = head;
                    count = 1;
                    break;
                }
                else if (currentHead.next == null && count < k)
                    return head;
                else
                {
                    currentHead = currentHead.next;
                    count++;
                }

            node1.next = null;

            while (node2 != null && count < k)
            {
                ListNode node3 = node2.next;

                node2.next = node1;
                node1 = node2;
                node2 = node3;

                count++;
            }

            if (node2 != null)
                currentHead.next = ReverseKGroup(node2, k);

            return node1;
    }
}