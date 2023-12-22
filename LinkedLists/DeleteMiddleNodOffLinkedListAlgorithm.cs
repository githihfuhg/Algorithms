using Algorithms.LinkedLists.TestUtils;
using Xunit;

namespace Algorithms.LinkedLists;

/// <summary>
/// Delete the Middle Node of a Linked List.
/// <see href="https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list"/>
/// </summary>
public class DeleteMiddleNodOffLinkedListAlgorithm
{
    public static ListNode DeleteMiddle(ListNode head)
    {
        var linkedListCount = 0;
        var currentNode = head;
        while (currentNode != null)
        {
            currentNode = currentNode.next;
            linkedListCount++;
        }

        var middleElementNumber = (linkedListCount / 2);
        ListNode nodeToUpdate = null;
        currentNode = head;
        for (var i = 0; i <= middleElementNumber; i++)
        {
            if (i == middleElementNumber - 1)
            {
                nodeToUpdate = currentNode;
            }

            if (i == middleElementNumber)
            {
                var nextNode = currentNode.next;
                nodeToUpdate.next = nextNode;
                break;
            }

            currentNode = currentNode.next;
        }

        return head;
    }
}

public class DeleteMiddleNodOffLinkedListAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 1, 3, 4, 7, 1, 2, 6 }, new[] { 1, 3, 4, 1, 2, 6 })]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 4 })]
    [InlineData(new[] { 2, 1 }, new[] { 2 })]
    public void DeleteMiddle_ShouldEqualExpected(int[] input, int[] expected)
    {
        // Arrange
        var head = LinkedListTestUtils.ArrayToLinkedList(input);

        // Act
        var result = DeleteMiddleNodOffLinkedListAlgorithm.DeleteMiddle(head);
        var resultArray = LinkedListTestUtils.LinkedListToArray(result);

        // Assert
        Assert.Equal(resultArray, expected);
    }
}