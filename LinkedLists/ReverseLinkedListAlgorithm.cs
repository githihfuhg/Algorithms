using Algorithms.LinkedLists.TestUtils;
using Xunit;

namespace Algorithms.LinkedLists;

/// <summary>
/// Reverse Linked List.
/// <see href="https://leetcode.com/problems/reverse-linked-list"/>
/// </summary>
public class ReverseLinkedListAlgorithm
{
    public static ListNode ReverseList(ListNode head)
    {
        ListNode currentNode = head;
        ListNode previousNode = null;
        while (currentNode != null)
        {
            var nextNode = currentNode.next;
            currentNode.next = previousNode;
            previousNode = currentNode;
            currentNode = nextNode;
        }

        return previousNode;
    }

    public static ListNode ReverseListRecursive(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        var newHead = ReverseListRecursive(head.next);

        head.next.next = head;
        head.next = null;

        return newHead;
    }
}

public class ReverseLinkedListAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5, }, new[] { 5,4,3,2,1 })]
    [InlineData(new[] { 1,2 }, new[] { 2,1})]
    public void ReverseList_ShouldEqualExpected(int[] input, int[] expected)
    {
        // Arrange
        var head = LinkedListTestUtils.ArrayToLinkedList(input);

        // Act
        var result = ReverseLinkedListAlgorithm.ReverseList(head);
        var resultArray = LinkedListTestUtils.LinkedListToArray(result);

        // Assert
        Assert.Equal(resultArray, expected);
    }
}