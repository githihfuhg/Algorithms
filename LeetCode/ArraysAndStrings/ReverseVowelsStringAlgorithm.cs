using Xunit;

namespace Algorithms.LeetCode.ArraysAndStrings;

/// <summary>
/// Can Place Flowers.
/// <see href="https://leetcode.com/problems/can-place-flowers"/>
/// </summary>
public class ReverseVowelsStringAlgorithm
{
    public static string ReverseVowels(string s)
    {
        var allVowelLetters = new HashSet<char>() { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
        var symbols = s.ToCharArray();
        var vowelLetters = symbols.Where(x => allVowelLetters.Contains(x));
        var vowelLettersStack = new Stack<char>(vowelLetters);

        for (var index = 0; index < symbols.Length; index++)
        {
            var symbol = symbols[index];
            if (allVowelLetters.Contains(symbol))
            {
                symbols[index] = vowelLettersStack.Pop();
            }
        }

        return new string(symbols);
    }
}

public class ReverseVowelsStringAlgorithmTest
{
    [Theory]
    [InlineData("hello", "holle")]
    [InlineData("leetcode", "leotcede")]
    [InlineData("aA", "Aa")]
    [InlineData("race car", "race car")]
    public void ReverseVowels_ShouldEqualExpected(string input, string expected)
    {
        // Act
        var result = ReverseVowelsStringAlgorithm.ReverseVowels(input);

        // Assert
        Assert.Equal(result, expected);
    }
}