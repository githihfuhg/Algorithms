using Xunit;

namespace Algorithms.LeetCode.ArraysAndStrings;

/// <summary>
/// Increasing Triplet Subsequence.
/// <see href="https://leetcode.com/problems/increasing-triplet-subsequence"/>
/// </summary>
public class IncreasingTripletSubsequenceAlgorithm
{
    public static bool IncreasingTriplet(int[] nums)
    {
        const int minSequenceLength = 3;
        if (nums.Length < minSequenceLength)
        {
            return false;
        }

        var smallest = int.MaxValue;
        var secondSmallest = int.MaxValue;
        foreach (var number in nums)
        {
            if (number <= smallest)
            {
                smallest = number;
            }

            else if (number <= secondSmallest)
            {
                secondSmallest = number;
            }

            else
            {
                return true;
            }
        }

        return false;
    }
}

public class IncreasingTripletSubsequenceAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, true)]
    [InlineData(new[] { 2, 1, 5, 0, 4, 6 }, true)]
    [InlineData(new[] { 5, 4, 3, 2, 1 }, false)]
    [InlineData(new[] { 20, 100, 10, 12, 5, 13 }, true)]
    [InlineData(new[] { 1, 5, 0, 4, 1, 3 }, true)]
    public void IncreasingTriplet_ShouldEqualExpected(int[] nums, bool expected)
    {
        // Act
        var result = IncreasingTripletSubsequenceAlgorithm.IncreasingTriplet(nums);

        // Assert
        Assert.Equal(result, expected);
    }
}