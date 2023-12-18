using Xunit;

namespace Algorithms.LeetCode.HashMaps;

/// <summary>
/// Unique Number of Occurrences.
/// <see href="https://leetcode.com/problems/unique-number-of-occurrences"/>
/// </summary>
public class UniqueNumberOccurrencesAlgorithm
{
    public static bool UniqueOccurrences(int[] arr)
    {
        var numberCountByNumber = new Dictionary<int, int>();
        foreach (var number in arr)
        {
            if (numberCountByNumber.TryGetValue(number, out var numberCount))
            {
                numberCountByNumber[number] = numberCount + 1;
                continue;
            }

            numberCountByNumber[number] = 0;
        }

        var numberCounts = new HashSet<int>();
        foreach (var (_, numberCount) in numberCountByNumber)
        {
            if (!numberCounts.Add(numberCount))
            {
                return false;
            }
        }

        return true;
    }
}

public class UniqueNumberOccurrencesAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 1, 2, 2, 1, 1, 3 }, true)]
    [InlineData(new[] { 1, 2 }, false)]
    [InlineData(new[] { -3, 0, 1, -3, 1, 1, 1, -3, 10, 0 }, true)]
    public void UniqueOccurrences_ShouldEqualExpected(int[] arr, bool expected)
    {
        // Act
        var result = UniqueNumberOccurrencesAlgorithm.UniqueOccurrences(arr);

        // Assert
        Assert.Equal(result, expected);
    }
}