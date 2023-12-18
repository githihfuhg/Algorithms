using Xunit;

namespace Algorithms.LeetCode.SlidingWindow;

/// <summary>
/// Maximum Average Subarray I.
/// <see href="https://leetcode.com/problems/maximum-average-subarray-i"/>
/// </summary>
public class MaximumAverageSubarrayAlgorithm
{
    public static double FindMaxAverage(int[] nums, int k)
    {
        var sum = 0d;
        for (var i = 0; i < k; i++)
        {
            sum += nums[i];
        }

        var average = sum / k;
        for (var i = k; i < nums.Length; i++)
        {
            sum += (nums[i] - nums[i - k]);
            average = Math.Max(average, sum / k);
        }

        return average;
    }
}

public class MaximumAverageSubarrayAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 1,12,-5,-6,50,3 }, 4,  12.75000)]
    [InlineData(new[] { -1 }, 1, -1d)]
    public void FindMaxAverage_ShouldEqualExpected(int[] nums, int k, double expected)
    {
        // Act
        var result = MaximumAverageSubarrayAlgorithm.FindMaxAverage(nums, k);
 
        // Assert
        Assert.Equal(result, expected);
    }
}