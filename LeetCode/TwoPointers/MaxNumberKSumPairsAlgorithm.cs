using Xunit;

namespace Algorithms.LeetCode.TwoPointers;

public class MaxNumberKSumPairsAlgorithm
{
    public static int MaxOperations(int[] nums, int k)
    {
        Array.Sort(nums);

        var leftIndex = 0;
        var rightIndex = nums.Length - 1;
        var operationsCount = 0;

        while (leftIndex < rightIndex)
        {
            var rightNumber = nums[rightIndex];
            if (rightNumber > k)
            {
                rightIndex--;
                continue;
            }

            var leftNumber = nums[leftIndex];
            var sum = leftNumber + rightNumber;
            if (sum == k)
            {
                leftIndex++;
                rightIndex--;
                operationsCount++;
                continue;
            }

            if (sum < k)
            {
                leftIndex++;
            }
            else
            {
                rightIndex--;
            }
        }

        return operationsCount;
    }
}

public class MaxNumberKSumPairsAlgorithmTest
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, 5, 2)]
    [InlineData(new[] { 3, 1, 3, 4, 3 }, 6, 1)]
    [InlineData(new[] { 4,4,1,3,1,3,2,2,5,5,1,5,2,1,2,3,5,4}, 2, 2)]
    public void MaxOperations_ShouldEqualExpected(int[] nums, int k, int expected)
    {
        // Act
        var result = MaxNumberKSumPairsAlgorithm.MaxOperations(nums, k);

        // Assert
        Assert.Equal(result, expected);
    }
}