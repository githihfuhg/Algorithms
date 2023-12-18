using Xunit;

namespace Algorithms.LeetCode.HashMaps;

/// <summary>
/// Find the Difference of Two Arrays.
/// <see href="https://leetcode.com/problems/find-the-difference-of-two-arrays"/>
/// </summary>
public class FindTheDifferenceTwoArraysAlgorithm
{
    public static IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        var firstDistinctNums = new HashSet<int>(nums1);
        var secondDistinctNums = new HashSet<int>(nums2);

        var firstDiffList = firstDistinctNums
            .Where(x => !secondDistinctNums.Contains(x))
            .ToList();
        var secondDiffList = secondDistinctNums
            .Where(x => !firstDistinctNums.Contains(x))
            .ToList();
        
        var result = new List<IList<int>>()
        {
            firstDiffList,
            secondDiffList
        };

        return result;
    }

    public static IList<IList<int>> FindDifference2(int[] nums1, int[] nums2)
    {
        var firstDistinctNums = new HashSet<int>(nums1);
        var secondDistinctNums = new HashSet<int>(nums2);

        firstDistinctNums.ExceptWith(nums2);
        secondDistinctNums.ExceptWith(nums1);

        var result = new List<IList<int>>()
        {
            firstDistinctNums.ToList(),
            secondDistinctNums.ToList()
        };

        return result;
    }
}

public class FindTheDifferenceTwoArraysAlgorithmTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void FindDifference_ShouldEqualExpected(int[] nums1, int[] nums2, IList<IList<int>> expected)
    {
        // Act
        var result = FindTheDifferenceTwoArraysAlgorithm.FindDifference(nums1, nums2);
        var result2 = FindTheDifferenceTwoArraysAlgorithm.FindDifference2(nums1, nums2);

        // Assert
        Assert.Equal(result, expected);
        Assert.Equal(result2, expected);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            new[] { 1, 2, 3 },
            new[] { 2, 4, 6 },
            new List<IList<int>>() { new List<int>() { 1, 3 }, new List<int>() { 4, 6 } }
        };
        yield return new object[]
        {
            new[] { 1, 2, 3, 3 },
            new[] { 1, 1, 2, 2 },
            new List<IList<int>>() { new List<int>() { 3 }, new List<int>() }
        };
    }
}