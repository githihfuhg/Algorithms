using Xunit;

namespace Algorithms.LeetCode.BinaryTrees;

/// <summary>
/// Count Good Nodes in Binary Tree.
/// <see href="https://leetcode.com/problems/count-good-nodes-in-binary-tree"/>
/// </summary>
public class CountGoodNodesInBinaryTreeAlgorithm
{
    public static int GoodNodes(TreeNode root)
    {
        return CountGoodNodes(root, root.val);
    }

    private static int CountGoodNodes(TreeNode root, int maxPreviousValue)
    {
        if (root == null)
        {
            return 0;
        }

        var maxValue = Math.Max(maxPreviousValue, root.val);
        var leftCount = CountGoodNodes(root.left, maxValue);
        var rightCount = CountGoodNodes(root.right, maxValue);

        var result = maxPreviousValue > root.val
            ? rightCount + leftCount
            : rightCount + leftCount + 1;

        return result;
    }
}

public class CountGoodNodesInBinaryTreeAlgorithmTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void GoodNodes_ShouldEqualExpected(TreeNode input, int excepted)
    {
        // Act
        var result = CountGoodNodesInBinaryTreeAlgorithm.GoodNodes(input);

        // Assert
        Assert.Equal(result, excepted);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            new TreeNode
            {
                left = new TreeNode()
                {
                    left = new TreeNode()
                    {
                        val = 3
                    },
                    val = 1
                },
                right = new TreeNode()
                {
                    left = new TreeNode()
                    {
                        val = 1
                    },
                    right = new TreeNode()
                    {
                        val = 5
                    },
                    val = 4
                },
                val = 3
            },
            4
        };
    }
}