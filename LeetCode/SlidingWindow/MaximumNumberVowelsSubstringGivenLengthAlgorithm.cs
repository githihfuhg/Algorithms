using Xunit;

namespace Algorithms.LeetCode.SlidingWindow;

/// <summary>
/// Maximum Number of Vowels in a Substring of Given Length.
/// <see href="https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length"/>
/// </summary>
public class MaximumNumberVowelsSubstringGivenLengthAlgorithm
{
    public static int MaxVowels(string s, int k)
    {
        var maxVowelsCount = 0;
        var substringVowelsCount = 0;
        for (int index = 0, substringIndex = 0; index < s.Length; index++)
        {
            var letter = s[index];
            if (IsVowel(letter))
            {
                substringVowelsCount++;
            }

            if (index - substringIndex + 1 != k)
            {
                continue;
            }

            maxVowelsCount = Math.Max(maxVowelsCount, substringVowelsCount);
            var substringLetter = s[substringIndex];
            if (IsVowel(substringLetter))
            {
                substringVowelsCount--;
            }

            substringIndex++;
        }

        return maxVowelsCount;
    }

    private static bool IsVowel(char symbol)
    {
        return (symbol == 'a' || symbol == 'o' || symbol == 'e' || symbol == 'u' || symbol == 'i');
    }
}

public class MaximumNumberVowelsSubstringGivenLengthAlgorithmTest
{
    [Theory]
    [InlineData("abciiidef", 3, 3)]
    [InlineData("aeiou", 2, 2)]
    [InlineData("leetcode", 3, 2)]
    [InlineData("tryhard", 4, 1)]
    [InlineData("weallloveyou", 7, 4)]
    public void MaxVowels_ShouldEqualExpected(string s, int k, int expected)
    {
        // Act
        var result = MaximumNumberVowelsSubstringGivenLengthAlgorithm.MaxVowels(s, k);

        // Assert
        Assert.Equal(result, expected);
    }
}