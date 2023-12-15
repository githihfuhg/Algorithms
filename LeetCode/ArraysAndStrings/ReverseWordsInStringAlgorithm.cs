using Xunit;

namespace Algorithms.LeetCode.ArraysAndStrings;

/// <summary>
/// Reverse Words in a String.
/// <see href="https://leetcode.com/problems/reverse-words-in-a-string"/>
/// </summary>
public class ReverseWordsInStringAlgorithm
{
    public static string ReverseWords(string s)
    {
        var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);

        return string.Join(' ', words);
    }
}

public class ReverseWordsInStringTest
{
    [Theory]
    [InlineData("the sky is blue", "blue is sky the")]
    [InlineData("  hello world  ", "world hello")]
    [InlineData("a good   example", "example good a")]
    [InlineData(" asdasd df f", "f df asdasd")]
    public void ReverseWords_ShouldEqualExpected(string input, string expected)
    {
        // Act
        var result = ReverseWordsInStringAlgorithm.ReverseWords(input);

        // Assert
        Assert.Equal(result, expected);
    }
}