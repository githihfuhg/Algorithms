namespace Algorithms.LeetCode.BinaryTrees;

/// <summary>
/// Path Sum III.
/// <see href="https://leetcode.com/problems/path-sum-iii"/>
/// </summary>
public class PathSumAlgorithm
{
    public int PathSum(TreeNode root, int targetSum)
    {
        var result = CountPathWithTargetSum(root, targetSum);

        return result.pathCount;
    }

    //ToDo: Переделать
    private static (int pathCount, int nodesSum) CountPathWithTargetSum(TreeNode root, int targetSum)
    {
        if (root == null)
        {
            return (0,0);
        }

        var (leftCount, leftSum) = CountPathWithTargetSum(root.left, targetSum);
        var (rightCount, rightSum) = CountPathWithTargetSum(root.right, targetSum);

        var pathCount = leftCount + rightCount;
        if (leftSum == targetSum)
        {  
            pathCount++;
        }

        if (rightCount == targetSum)
        {
            pathCount++;
        }

        var sum = leftSum + rightSum + targetSum;

        return (pathCount, sum);
    }
}