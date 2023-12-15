using System.Text;
using Xunit;

namespace Algorithms.LeetCode.ArraysAndStrings;

/// <summary>
/// String Compression.
/// <see href="https://leetcode.com/problems/string-compression"/>
/// </summary>
public class StringCompressionAlgorithm
{
    public static int Compress(char[] chars)
    {
        var compressedSymbols = new StringBuilder();
        var firstSymbol = chars[0];
        var duplicatedCount = 1;

        if (chars.Length == 1)
        {
            return 1;
        }

        for (var index = 1; index < chars.Length; index++)
        {
            var secondSymbol = chars[index];

            if (firstSymbol == secondSymbol)
            {
                duplicatedCount++;
            }

            var isLast = index == chars.Length - 1;

            if (firstSymbol != secondSymbol || isLast)
            {
                compressedSymbols.Append(firstSymbol);
                if (duplicatedCount > 1)
                {
                    compressedSymbols.Append(duplicatedCount);
                }

                duplicatedCount = 1;
            }

            if (firstSymbol != secondSymbol && isLast)
            {
                compressedSymbols.Append(secondSymbol);
            }

            firstSymbol = secondSymbol;
        }

        compressedSymbols.CopyTo(0, chars, compressedSymbols.Length);

        return compressedSymbols.Length;
    }
}

public class StringCompressionAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' }, 6)]
    [InlineData(new[] { 'a' }, 1)]
    [InlineData(new[] { 'a', 'b', 'c' }, 3)]
    [InlineData(new[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' }, 4)]
    public void Compress_ShouldEqualExpected(char[] chars, int expected)
    {
        // Act
        var result = StringCompressionAlgorithm.Compress(chars);

        // Assert
        Assert.Equal(result, expected);
    }
}