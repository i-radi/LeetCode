public class Solution
{
    public bool IsPalindrome(ListNode head)
    {
        if (head == null || head.next == null) return true;

        ListNode fast = head;
        ListNode slow = head;

        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        fast = head;
        slow = Reverse(slow);

        while (slow != null)
        {
            if (slow.val != fast.val) return false;
            
            fast = fast.next;
            slow = slow.next;
        }

        return true;
    }

    private ListNode Reverse(ListNode node)
    {
        ListNode prev = null;
        ListNode next = null;
        while(node!=null)
        {
            next = node.next;
            node.next = prev;
            prev = node;
            node = next;
        }

        return prev;
    }
}
