using Xunit;

namespace Algorithms.LeetCode.DictionariesAndHashmaps;

/// <summary>
/// Equal Row and Column Pairs.
/// <see href="https://leetcode.com/problems/equal-row-and-column-pairs"/>
/// </summary>
public class EqualRowAndColumnPairsAlgorithm
{
    public static int EqualPairs(int[][] grid)
    {
        var hashCountByHash = new Dictionary<string, int>();
        foreach (var row in grid)
        {
            var hash = CalculateHash(row);
            if (hashCountByHash.TryGetValue(hash, out var rowHashCount))
            {
                hashCountByHash[hash] = rowHashCount + 1;
                continue;
            }

            hashCountByHash[hash] = 1;
        }

        var pairCount = 0;
        var columnsLength = grid[0].Length;
        for (var columnIndex = 0; columnIndex < columnsLength; columnIndex++)
        {
            var column = grid.Select(row => row[columnIndex]);
            var columnHash = CalculateHash(column);

            if (hashCountByHash.TryGetValue(columnHash, out var hashCount))
            {
                pairCount += hashCount;
            }
        }

        return pairCount;
    }

    private static string CalculateHash(IEnumerable<int> array)
    {
        const char hashSeparator = '_';

        return string.Join(hashSeparator, array);
    }
}

public class EqualRowAndColumnPairsAlgorithmTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void EqualPairs_ShouldEqualExpected(int[][] grid, int expected)
    {
        // Act
        var result = EqualRowAndColumnPairsAlgorithm.EqualPairs(grid);

        // Assert
        Assert.Equal(result, expected);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            new int[][] { new[] { 123 } },
            1
        };
        yield return new object[]
        {
            new int[][] { new[] { 3, 1, 2, 2 }, new[] { 1, 4, 4, 5 }, new[] { 2, 4, 2, 2 }, new[] { 2, 4, 2, 2 } },
            3
        };     
        yield return new object[]
        {
            new int[][] { new[] { 11, 1 }, new[] { 1, 11 } },
            2
        };
    }
}