using Xunit;

namespace Algorithms.LeetCode.DictionariesAndHashmaps;

/// <summary>
/// Determine if Two Strings Are Close.
/// <see href="https://leetcode.com/problems/determine-if-two-strings-are-close"/>
/// </summary>
public class DetermineIfTwoStringsCloseAlgorithm
{
    public static bool CloseStrings(string word1, string word2)
    {
        if (word1.Length != word2.Length)
        {
            return false;
        }

        var firstLetterCountByLetter = ArrayToCountByArrayItem(word1);
        var secondLetterCountByLetter = ArrayToCountByArrayItem(word2);
        if (firstLetterCountByLetter.Count != secondLetterCountByLetter.Count)
        {
            return false;
        }

        foreach (var (letter, _) in secondLetterCountByLetter)
        {
            if (!firstLetterCountByLetter.ContainsKey(letter))
            {
                return false;
            }
        }

        var firstCountByLetterCount = ArrayToCountByArrayItem(firstLetterCountByLetter.Values);
        var secondCountByLetterCount = ArrayToCountByArrayItem(secondLetterCountByLetter.Values);
        if (firstCountByLetterCount.Count != secondCountByLetterCount.Count)
        {
            return false;
        }

        foreach (var (secondKey, secondValue) in secondCountByLetterCount)
        {
            if (!firstCountByLetterCount.TryGetValue(secondKey, out var firstValue))
            {
                return false;
            }

            if (firstValue != secondValue)
            {
                return false;
            }
        }

        return true;
    }

    private static Dictionary<T, int> ArrayToCountByArrayItem<T>(IEnumerable<T> array)
    {
        var arrayItemCountByArrayItem = new Dictionary<T, int>();
        foreach (var item in array)
        {
            if (arrayItemCountByArrayItem.TryGetValue(item, out var itemCount))
            {
                arrayItemCountByArrayItem[item] = itemCount + 1;
                continue;
            }

            arrayItemCountByArrayItem[item] = 1;
        }

        return arrayItemCountByArrayItem;
    }
}

public class DetermineIfTwoStringsCloseAlgorithmTest
{
    [Theory]
    [InlineData("abbbzcf", "babzzcz", false)]
    [InlineData("abc", "bca", true)]
    [InlineData("a", "aa", false)]
    [InlineData("cabbba", "abbccc", true)]
    [InlineData("abbzzca", "babzzcz", false)]
    public void CloseStrings_ShouldEqualExpected(string word1, string word2, bool expected)
    {
        // Act
        var result = DetermineIfTwoStringsCloseAlgorithm.CloseStrings(word1, word2);

        // Assert
        Assert.Equal(result, expected);
    }
}