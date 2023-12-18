using Xunit;

namespace Algorithms.LeetCode.TwoPointers;

/// <summary>
/// Container With Most Water.
/// <see href="https://leetcode.com/problems/container-with-most-water"/>
/// </summary>
public class ContainerWithMostWaterAlgorithm
{
    public static int MaxArea(int[] height)
    {
        var maxCapacity = 0;
        var leftIndex = 0;
        var rightIndex = height.Length - 1;

        while (leftIndex < rightIndex)
        {
            var leftHeight = height[leftIndex];
            var rightHeight = height[rightIndex];
            var reservoirLength = rightIndex - leftIndex;
            var reservoirHeight = Math.Min(leftHeight, rightHeight);
            var capacity = reservoirLength * reservoirHeight;

            if (maxCapacity < capacity)
            {
                maxCapacity = capacity;
            }

            if (leftHeight < rightHeight)
            {
                leftIndex++;
            }
            else
            {
                rightIndex--;
            }
        }

        return maxCapacity;
    }
}

public class ContainerWithMostWaterAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    [InlineData(new[] { 1, 2, 1 }, 2)]
    public void MaxArea_ShouldEqualExpected(int[] height, int expected)
    {
        // Act
        var result = ContainerWithMostWaterAlgorithm.MaxArea(height);

        // Assert
        Assert.Equal(result, expected);
    }
}