namespace Algorithms.LinkedLists.TestUtils;

public class LinkedListTestUtils
{
    public static ListNode ArrayToLinkedList(int[] array)
    {
        var headNode = new ListNode();
        var currentNode = headNode;

        for (var index = 0; index < array.Length; index++)
        {
            var value = array[index];
            currentNode.val = value;

            var isLast = index == array.Length - 1;
            if (isLast)
            {
                break;
            }

            var nextNode = new ListNode();
            currentNode.next = nextNode;
            currentNode = nextNode;
        }

        return headNode;
    }

    public static int[] LinkedListToArray(ListNode head)
    {
        var resultList = new List<int>();
        var currentNode = head;

        while (currentNode != null)
        {
            resultList.Add(currentNode.val);
            currentNode = currentNode.next;
        }

        return resultList.ToArray();
    }
}