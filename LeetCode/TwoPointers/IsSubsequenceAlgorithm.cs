using Xunit;

namespace Algorithms.LeetCode.TwoPointers;

/// <summary>
/// Is Subsequence.
/// <see href="https://leetcode.com/problems/is-subsequence"/>
/// </summary>
public class IsSubsequenceAlgorithm
{
    public static bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0)
        {
            return true;
        }

        var substringSymbols = new Queue<char>(s);
        var currentSubstringSymbol = substringSymbols.Peek();

        foreach (var symbol in t)
        {
            if (currentSubstringSymbol != symbol)
            {
                continue;
            }

            if (!substringSymbols.TryDequeue(out currentSubstringSymbol))
            {
                return true;
            }

            if (!substringSymbols.TryPeek(out currentSubstringSymbol))
            {
                return true;
            }
        }

        return substringSymbols.Count == 0;
    }

    public static bool IsSubsequence2(string s, string t)
    {
        var symbolCounter = 0;
        for (var i = 0; i <= t.Length; i++)
        {
            if (symbolCounter == s.Length)
            {
                return true;
            }

            if (i == t.Length)
            {
                break;
            }

            var symbol = t[i];
            var substringSymbol = s[symbolCounter];
            if (symbol == substringSymbol)
            {
                symbolCounter += 1;
            }
        }

        return false;
    }
}

public class IsSubsequenceAlgorithmTest
{
    [Theory]
    [InlineData("abc", "ahbgdc", true)]
    [InlineData("axc", "ahbgdc", false)]
    [InlineData("b", "c", false)]
    [InlineData("acb", "ahbgdc", false)]
    public static void IsSubsequence_ShouldEqualExpected(string substring, string line, bool expected)
    {
        // Act
        var result = IsSubsequenceAlgorithm.IsSubsequence(substring, line);
        var result2 = IsSubsequenceAlgorithm.IsSubsequence2(substring, line);

        // Assert
        Assert.Equal(result, expected);
        Assert.Equal(result2, expected);
    }
}