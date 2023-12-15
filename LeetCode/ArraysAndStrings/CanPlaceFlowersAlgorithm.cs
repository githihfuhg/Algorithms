using Xunit;

namespace Algorithms.LeetCode.ArraysAndStrings;

/// <summary>
/// Reverse Vowels of a String.
/// <see href="https://leetcode.com/problems/reverse-vowels-of-a-string"/>
/// </summary>
public class CanPlaceFlowersAlgorithm
{
    public static bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        var insertedFlowerCount = 0;
        for (var i = 0; i < flowerbed.Length; i++)
        {
            var isSkip = flowerbed[i] != 0
                         || (i != 0 && flowerbed[i - 1] != 0)
                         || (i != flowerbed.Length - 1 && flowerbed[i + 1] != 0);
            if (isSkip)
            {
                continue;
            }

            flowerbed[i] = 1;
            insertedFlowerCount++;
        }

        var result = insertedFlowerCount >= n;

        return result;
    }
}

public class CanPlaceFlowersAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 1, 0, 0, 0, 1 }, 1, true)]
    [InlineData(new[] { 1, 0, 0, 0, 1 }, 2, false)]
    [InlineData(new[] { 1, 0, 0, 0, 0, 1 }, 2, false)]
    [InlineData(new[] { 1, 0, 0, 0, 0, 0, 0, 0, 1 }, 3, true)]
    [InlineData(new[] { 1, 0, 1, 0, 1, 0, 1 }, 0, true)]
    [InlineData(new[] { 0, 0, 1, 0, 1 }, 1, true)]
    [InlineData(new[] { 1, 0, 0, 0, 1, 0, 0 }, 2, true)]
    public void CanPlaceFlowers_ShouldEqualExpected(int[] flowerbed, int n, bool expected)
    {
        // Act
        var result = CanPlaceFlowersAlgorithm.CanPlaceFlowers(flowerbed, n);

        // Assert
        Assert.Equal(result, expected);
    }
}