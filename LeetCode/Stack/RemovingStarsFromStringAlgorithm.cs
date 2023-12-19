using Xunit;

namespace Algorithms.LeetCode.Stack;

/// <summary>
///  Removing Stars From a String.
/// <see href="https://leetcode.com/problems/removing-stars-from-a-string"/>
/// </summary>
public class RemovingStarsFromStringAlgorithm
{
    public static string RemoveStars(string s)
    {
        var letters = new Stack<char>();
        foreach (var letter in s)
        {
            if (letter == '*')
            {
                letters.TryPop(out _);
                continue;
            }
            
            letters.Push(letter);
        }

        var resultLetters = letters.Reverse();
        var result = string.Concat(resultLetters);

        return result;
    }
}

public class RemovingStarsFromStringAlgorithmTest
{
    [Theory]
    [InlineData("leet**cod*e", "lecoe")]
    [InlineData("erase*****", "")]
    public void RemoveStars_ShouldEqualExpected(string s, string expected)
    {
        // Act
        var result = RemovingStarsFromStringAlgorithm.RemoveStars(s);
 
        // Assert
        Assert.Equal(result, expected);
    }
}