using Xunit;

namespace Algorithms.LeetCode.TwoPointers;

/// <summary>
/// Move Zeroes.
/// <see href="https://leetcode.com/problems/move-zeroes"/>
/// </summary>
public class MoveZeroesAlgorithm
{
    public static void MoveZeroes(int[] nums)
    {
        var index = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                continue;
            }

            nums[index] = nums[i];

            if (index != i)
            {
                nums[i] = 0;
            }

            index++;
        }
    }
}

public class MoveZeroesAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 0, 1, 0, 3, 12 }, new[] { 1, 3, 12, 0, 0 })]
    [InlineData(new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 0, 0, 1 }, new[] { 1, 0, 0 })]
    public void MoveZeroes_ShouldEqualExpected(int[] nums, int[] expected)
    {
        // Act
        MoveZeroesAlgorithm.MoveZeroes(nums);

        // Assert
        Assert.Equal(nums, expected);
    }
}