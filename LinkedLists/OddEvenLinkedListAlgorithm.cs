using Algorithms.LinkedLists.TestUtils;
using Xunit;

namespace Algorithms.LinkedLists;

/// <summary>
/// Odd Even Linked List.
/// <see href="https://leetcode.com/problems/odd-even-linked-list"/>
/// </summary>
public class OddEvenLinkedListAlgorithm
{
    public static ListNode OddEvenList(ListNode head)
    {
        if (head == null)
        {
            return head;
        }

        var linkedListCount = 1;
        var lastNode = head;
        while (lastNode.next != null)
        {
            lastNode = lastNode.next;
            linkedListCount++;
        }

        var evenValuesCount = linkedListCount / 2;
        var counter = 0;
        var notEvenNode = head;
        var evenNode = head.next;
        while (notEvenNode.next != null && evenNode?.next != null && counter < evenValuesCount)
        {
            var nextNotEvenNode = notEvenNode.next.next;
            var nextEvenNode = evenNode.next.next;

            notEvenNode.next = nextNotEvenNode;
            evenNode.next = null;
            lastNode.next = evenNode;
            lastNode = evenNode;

            evenNode = nextEvenNode;
            notEvenNode = nextNotEvenNode;
            counter++;
        }

        return head;
    }
}

public class OddEvenLinkedListAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5, }, new[] { 1, 3, 5, 2, 4 })]
    [InlineData(new[] { 2, 1, 3, 5, 6, 4, 7 }, new[] { 2, 3, 6, 7, 1, 5, 4 })]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1, 3, 2 })]
    [InlineData(new[] { 1, 1 }, new[] { 1, 1 })]
    public void OddEvenList_ShouldEqualExpected(int[] input, int[] expected)
    {
        // Arrange
        var head = LinkedListTestUtils.ArrayToLinkedList(input);

        // Act
        var result = OddEvenLinkedListAlgorithm.OddEvenList(head);
        var resultArray = LinkedListTestUtils.LinkedListToArray(result);

        // Assert
        Assert.Equal(resultArray, expected);
    }
}