using Xunit;

namespace Algorithms.LeetCode.Stacks;

/// <summary>
///  Decode String.
/// <see href="https://leetcode.com/problems/decode-string"/>
/// </summary>
public class DecodeStringAlgorithm
{
    public static string DecodeString(string s)
    {
        var symbolsStack = new Stack<char>();
        var substringInformationStack = new Stack<(int substringStart, int duplicateCount)>();
        foreach (var symbol in s)
        {
            if (symbol == '[')
            {
                var duplicateCount = ReadNumber(symbolsStack);
                substringInformationStack.Push((symbolsStack.Count, duplicateCount));

                continue;
            }

            if (symbol == ']')
            {
                var substringInformation = substringInformationStack.Pop();
                var symbolsCount = symbolsStack.Count - substringInformation.substringStart;

                DuplicateSymbols(symbolsStack, symbolsCount, substringInformation.duplicateCount);

                continue;
            }

            symbolsStack.Push(symbol);
        }

        var resultSymbols = symbolsStack.Reverse();
        var result = string.Concat(resultSymbols);

        return result;
    }

    private static int ReadNumber(Stack<char> stack)
    {
        var numberSymbol = stack.Peek();
        var isNumber = char.IsDigit(numberSymbol);
        var numbers = new Stack<char>();
        while (isNumber)
        {
            stack.Pop();
            numbers.Push(numberSymbol);

            isNumber = stack.TryPeek(out numberSymbol) && char.IsDigit(numberSymbol);
        }

        var numberInString = string.Concat(numbers);
        var result = int.Parse(numberInString);

        return result;
    }

    private static void DuplicateSymbols(Stack<char> stack, int symbolsCount, int duplicateCount)
    {
        var symbolsToCopyStack = new Stack<char>();
        for (var i = 0; i < symbolsCount; i++)
        {
            var symbolToCopy = stack.Pop();
            symbolsToCopyStack.Push(symbolToCopy);
        }

        for (var i = 0; i < duplicateCount; i++)
        {
            foreach (var symbolToCopy in symbolsToCopyStack)
            {
                stack.Push(symbolToCopy);
            }
        }
    }
}

public class DecodeStringAlgorithmTest
{
    [Theory]
    [InlineData("100[leetcode]", "leetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcode")]
    [InlineData("3[a]2[bc]", "aaabcbc")]
    [InlineData("3[a2[c]]", "accaccacc")]
    [InlineData("2[abc]3[cd]ef", "abcabccdcdcdef")]
    public void DecodeString_ShouldEqualExpected(string s, string expected)
    {
        // Act
        var result = DecodeStringAlgorithm.DecodeString(s);

        // Assert
        Assert.Equal(result, expected);
    }
}