using Xunit;

namespace Algorithms.LeetCode.ArraysAndStrings;

/// <summary>
/// Product of Array Except Self.
/// <see href="https://leetcode.com/problems/product-of-array-except-self"/>
/// </summary>
public class ProductArrayExceptSelfAlgorithm
{
    public static int[] ProductExceptSelf(int[] nums)
    {
        var resultArray = new int[nums.Length];
        var right = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            resultArray[i] = right;
            right *= nums[i];
        }

        var left = 1;
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            resultArray[i] *= left;
            left *= nums[i];
        }

        return resultArray;
    }
}

public class ProductArrayExceptSelfAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 24, 12, 8, 6 })]
    [InlineData(new[] { -1, 1, 0, -3, 3 }, new[] { 0, 0, 9, 0, 0 })]
    public void ProductExceptSelf_ShouldEqualExpected(int[] nums, int[] expected)
    {
        // Act
        var result = ProductArrayExceptSelfAlgorithm.ProductExceptSelf(nums);

        // Assert
        Assert.Equal(result, expected);
    }
}