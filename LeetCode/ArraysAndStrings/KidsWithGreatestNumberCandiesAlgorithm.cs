using Xunit;

namespace Algorithms.LeetCode.ArraysAndStrings;

/// <summary>
/// Kids With the Greatest Number of Candies.
/// <see href="https://leetcode.com/problems/kids-with-the-greatest-number-of-candies"/>
/// </summary>
public class KidsWithGreatestNumberCandiesAlgorithm
{
    public static IList<bool> KidsWithCandies(int[] candyCounts, int extraCandies)
    {
        var maxCandyCount = candyCounts.Max();
        var result = new List<bool>(candyCounts.Length);
        foreach (var candyCount in candyCounts)
        {
            var isMaxCount = candyCount + extraCandies >= maxCandyCount;
            result.Add(isMaxCount);
        }

        return result;
    }
}

public class KidsWithGreatestNumberCandiesAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 2, 3, 5, 1, 3 }, 3, new[] { true, true, true, false, true })]
    [InlineData(new[] { 4, 2, 1, 1, 2 }, 1, new[] { true, false, false, false, false })]
    public void KidsWithCandies_ShouldEqualExpected(int[] candyCounts, int extraCandies, IList<bool> expected)
    {
        // Act
        var result = KidsWithGreatestNumberCandiesAlgorithm.KidsWithCandies(candyCounts, extraCandies);

        // Assert
        Assert.Equal(result, expected);
    }
}