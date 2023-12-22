using Xunit;

namespace Algorithms.LeetCode.Queues;

/// <summary>
/// Number of Recent Calls.
/// <see href="https://leetcode.com/problems/number-of-recent-calls"/>
/// </summary>
public class RecentCounter
{
    private readonly Queue<int> _requestQueue;

    public RecentCounter()
    {
        _requestQueue = new Queue<int>();
    }

    public int Ping(int t)
    {
        _requestQueue.Enqueue(t);

        const int interval = 3000;
        var minTime = t - interval;
        while(_requestQueue.Peek() < minTime){
            _requestQueue.Dequeue();
        }

        return _requestQueue.Count;
    }
}

public class NumberOfRecentCallsAlgorithm
{
    private static readonly RecentCounter _recentCounter = new RecentCounter();

    public static int Ping(int t)
    {
        return _recentCounter.Ping(t);
    }
}

public class NumberIOfRecentCallsAlgorithmTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Ping_ShouldEqualExpected(List<(int input, int excepted)> testCases)
    {
        foreach (var testCase in testCases)
        {
            // Act
            var result = NumberOfRecentCallsAlgorithm.Ping(testCase.input);

            // Assert
            Assert.Equal(result, testCase.excepted);
        }
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            new List<(int input, int excepted)>
            {
                (1, 1),
                (10, 2),
                (3001, 3),
                (3002, 3)
            },
        };
    }
}